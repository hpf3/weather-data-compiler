using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace weather_data_compiler.Data
{
    public class ShrunkData
    {
        [XmlElement(ElementName = "Location")]
        public string Location;
        [XmlElement(ElementName = "Station")]
        public string Station;
        [XmlElement(ElementName = "Temperature")]
        public string Temperature;
        [XmlElement(ElementName = "Latitude")]
        public string Latitude;
        [XmlElement(ElementName = "Longitude")]
        public string Longitude;
        [XmlElement(ElementName = "DateTime")]
        public string DateTime;

        public ShrunkData(string location, string station, string temperature, string latitude, string longitude,string dateTime)
        {
            Location = location;
            Station = station;
            Temperature = temperature;
            Latitude = latitude;
            Longitude = longitude;
            DateTime = dateTime;
        }
        public ShrunkData()
        {

        }
    }
}
