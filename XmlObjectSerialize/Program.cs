using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace XmlObjectSerialize
{
    [DataContract]
    public class Company
    {
        [DataMember]
        public string Name;
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting");
                Program p= new Program();
                p.Run();
                Console.WriteLine("Done");
                Console.ReadLine();
            }
            catch (InvalidDataContractException e)
            {
                Console.WriteLine("You have an invalid data contract: ");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            catch (SerializationException e)
            {
                Console.WriteLine("There is a problem with the instance:");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private void WriteObjectWithInstance(XmlObjectSerializer xm, Company graph, string fileName)
        {
            Console.WriteLine(xm.GetType());
            FileStream fs=  new FileStream(fileName, FileMode.Create);
            XmlDictionaryWriter writer= XmlDictionaryWriter.CreateTextWriter(fs);
            xm.WriteObject(writer,graph);
            Console.WriteLine("Done writing {0}", fileName);
        }

        private void Run()
        {
            Company graph= new Company();
            graph.Name = "Apple";
            string filePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            DataContractSerializer dcs= new DataContractSerializer(typeof(Company));
            NetDataContractSerializer ndcs= new NetDataContractSerializer();
            WriteObjectWithInstance(dcs, graph, filePath+"\\datacontract.xml");
            WriteObjectWithInstance(ndcs, graph, filePath+"\\netDatacontract.xml");
        }


    }
}
