using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sales_Tracker;

namespace The_Sales_Tracker
{
    /// <summary>
    /// MVC Controller class
    /// </summary>
    class Controller
    {
        #region FIELDS

        private bool _usingApplication;

        //
        // declare ConsoleView and Salesperson objects for the Controller to use
        //
        private ConsoleView _consoleView;
        private Salesperson _salesperson;

        #endregion

        #region PROPERTIES
        
        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            InitializeController();

            //
            // instantiate a Salesperson object
            //
            _salesperson = new Salesperson();

            //
            // instantiate a ConsoleView object
            //
            _consoleView = new ConsoleView();

            //
            // begins running the application UI
            //
            ManageApplicationLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the controller 
        /// </summary>
        private void InitializeController()
        {
            _usingApplication = true;
        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageApplicationLoop()
        {
            MenuOption userMenuChoice;

            _consoleView.DisplayWelcomeScreen();

            //
            // setup initial salesperson account
            //
            _salesperson = _consoleView.DisplaySetupAccount();

            //
            // application loop
            //
            while (_usingApplication)
            {
                //
                // get a menu choice from the ConsoleView object
                //
                userMenuChoice = _consoleView.DisplayGetUserMenuChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (userMenuChoice)
                {
                    case MenuOption.None:
                        break;
                    case MenuOption.AccountEdit:
                        DisplayUpdateAccountInfo();
                        break;
                    case MenuOption.Travel:
                        Travel();
                        break;
                    case MenuOption.Buy:
                        Buy();
                        break;
                    case MenuOption.Sell:
                        Sell();
                        break;
                    case MenuOption.DisplayInventory:
                        DisplayInventory();
                        break;
                    case MenuOption.DisplayCities:
                        DisplayCities();
                        break;
                    case MenuOption.DisplayAccountInfo:
                        DisplayAccountInfo();
                        break;
                    case MenuOption.Exit:
                        _usingApplication = false;
                        break;
                    default:
                        break;
                }
            }

            _consoleView.DisplayClosingScreen();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// add the next city location to the list of cities
        /// </summary>
        private void Travel()
        {
            string nextCity = _consoleView.DisplayGetNextCity();

            //
            // do not add empty strings to list for city names
            //
            if (nextCity != "")
            {
                _salesperson.CitiesVisited.Add(nextCity);
            }
        }

        /// <summary>
        /// display all cities traveled to
        /// </summary>
        private void DisplayCities()
        {
            _consoleView.DisplayCitiesTraveled(_salesperson);
        }

        /// <summary>
        /// display account information
        /// </summary>
        private void DisplayAccountInfo()
        {
            _consoleView.DisplayAccountInfo(_salesperson);
        }

        /// <summary>
        /// display account edit
        /// </summary>
        private void DisplayUpdateAccountInfo()
        {
            _consoleView.DisplayUpdateAccountInfo(_salesperson);
        }

        /// <summary>
        /// save account info
        /// </summary>
        private void DisplaySaveAccountInfo()
        {
            bool maxAttemptsExceeded = false;
            bool saveAccountInfo = false;

            saveAccountInfo = _consoleView.DisplaySaveAccountInfo(_salesperson, out maxAttemptsExceeded);

            if (saveAccountInfo && !maxAttemptsExceeded)
            {
                //CsvServices csvServices = new CsvServices(DataSettings.dataFilePathCsv);
                XmlServices xmlServices = new XmlServices(DataSettings.dataFilePathXml);

                //csvServices.WriteSalespersonToDataFile(_salesperson);
                xmlServices.WriteSalespersonToDataFile(_salesperson);

                _consoleView.DisplayConfirmSaveAccountInfo();
            }
        }

        /// <summary>
        /// display buy
        /// </summary>
        private void Buy()
        {
            int numberOfUnits = _consoleView.DisplayGetNumberOfUnitsToBuy(_salesperson.CurrentStock);
            _salesperson.CurrentStock.AddProducts(numberOfUnits);
        }

        /// <summary>
        /// display sell
        /// </summary>
        private void Sell()
        {
            int numberOfUnits = _consoleView.DisplayGetNumberOfUnitsToSell(_salesperson.CurrentStock);
            _salesperson.CurrentStock.SubtractProducts(numberOfUnits);

            if (_salesperson.CurrentStock.OnBackOrder)
            {
                _consoleView.DisplayBackOrderNotification(_salesperson.CurrentStock, numberOfUnits);
            }
        }

        /// <summary>
        /// call the display inventory
        /// </summary>
        private void DisplayInventory()
        {
            _consoleView.DisplayInventory(_salesperson.CurrentStock);
        }

        #endregion
    }
}
