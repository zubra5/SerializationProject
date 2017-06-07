using System;


namespace CarSerializable
{
    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;
        [NonSerialized] public string radioID = "XF-552RF6";
    }
}
