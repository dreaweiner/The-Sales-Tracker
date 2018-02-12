﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sales_Tracker;

namespace The_Sales_Tracker
{
    /// <summary>
    /// MVC View class
    /// </summary>
    class ConsoleView
    {
        #region FIELDS

        private const int MAXIMUM_ATTEMPTS = 5;
        private const int MAXIMUM_BUYSELL_AMOUNT = 100;
        private const int MINIMUM_BUYSELL_AMOUNT = 0;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView()
        {
            InitializeConsole();
        }

        #endregion

        #region METHODS

        ///
        /// display backorder notification
        /// 
        public void DisplayBackOrderNotification(Product product, int numberOfUnitsSold)
        {
            ConsoleUtil.HeaderText = "Inventory Backorder Notification";
            ConsoleUtil.DisplayReset();

            int numberofUnitsBackordered = Math.Abs(product.NumberOfUnits);
            int numberofUnitsShipped = numberOfUnitsSold - numberofUnitsBackordered;

            ConsoleUtil.DisplayMessage("Products Sold: " + numberOfUnitsSold);
            ConsoleUtil.DisplayMessage("Products Shipped: " + numberofUnitsShipped);
            ConsoleUtil.DisplayMessage("Products on Backorder: " + numberofUnitsBackordered);

            DisplayContinuePrompt();
        }


        ///
        /// display get number of units to buy
        /// 
        public int DisplayGetNumberOfUnitsToBuy(Product product)
        {
            ConsoleUtil.HeaderText = "Buy Inventory";
            ConsoleUtil.DisplayReset();

            //
            // get number of products to buy
            //
            ConsoleUtil.DisplayMessage("Buying " + product.Type.ToString() + " Products.");
            ConsoleUtil.DisplayMessage("");

            if (!ConsoleValidator.TryGetIntegerFromUser(MINIMUM_BUYSELL_AMOUNT, MAXIMUM_BUYSELL_AMOUNT, MAXIMUM_ATTEMPTS, "products", out int numberOfUnitsToBuy))
            {
                ConsoleUtil.DisplayMessage("It appears you are having difficulty setting the number of products to buy.");
                ConsoleUtil.DisplayMessage("By default, the number of products to sell will be set to zero.");
                numberOfUnitsToBuy = 0;
                DisplayContinuePrompt();
            }

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(numberOfUnitsToBuy + " " + product.Type.ToString() + " products have been added to the inventory.");

            DisplayContinuePrompt();

            return numberOfUnitsToBuy;
        }

        ///
        /// display get number of units to sell
        /// 
        public int DisplayGetNumberOfUnitsToSell(Product product)
        {
            ConsoleUtil.HeaderText = "Sell Inventory";
            ConsoleUtil.DisplayReset();

            //
            // get number of products to sell
            //
            ConsoleUtil.DisplayMessage("Selling " + product.Type.ToString() + " Products.");
            ConsoleUtil.DisplayMessage("");

            if (!ConsoleValidator.TryGetIntegerFromUser(MINIMUM_BUYSELL_AMOUNT, MAXIMUM_BUYSELL_AMOUNT, MAXIMUM_ATTEMPTS, "products", out int numberOfUnitsToSell))
            {
                ConsoleUtil.DisplayMessage("It appears you are having difficulty setting the number of products to sell.");
                ConsoleUtil.DisplayMessage("By default, the number of products to sell will be set to zero.");
                numberOfUnitsToSell = 0;
                DisplayContinuePrompt();
            }

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(numberOfUnitsToSell + " " + product.Type.ToString() + " products have been subtracted from the inventory.");

            DisplayContinuePrompt();

            return numberOfUnitsToSell;
        }

        ///
        /// display inventory
        /// 
        public void DisplayInventory(Product product)
        {
            ConsoleUtil.HeaderText = "Current Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Product type: " + product.Type.ToString());
            ConsoleUtil.DisplayMessage("Number of units: " + product.NumberOfUnits.ToString());
            ConsoleUtil.DisplayMessage("");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// uppercase first
        /// changes string to lowercase with first letter uppercase
        /// adapted from: https://www.dotnetperls.com/uppercase-first-letter
        /// <summary>
        /// <param name="s"></param>
        /// <return></return>
        static string UppercaseFirst(string s)
        {
            // check for empty string
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            //Return char and concatenation substring.
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "Mrs. D's Productions";
            ConsoleUtil.HeaderText = "The Sales Tracker Application";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            ConsoleUtil.DisplayMessage("");

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Thank you for using the application. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }


        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Written by Drea Weiner");
            ConsoleUtil.DisplayMessage("Northwestern Michigan College");
            ConsoleUtil.DisplayMessage("");

