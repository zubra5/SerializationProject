using System;
using System.Xml.Serialization;

namespace CarSerializable
{
    [Serializable]
    public class Car
    {
        public Radio theRadio= new Radio();
        public bool isHatchBack;
    }

    [Serializable]
    [XmlRoot(Namespace = "http://blabla.site")]
    public class JamesBondClass : Car
    {
        [XmlAttribute]
        public bool canFly;

        [XmlAttribute]
        public bool canSubmerge;
    }
}
