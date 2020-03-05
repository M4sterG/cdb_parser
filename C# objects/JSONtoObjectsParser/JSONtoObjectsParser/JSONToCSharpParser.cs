using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WaponJSONParser;

namespace JSONtoObjectsParser
{
    public class JSONToCSharpParser<T>
    {
        private string fixJson(string json)
        {
            return " [ " + json + " ] ";
        }

        public List<T> parse(string path)
        {
            return loadItems(path);
        }

        private List<T> loadItems(string path)
        {


            List<T> objects;
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    json = fixJson(json);
                    //Console.Write(json);
                    objects = JsonConvert.DeserializeObject<List<T>>(json);
                    Console.WriteLine("Found the file and converted the objects");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found");
                Console.WriteLine(e.Message);
                objects = new List<T>();
            }
            catch (Newtonsoft.Json.JsonSerializationException e)
            {
                Console.WriteLine("Error while parsin the JSON file");
                Console.WriteLine(e.Message);
                objects = new List<T>();
            }
            return objects;
        }
    }
}
