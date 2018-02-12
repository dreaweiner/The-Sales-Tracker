using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sales_Tracker;
using System.Xml.Serialization;

namespace The_Sales_Tracker
{
    public class CsvServices
    {
        private string _dataFilePath;

        public CsvServices(string dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }

        public Salesperson ReadSalespersonFromDataFile()
        {
            Salesperson salesperson = new Salesperson();
            string salespersonInfo;
            string[] salespersonInfoArray;
            string citiesTraveled;

            // initialize a FileStream object for writing
            FileStream rfileStream = File.OpenRead(DataSettings.dataFilePathCsv);

            // wrap the FieldStream object in a using statement to ensure of the dispose
            using (rfileStream)
            {
                // wrap the FileStream object in a StreamWriter object to simplify writing strings
                StreamReader sReader = new StreamReader(rfileStream);

                using (sReader)
                {
                    salespersonInfo = sReader.ReadLine();
                    citiesTraveled = sReader.ReadLine();
                }
            }

            //
            // convert and write data to salesperson object
            //
            salespersonInfoArray = salespersonInfo.Split(',');
            salesperson.FirstName = salespersonInfoArray[0];
            salesperson.LastName = salespersonInfoArray[1];
            salesperson.AccountID = salespersonInfoArray[2];

            if (!Enum.TryParse<Product.ProductType>(salespersonInfoArray[3], out Product.ProductType productType))
            {
                productType = Product.ProductType.None;
            }
            salesperson.CurrentStock.Type = productType;

            salesperson.CurrentStock.AddProducts(Convert.ToInt32(salespersonInfoArray[4]));
            salesperson.CurrentStock.OnBackorder = Convert.ToBoolean(salespersonInfoArray[5]);

            salesperson.CitiesVisited = citiesTraveled.Split(',').ToList();

            return salesperson;
        }

        public void WriteSalespersonToDataFile(Salesperson salesperson)
        {
            string salespersonData;
            char delineator = ',';

            StringBuilder sb = new StringBuilder();

            //
            // add salesperson and product info to string
            //
            sb.Clear();
            sb.Append(salesperson.FirstName + delineator);
            sb.Append(salesperson.LastName + delineator);
            sb.Append(salesperson.AccountID + delineator);
            sb.Append(salesperson.CurrentStock.Type.ToString() + delineator);
            sb.Append(salesperson.CurrentStock.NumberOfUnits.ToString() + delineator);
            sb.Append(salesperson.CurrentStock.OnBackorder.ToString());
            sb.Append(Environment.NewLine);

            //
            // add cities traveled to the string
            //
            foreach (string city in salesperson.CitiesVisited)
            {
                sb.Append(city + delineator);
            }

            //
            // remove the last delineator
            //
            if (sb.Length != 0)
            {
                sb.Length--;
            }

            //
            // convert StringBuilder object to a string
            //
            salespersonData = sb.ToString();

            // initialize a FileStream object for writing
            FileStream wfileStream = File.OpenWrite(DataSettings.dataFilePathCsv);

            // wrap the FieldStream object in a using statement to ensure of the dispose
            using (wfileStream)
            {
                // wrap the FileStream object in a StreamWriter object to simplify writing strings
                StreamWriter sWriter = new StreamWriter(wfileStream);

                using (sWriter)
                {
                    sWriter.Write(salespersonData);
                }
            }
        }
    }
}
