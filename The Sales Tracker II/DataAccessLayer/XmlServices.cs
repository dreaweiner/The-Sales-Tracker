using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace The_Sales_Tracker
{
    public class XmlServices
    {
        private string _dataFilePath;

        public XmlServices(string dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }

        public Salesperson ReadSalespersonFromDataFile()
        {
            Salesperson salesperson = new Salesperson();

            // initialize a FileStream object for reading
            StreamReader sReader = new StreamReader(_dataFilePath);

            // initialize an XML seriailizer object
            XmlSerializer deserializer = new XmlSerializer(typeof(Salesperson));

            using (sReader)
            {
                object xmlObject = deserializer.Deserialize(sReader);
                Console.WriteLine(xmlObject);
                salesperson = (Salesperson)xmlObject;
            }

            return salesperson;
        }

        public void WriteSalespersonToDataFile(Salesperson salesperson)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Salesperson), new XmlRootAttribute("Salesperson"));

            StreamWriter sWriter = new StreamWriter(_dataFilePath);

            using (sWriter)
            {
                serializer.Serialize(sWriter, salesperson);
            }
        }
    }
}
