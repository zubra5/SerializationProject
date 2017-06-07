using System;


namespace SerializationProject
{
    [Serializable]
    public class Person
    {
        public bool isAlive = true;
        private int personAge = 21;

        private string fName = string.Empty;

        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
    }
}
