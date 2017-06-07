using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace JsonSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string jsonFileName = filePath + "\\people.json";

            JsonWriteIntoFile(jsonFileName);

            JsonReadFromFile(jsonFileName);

            Console.ReadLine();
        }

        private static void JsonWriteIntoFile(string fileName)
        {
            // объект для сериализации
            Person person1 = new Person("Tom", 29);
            Person person2 = new Person("Bill", 25);
            Person[] people = new Person[] { person1, person2 };

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer jDataContract = new DataContractJsonSerializer(typeof(Person[]));
                jDataContract.WriteObject(fs,people);
            }
            Console.WriteLine("Json was written into the file");
            Console.WriteLine(new string('+',40));
        }

        private static void JsonReadFromFile(string fileName)
        {

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer jDataContract = new DataContractJsonSerializer(typeof(Person[]));
                Person[]  newpeople = (Person[])jDataContract.ReadObject(fs);

                foreach (Person p in newpeople)
                {
                    Console.WriteLine("Name: {0} --- Age: {1}", p.Name, p.Age);
                }
            }

            Console.WriteLine("Json was read from the file");
            Console.WriteLine(new string('*', 40));
        }

    }
}
