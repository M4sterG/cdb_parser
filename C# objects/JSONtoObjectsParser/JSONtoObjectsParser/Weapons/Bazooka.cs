using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public class Bazooka : Explosive
    {
        public int BulletSpeed { get; set; }
        public SwapSpeed SwapSpeed { get; set; }
        public Bazooka()
        {
            WeaponType = WeaponType.Bazooka;
        }
        public Bazooka(int power, int firingRate, int blastRadius, int bulletSpeed) : this()
        {
            Power = power;  // ability_a in cgd  
            FiringRate = firingRate;    // ability_b in cgd  
            BlastRadius = blastRadius;  // ability_c in cgd  
            BulletSpeed = bulletSpeed;  // ability_d in cgd  
        }
        public new string ToUniquePropertyList()
        {
            return "blast_radius, bullet_speed, swap_speed";
        }
        public new string ToSQLQuery()
        {
            return "INSERT IGNORE INTO bazooka_base_stats (id, " + ToUniquePropertyList() + ") VALUES (" +
                Id + "," +
                BlastRadius + "," +
                BulletSpeed + "," +
                "'" + SwapSpeed.ToString() + "');";
        }
    }
}
