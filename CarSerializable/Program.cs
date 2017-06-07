using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;


namespace CarSerializable
{
    class Program
    {
        private static void Main(string[] args)
        {
            string filePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

            JamesBondClass jbc = new JamesBondClass();

            jbc.canFly = true;
            jbc.canSubmerge = false;
            jbc.theRadio.stationPresets = new double[] { 89.3, 105.1, 97.1 };
            jbc.theRadio.hasTweeters = true;

            string binaryFileName = filePath + "\\carBinaryData.dat";

            SaveBinaryFormat(jbc, binaryFileName);

            LoadFromBinaryFile(binaryFileName);


            string soapFileName = filePath + "\\carSoapData.dat";

            SoapWriteFile(jbc, soapFileName);

            string xmlFileName = filePath + "\\carXmlData.dat";

            SaveInXmlFormat(jbc, xmlFileName);

            Console.ReadLine();
        }

        private static void SaveBinaryFormat(object objGraph, string fileName)
        {
            BinaryFormatter binFormat= new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("--> Saving of object JamesBondClass on Binary format");
        }
       

        private static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat= new BinaryFormatter();

            Console.WriteLine("Retrieving of object from a local file...");

            using (Stream fStream = File.OpenRead(fileName))
            {
                JamesBondClass carFromDisk = (JamesBondClass) binFormat.Deserialize(fStream);
                Console.WriteLine(carFromDisk.canFly);
            }

            Console.WriteLine(new string('_', 40));
        }

        private static void SoapWriteFile(object objGraph, string fileName)
        {
            SoapFormatter soapFormatter=new SoapFormatter();
            using (Stream fStream=new FileStream(fileName,FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormatter.Serialize(fStream, objGraph);
            }

            Console.WriteLine("--> Saving of object JamesBondClass on Soap format");
        }

        private static void SaveInXmlFormat(object objGraph, string fileName)
        {
            XmlSerializer xmlFormat= new XmlSerializer(typeof(JamesBondClass), new Type[]{typeof(Radio), typeof(Car)});

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }

            Console.WriteLine("--> Saving of object JamesBondClass on Xml format");
        }
    }
}
