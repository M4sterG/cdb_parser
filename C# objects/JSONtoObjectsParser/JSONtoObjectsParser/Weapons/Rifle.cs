using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public class Rifle : Gun
    {
        public Rifle() 
        {
            WeaponType = WeaponType.Rifle;
        }
        public Rifle(int power, int firingRate, int accuracy, int reloadSpeed) : this()
        {
            Power = power;  // ability_c in cgd  
            FiringRate = firingRate;    // ability_b in cgd  
            Accuracy = accuracy;    // ability_c in cgd  
            ReloadSpeed = reloadSpeed;// ability_d in cgd  
        }
        public new string ToUniquePropertyList()
        {
            return "accuracy";
        }
        public new string ToSQLQuery()
        {
            return "INSERT IGNORE INTO rifle_base_stats (id, " + ToUniquePropertyList() + ") VALUES (" +
                Id + "," +
               Accuracy + ");";
        }
    }
}
