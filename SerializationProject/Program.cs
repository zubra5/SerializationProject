using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SerializationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            UserPrefsSave();
        }

        private static void UserPrefsSave()
        {
            UserPrefs userData= new UserPrefs();

            userData.WindowColor = "Yellow";
            userData.FonrSize = 50;

            string filePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            filePath = filePath + "\\user.dat";

            BinaryFormatter binFormat = new BinaryFormatter();

            Console.WriteLine("Saving of object into a local file...");
            Console.WriteLine(new string('_',40));

            using (Stream fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, userData);
            }

            Console.ReadLine();
        }
    }
}
