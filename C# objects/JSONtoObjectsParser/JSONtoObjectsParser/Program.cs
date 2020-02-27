using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WaponJSONParser;

namespace JSONtoObjectsParser
{
    class Program
    {
        private const string WEAPON_INFO_PATH = "weaponinfo.cdb.json";
        private const string ITEM_WEAPON_INFO_PATH = "itemweaponsinfo.cdb.json";
        static void Main(string[] args)
        {
            Console.WriteLine("!!! Debugger looks for the files in: " + Environment.CurrentDirectory);
            List<PrimitiveWeapon> weapons = new JSONToCSharpParser<PrimitiveWeapon>().parse(WEAPON_INFO_PATH);
            List<PrimitiveIteamWeaponInfo> weaponInfos = new JSONToCSharpParser<PrimitiveIteamWeaponInfo>().parse(ITEM_WEAPON_INFO_PATH);
            weapons = weapons.FindAll(w => lastTwoDigitsAreGood(w.wi_id));
            weaponInfos = weaponInfos.FindAll(info => lastTwoDigitsAreGood(info.ii_weaponinfo));
            List<int> missingIDS = new List<int>();
            var outPath = Environment.CurrentDirectory + "weapons.res";
            using (var writer = new StreamWriter(outPath))
            {
                foreach (PrimitiveWeapon w in weapons)
                {
                    bool found = false;
                    foreach (PrimitiveIteamWeaponInfo info in weaponInfos)
                    {
                        if (info.ii_weaponinfo == w.wi_id)
                        {
                            string msg = "id : " + w.wi_id + " | name: " + info.ii_name + " | Type " + w.wi_weapon_type.ToString();
                            writer.WriteLine(msg);
                            Console.WriteLine(msg);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        missingIDS.Add(w.wi_id);
                        string errorMsg = "Couldn't find match for id: " + w.wi_id;
                        Console.WriteLine(errorMsg);
                        writer.WriteLine(errorMsg);
                    }
                }
            }
            Console.WriteLine("File in: " + Environment.CurrentDirectory);
           

        }

        public static bool lastTwoDigitsAreGood(int id)
        {
            int[] digits = new int[7];
            int pos = 0;
            while (id > 0)
            {                               
                digits[pos] = id % 10;           
                id /= 10;
                pos++;
            }
            Array.Reverse(digits);
            return digits[5] == 0 && digits[6] == 0;
        }

       

     
    }
}
