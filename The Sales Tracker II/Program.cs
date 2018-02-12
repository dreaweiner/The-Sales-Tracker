using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Sales_Tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // seed data file
            //
            InitializeDataFileCsv dataInitializerCsv = new InitializeDataFileCsv();
            dataInitializerCsv.SeedDataFile();
            InitializeDataFileXml dataInitializerXml = new InitializeDataFileXml();
            dataInitializerXml.SeedDataFile();

            Controller appController = new Controller();
        }
    }
}
