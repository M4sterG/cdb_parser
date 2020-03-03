using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WaponJSONParser;

namespace JSONtoObjectsParser
{
    internal class Program
    {
        private const string WEAPON_INFO_PATH = "MV/weaponinfo.json";
        private const string ITEM_WEAPON_INFO_PATH = "MV/itemweaponsinfo.json";
        private const string WEAPON_INFO_PATH_TW = "TW/weaponinfo.json";
        private const string ITEM_WEAPON_INFO_PATH_TW = "TW/itemweaponsinfo.json";

        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("!!! Debugger looks for the files in: " + Environment.CurrentDirectory);
            List<PrimitiveWeapon> weapons_mv = new JSONToCSharpParser<PrimitiveWeapon>().parse(WEAPON_INFO_PATH);
            List<PrimitiveIteamWeaponInfo> weaponInfos_mv = new JSONToCSharpParser<PrimitiveIteamWeaponInfo>().parse(ITEM_WEAPON_INFO_PATH);

            List<PrimitiveWeapon> weapons_tw = new JSONToCSharpParser<PrimitiveWeapon>().parse(WEAPON_INFO_PATH_TW);
            List<PrimitiveIteamWeaponInfo> weaponInfos_tw = new JSONToCSharpParser<PrimitiveIteamWeaponInfo>().parse(ITEM_WEAPON_INFO_PATH_TW);

            weapons_mv = weapons_mv.FindAll(w_mv => lastTwoDigitsAreGood(w_mv.wi_id));
            weaponInfos_mv = weaponInfos_mv.FindAll(info_mv => lastTwoDigitsAreGood(info_mv.ii_weaponinfo));

            weapons_tw = weapons_tw.FindAll(w_tw => lastTwoDigitsAreGood(w_tw.wi_id));
            weaponInfos_tw = weaponInfos_tw.FindAll(info_tw => lastTwoDigitsAreGood(info_tw.ii_weaponinfo));

            List<int> missingIDS = new List<int>();

            var outPath = Environment.CurrentDirectory + "weapons.res";
            List<Weapon> weapons = new List<Weapon>();

            using (var writer = new StreamWriter(outPath))
            {
                foreach (PrimitiveWeapon w_mv in weapons_mv)
                {
                    bool found = false;
                    foreach (PrimitiveIteamWeaponInfo info_mv in weaponInfos_mv)
                    {
                        if (info_mv.ii_weaponinfo == w_mv.wi_id)
                        {
                            weapons.Add(getActualWeapon(w_mv, info_mv));
                            string msg = "id : " + w_mv.wi_id + " | name: " + info_mv.ii_name + " | Type " + w_mv.wi_weapon_type.ToString();
                            writer.WriteLine(msg);
                            Console.WriteLine(msg);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        missingIDS.Add(w_mv.wi_id);
                        string errorMsg = "Couldn't find match for id: " + w_mv.wi_id;
                        Console.WriteLine(errorMsg);
                        writer.WriteLine(errorMsg);
                    }
                }

                int missing = missingIDS.Count;
                Console.WriteLine(missing + " items are missing in database");

                foreach (PrimitiveWeapon w_tw in weapons_tw)
                {
                    foreach (PrimitiveIteamWeaponInfo info_tw in weaponInfos_tw)
                    {
                        if (missingIDS.Contains(w_tw.wi_id))
                        {

                            missingIDS.Remove(w_tw.wi_id);
                            weapons.Add(getActualWeapon(w_tw, info_tw));
                            String msg = "id : " + w_tw.wi_id + " | name: " + info_tw.ii_name + " | Type " + w_tw.wi_weapon_type.ToString();
                            Console.WriteLine("Found in TW :" + msg);
                            writer.WriteLine(msg);
                        }
                    }
                }
                Console.WriteLine("Still " + missingIDS.Count + " items are missing in database");
            }
            Console.WriteLine("File in: " + Environment.CurrentDirectory);
        }
        
        public static Weapon getActualWeapon(PrimitiveWeapon primWep, PrimitiveIteamWeaponInfo info)
        {
            switch (primWep.wi_weapon_type) {
                case WeaponType.Melee:
                    return handleMeleeCase(primWep, info);
                case WeaponType.Rifle:
                    return handleCaseRifle(primWep, info);
                default:
                    return new Weapon(primWep.wi_id, primWep.wi_weapon_type, info.ii_desc, info.ii_name);
            }
            return null;

        }

        private static Weapon handleCaseRifle(PrimitiveWeapon primWep, PrimitiveIteamWeaponInfo info)
        {
            Weapon wep = new Rifle(primWep.wi_ability_a, primWep.wi_ability_b,
                                         primWep.wi_ability_c, primWep.wi_ability_d);
            setStats(wep, primWep, info);
            return wep;
        }

        private static void setStats(Weapon wep, PrimitiveWeapon primWep, PrimitiveIteamWeaponInfo info)
        {
            wep.Id = primWep.wi_id;
            wep.Description = info.ii_desc;
            wep.Name = info.ii_name;
            wep.MeshPath = info.ii_meshfilename;
        }

        private static Weapon handleMeleeCase(PrimitiveWeapon primWep, PrimitiveIteamWeaponInfo info)
        {
            Weapon wep = new Melee(primWep.wi_ability_a, primWep.wi_ability_b,
                                         primWep.wi_ability_c, primWep.wi_ability_d);
            setStats(wep, primWep, info);
            return wep;
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