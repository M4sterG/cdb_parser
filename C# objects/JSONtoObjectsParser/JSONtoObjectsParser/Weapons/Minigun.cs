using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public class Minigun : Gun
    {
        public enum FireType
        {
            BULLETS,
            FIRE,
            PLASMA
        }
        public int WarmUpTime { get; set; }
        public int Weight { get; set; }
        public FireType FType { get; set; }
        
        public Minigun()
        {
            WeaponType = WeaponType.Minigun;
        }
        public Minigun(int power, int warmUpTime, int runSpeed, int accuracy) : this()
        {
            Power = power;  // ability_a in cgd  
            WarmUpTime = warmUpTime;    // ability_b in cgd  
            Weight = runSpeed;    // ability_c in cgd  
            Accuracy = accuracy;    // ability_d in cgd  
        }
        public new string ToUniquePropertyList()
        {
            return "fire_type, warm_up, weigth";
        }
        public new string ToSQLQuery()
        {
            return "INSERT IGNORE INTO minigun_base_stats (id, " + ToUniquePropertyList() + ") VALUES (" +
                Id + "," +
                "'" + FType.ToString() + "'" +
                WarmUpTime + "," +
                Weight + ");";
        }
    }
}
