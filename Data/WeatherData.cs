using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace weather_data_compiler.Data
{
    public class WeatherData
    {
        [XmlElement(ElementName = "City")]
        public string city;
        [XmlElement(ElementName = "DateTime")]
        public string Date;
        [XmlElement(ElementName = "Temperature_C")]
        public double TemperatureC;
    }
}
