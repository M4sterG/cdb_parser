using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public class Shotgun : Gun
    {   
        public SwapSpeed SwapSpeed { get; set; }
        public Shotgun()
        {
            WeaponType = WeaponType.Shotgun;
        }
        public Shotgun(int power, int firingRate, int accuracy, int reloadSpeed) : this()
        {
            Power = power;  // ability_a in cgd
            FiringRate = firingRate; // ability_b in cgd
            Accuracy = accuracy;    // ability_c in cgd
            ReloadSpeed = reloadSpeed; // ability_d in cgd
        }
        public new string ToUniquePropertyList()
        {
            return "swap_speed";
        }
        public new string ToSQLQuery()
        {
            return "INSERT IGNORE INTO shotgun_base_stats (id, " + ToUniquePropertyList() + ") VALUES (" +
                Id + "," +
                "'" + SwapSpeed.ToString() + "');";
        }
    }
}