            sb.Clear();
            sb.AppendFormat("You are a salesperson buying and selling high end STEM educational tools ");
            sb.AppendFormat("around the country. You will be prompted regarding which city ");
            sb.AppendFormat("you wish to travel to and will then be asked whether you wish to buy ");
            sb.AppendFormat("or sell widgets.");
            ConsoleUtil.DisplayMessage(sb.ToString());
            ConsoleUtil.DisplayMessage("");

            sb.Clear();
            sb.AppendFormat("Your first task will be to set up your account details.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new salesperson object with the initial data
        /// </summary>
        public Salesperson DisplaySetupAccount()
        {
            Salesperson salesperson = new Salesperson();

            ConsoleUtil.HeaderText = "Account Setup";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Setup your account now.");
            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayPromptMessage("Enter your first name: ");
            salesperson.FirstName = Console.ReadLine();
            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayPromptMessage("Enter your last name: ");
            salesperson.LastName = Console.ReadLine();
            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayPromptMessage("Enter your account ID: ");
            salesperson.AccountID = Console.ReadLine();
            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayMessage("Product Types");
            ConsoleUtil.DisplayMessage("");

            //
            // list all product types
            //
            foreach (string productTypeName in Enum.GetNames(typeof(Product.ProductType)))
            {
                //
                // do not display the "NONE" enum value
                //
                if (productTypeName != Product.ProductType.None.ToString())
                {
                    ConsoleUtil.DisplayMessage(productTypeName);
                }
            }

            //
            // get product type, if invalid entry, set type to "None"
            //
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayPromptMessage("Enter the product type: ");
            Product.ProductType productType;
            if (Enum.TryParse<Product.ProductType>(UppercaseFirst(Console.ReadLine()), out productType))
            {
                salesperson.CurrentStock.Type = productType;
            }
            else
            {
                salesperson.CurrentStock.Type = Product.ProductType.None;
            }

            //
            // get number of products in inventory
            //
            if (ConsoleValidator.TryGetIntegerFromUser(0, 100, 3, "products", out int numberOfUnits))
            {
                salesperson.CurrentStock.AddProducts(numberOfUnits);
            }
            else
            {
                ConsoleUtil.DisplayMessage("It appears you are having difficulty setting the number of products in your stock.");
                ConsoleUtil.DisplayMessage("By default, the number of products in your inventory are now set to zero.");
                salesperson.CurrentStock.AddProducts(0);
                DisplayContinuePrompt();
            }

            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Your account is setup");

            DisplayContinuePrompt();

            return salesperson;
        }

        ///<summary>
        /// display update account info
        /// </summary>
        public Salesperson DisplayUpdateAccountInfo(Salesperson salesperson)
        {
            string userResponse;

            //Salesperson salesperson = new Salesperson();

            ConsoleUtil.HeaderText = "Update Account Setup";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Change your account now.");
            ConsoleUtil.DisplayMessage("");

            //
            // edit first name
            //
            ConsoleUtil.DisplayPromptMessage("Would you like to change your first name?");
            userResponse = Console.ReadLine().ToUpper();
            if (userResponse != "NO")
            {
                ConsoleUtil.DisplayPromptMessage("Enter your first name: ");
                salesperson.FirstName = Console.ReadLine();
                ConsoleUtil.DisplayPromptMessage("Press any key to continue.");
                Console.ReadKey();
            
            }
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Press another key to continue");

            //
            // edit last name
            //
            ConsoleUtil.DisplayPromptMessage("Would you like to change your last name?");
            userResponse = Console.ReadLine().ToUpper();
            if (userResponse != "NO")
            {
                ConsoleUtil.DisplayPromptMessage("Enter your last name: ");
                salesperson.LastName = Console.ReadLine();
                ConsoleUtil.DisplayPromptMessage("Press any key to continue.");
                Console.ReadKey();
            }
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Press another key to continue");

            //
            // edit account ID
            //
            ConsoleUtil.DisplayPromptMessage("Would you like to change your account ID?");
            userResponse = Console.ReadLine().ToUpper();
            if (userResponse != "NO")
            {
                ConsoleUtil.DisplayPromptMessage("Enter your account ID: ");
                salesperson.AccountID = Console.ReadLine();
                ConsoleUtil.DisplayPromptMessage("Press any key to continue.");
                Console.ReadKey();
            }
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Press another key to continue");

            //
            // edit products
            //
            ConsoleUtil.DisplayMessage("Would you like to change what product type your selling?");
            userResponse = Console.ReadLine().ToUpper();
            if (userResponse != "NO")
            {
                ConsoleUtil.DisplayMessage("Product Types");
                ConsoleUtil.DisplayMessage("");

                //
                // list all product types
                //
                foreach (string productTypeName in Enum.GetNames(typeof(Product.ProductType)))
                {
                    //
                    // do not display the "NONE" enum value
                    //
                    if (productTypeName != Product.ProductType.None.ToString())
                    {
                        ConsoleUtil.DisplayMessage(productTypeName);
                    }
                }

                //
                // get product type, if invalid entry, set type to "None"
                //
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayPromptMessage("Enter the product type: ");
                Product.ProductType productType;
                if (Enum.TryParse<Product.ProductType>(UppercaseFirst(Console.ReadLine()), out productType))
                {
                    salesperson.CurrentStock.Type = productType;
                }
                else
                {
                    salesperson.CurrentStock.Type = Product.ProductType.None;
                }
            }

            //
            // edit inventory
            //
            ConsoleUtil.DisplayMessage("Would you like to edit your inventory?");
            userResponse = Console.ReadLine().ToUpper();
            if (userResponse != "NO")
            {
                if (ConsoleValidator.TryGetIntegerFromUser(0, 100, 3, "products", out int numberOfUnits))
                {
                    salesperson.CurrentStock.AddProducts(numberOfUnits);
                }
                else
                {
                    ConsoleUtil.DisplayMessage("It appears you are having difficulty setting the number of products in your stock.");
                    ConsoleUtil.DisplayMessage("By default, the number of products in your inventory are now set to zero.");
                    salesperson.CurrentStock.AddProducts(0);
                    DisplayContinuePrompt();
                }
            }

            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Your account is updated.");

            DisplayContinuePrompt();

            return salesperson;
        }

        /// <summary>
        /// save account information to file
        /// </summary>
        /// <param name="salesperson">Salesperson object</param>
        /// <param name="maxAttemptsExceeded">maximum attempts exceeded flag</param>
        /// <returns></returns>
        public bool DisplaySaveAccountInfo(Salesperson salesperson, out bool maxAttemptsExceeded)
        {
            string userResponse;
            maxAttemptsExceeded = false;

            ConsoleUtil.HeaderText = "Save Account";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("The current account information.");
            DisplayAccountInfo(salesperson);

            ConsoleUtil.DisplayMessage("");
            userResponse = ConsoleValidator.GetYesNoFromUser(MAXIMUM_ATTEMPTS, "Save the account information?", out maxAttemptsExceeded);

            if (maxAttemptsExceeded)
            {
                ConsoleUtil.DisplayMessage("It appears you are having difficulty. You will return to the main menu.");
                return false;
            }
            else
            {
                //
                // note use of ternary operator
                //
                return userResponse == "YES" ? true : false;
            }
        }

        /// <summary>
        /// load account information
        /// </summary>
        /// <param name="salesperson">Salesperson object</param>
        /// <param name="maxAttemptsExceeded">maximum attempts exceeded flag</param>
        /// <returns>user choice</returns>
        public bool DisplayLoadAccountInfo(out bool maxAttemptsExceeded)
        {
            string userResponse;
            maxAttemptsExceeded = false;

            ConsoleUtil.HeaderText = "Load Account";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            userResponse = ConsoleValidator.GetYesNoFromUser(MAXIMUM_ATTEMPTS, "Load the account information?", out maxAttemptsExceeded);

            if (maxAttemptsExceeded)
            {
                ConsoleUtil.DisplayMessage("It appears you are having difficulty. You will return to the main menu.");
                return false;
            }
            else
            {
                //
                // note use of ternary operator
                //
                return userResponse == "YES" ? true : false;
            }
        }

        /// <summary>
        /// displays a confirmation of account as saved
        /// </summary>
        public void DisplayConfirmSaveAccountInfo()
        {
            ConsoleUtil.HeaderText = "Save Account";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Account information saved.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a closing screen when the user quits the application
        /// </summary>
        public void DisplayClosingScreen()
        {
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Thank you for using The Sales Tracker Application.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the menu choice from the user
        /// </summary>
        public MenuOption DisplayGetUserMenuChoice()
        {
            ConsoleUtil.HeaderText = "Menu";
            ConsoleUtil.DisplayReset();

            MenuOption userMenuChoice = MenuOption.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("Please type the number of your menu choice.");
                ConsoleUtil.DisplayMessage("");
                Console.Write(
                    "\t" + "1. Update Account Information" + Environment.NewLine +
                    "\t" + "2. Travel" + Environment.NewLine +
                    "\t" + "3. Buy" + Environment.NewLine +
                    "\t" + "4. Sell" + Environment.NewLine +
                    "\t" + "5. Display Inventory" + Environment.NewLine +
                    "\t" + "6. Display Cities" + Environment.NewLine +
                    "\t" + "7. Display Account Info" + Environment.NewLine +
                    "\t" + "8. Save Account Info" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        userMenuChoice = MenuOption.AccountEdit;
                        usingMenu = false;
                        break;
                    case '2':
                        userMenuChoice = MenuOption.Travel;
                        usingMenu = false;
                        break;
                    case '3':
                        userMenuChoice = MenuOption.Buy;
                        usingMenu = false;
                        break;
                    case '4':
                        userMenuChoice = MenuOption.Sell;
                        usingMenu = false;
                        break;
                    case '5':
                        userMenuChoice = MenuOption.DisplayInventory;
                        usingMenu = false;
                        break;
                    case '6':
                        userMenuChoice = MenuOption.DisplayCities;
                        usingMenu = false;
                        break;
                    case '7':
                        userMenuChoice = MenuOption.DisplayAccountInfo;
                        usingMenu = false;
                        break;
                    case '8':
                        userMenuChoice = MenuOption.DisplaySaveAccountInfo;
                        usingMenu = false;
                        break;
                    case '9':
                        userMenuChoice = MenuOption.DisplayLoadAccountInfo;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        userMenuChoice = MenuOption.Exit;
                        usingMenu = false;
                        break;
                    default:
                        ConsoleUtil.DisplayMessage(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to quit the application.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;

            return userMenuChoice;
        }

        /// <summary>
        /// get the next city to travel to from the user
        /// </summary>
        /// <returns>string City</returns>
        public string DisplayGetNextCity()
        {
            string nextCity = "";

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Enter the name of the next city:");
            nextCity = Console.ReadLine();

            return nextCity;
        }

        /// <summary>
        /// display a list of the cities traveled
        /// </summary>
        public void DisplayCitiesTraveled(Salesperson salesperson)
        {
            ConsoleUtil.HeaderText = "Cities Traveled";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("You have traveled to the following cities.");
            ConsoleUtil.DisplayMessage("");

            foreach (string city in salesperson.CitiesVisited)
            {
                ConsoleUtil.DisplayMessage(city);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current account information
        /// </summary>
        public void DisplayAccountInfo(Salesperson salesperson)
        {
            ConsoleUtil.HeaderText = "Account Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("First Name: " + salesperson.FirstName);
            ConsoleUtil.DisplayMessage("Last Name: " + salesperson.LastName);
            ConsoleUtil.DisplayMessage("Account ID: " + salesperson.AccountID);
            ConsoleUtil.DisplayMessage("Product Type: " + salesperson.CurrentStock.Type);
            if (!salesperson.CurrentStock.OnBackorder)
            {
                ConsoleUtil.DisplayMessage("Units of Products in Inventory: " + salesperson.CurrentStock.NumberOfUnits);
            }
            else
            {
                ConsoleUtil.DisplayMessage("Units of Products on Backorder: " + Math.Abs(salesperson.CurrentStock.NumberOfUnits));
            }

            DisplayContinuePrompt();
        }

        #endregion
    }
}
