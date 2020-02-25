using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WaponJSONParser;

namespace JSONtoObjectsParser
{
    class Program
    {
        private const string ITEMS_PATH = "weaponinfo.cdb.json";
        static void Main(string[] args)
        {
            List<PrimitiveWeapon> weps = loadItems(ITEMS_PATH);
        }

        private static string fixJson(String json)
        {
            return " [ " + json + " ] ";
        }

        private static List<PrimitiveWeapon> loadItems(string path)
        {


            List<PrimitiveWeapon> weps;
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    json = fixJson(json);
                    //Console.Write(json);
                    weps = JsonConvert.DeserializeObject<List<PrimitiveWeapon>>(json);
                    Console.WriteLine("Found the file and converted the objects");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found");
                Console.WriteLine(e.Message);
                weps = new List<PrimitiveWeapon>();
            }
            catch (Newtonsoft.Json.JsonSerializationException e)
            {
                Console.WriteLine("Error while parsin the JSON file");
                Console.WriteLine(e.Message);
                weps = new List<PrimitiveWeapon>();
            }
            return weps;
        }
    }
}
