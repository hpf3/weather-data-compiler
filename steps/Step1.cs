using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace weather_data_compiler.steps
{
    public static class Step1
    {
        public static void Start()
        {
            List<Data.ShrunkData> datas = new List<Data.ShrunkData>();
            foreach (Data.current_observation item in filter(Read()))
            {
                datas.Add(new Data.ShrunkData(item.location, item.station_id, item.temp_c, item.latitude, item.longitude,item.observation_time.Remove(0,16)));
            }
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Data.ShrunkData>));
            StreamWriter writer = new StreamWriter(MainWindow.stationFile);
            serializer.Serialize(writer, datas);
            writer.Close();
        }

        private static List<Data.current_observation> filter(List<Data.current_observation> raw)
        {
            List<Data.current_observation> filtered = new List<Data.current_observation>();
            foreach (Data.current_observation item in raw)
            {
                if (!(item.location == "Unknown Station") && item.temp_c != null)
                {
                    filtered.Add(item);
                }
            }
            return filtered;
        }

        private static List<Data.current_observation> Read()
        {
            string folder = MainWindow.folderPath;
            List<Data.current_observation> observations = new List<Data.current_observation>();
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Data.current_observation));
            string[] vs = System.IO.Directory.GetFiles(folder);
            for (int i = 0; i < vs.Length; i++)
            {

                System.IO.TextReader reader = System.IO.File.OpenText(vs[i]);
                Data.current_observation observation = (Data.current_observation)serializer.Deserialize(reader);
                observations.Add(observation);
                reader.Close();
            }
            return observations;
        }
    }
}
