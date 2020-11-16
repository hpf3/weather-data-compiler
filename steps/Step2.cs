using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace weather_data_compiler.steps
{
    public static class Step2
    {

        public static void Run()
        {
            
            List<Data.city> cities = CitiesGet();
            List<Data.WeatherData> weatherDatas = new List<Data.WeatherData>();
            foreach (Data.ShrunkData item in StationsGet())
            {
                Data.city closest = GetCity(double.Parse(item.Latitude),double.Parse(item.Longitude),cities);
                weatherDatas.Add(new Data.WeatherData() { city = closest.Name, Date = item.DateTime, TemperatureC = double.Parse(item.Temperature) });
            }
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Data.WeatherData>));
            StreamWriter writer = new StreamWriter(MainWindow.endFile);
            serializer.Serialize(writer, weatherDatas);
            writer.Close();
        }
        private static List<Data.city> CitiesGet()
        {
            List<Data.city> cities = new List<Data.city>();
            StreamReader reader = new StreamReader(MainWindow.cityFile);
            while (!reader.EndOfStream)
            {
                //city,state_id,county_name,lat,lng
                string[] items = reader.ReadLine().Split(',');
                cities.Add(new Data.city() { Name = items[0], State = items[1], county = items[2], Lattitude =double.Parse(items[3]), Longitude =double.Parse(items[4]) });
            }
            return cities;
        }
        private static List<Data.ShrunkData> StationsGet()
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Data.ShrunkData>));
                TextReader reader = File.OpenText(MainWindow.stationFile);
                List<Data.ShrunkData> observation = (List<Data.ShrunkData>)serializer.Deserialize(reader);
                reader.Close();
            
            return observation;
        }

        private static Data.city GetCity(double lat, double lon, List<Data.city> Cities)
        {
            Data.city closest = null;
            double closestDistance = 99999999999.9;
            foreach (Data.city item in Cities)
            {
                double distance = Haversine(lat, item.Lattitude, lon, item.Longitude);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = item;
                }
            }
            return closest;
        }
        private static double Haversine(double lat1, double lat2, double lon1, double lon2)
        {
            const double r = 6371; // meters

            var sdlat = Math.Sin((lat2 - lat1) / 2);
            var sdlon = Math.Sin((lon2 - lon1) / 2);
            var q = sdlat * sdlat + Math.Cos(lat1) * Math.Cos(lat2) * sdlon * sdlon;
            var d = 2 * r * Math.Asin(Math.Sqrt(q));

            return d;
        }
    }
}
