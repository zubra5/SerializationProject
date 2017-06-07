using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerialize
{
    [DataContract]
    public class Person
    {
        [DataMember(Order=1, Name="LastName")]
        public string Name { get; set; }

        [DataMember(Order = 10)]
        public int Age { get; set; }

        public Person(string name, int year)
        {
            Name = name;
            Age = year;
        }
    }
}
