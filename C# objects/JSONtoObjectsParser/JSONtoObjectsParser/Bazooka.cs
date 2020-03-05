using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public class Bazooka : Weapon
    {
        public int Power { get; set; } // ability_a in cgd
        public int FiringRate { get; set; } // ability_b in cgd

        public int BlastRadius { get; set; } // ability_c in cgd

        public int BulletSpeed { get; set; } // ability_d in cgd

        public Bazooka()
        {
            WeaponType = WeaponType.Bazooka;
        }

        public Bazooka(int power, int firingRate, int blastRadius, int bulletSpeed) : this()
        {
            Power = power;
            FiringRate = firingRate;
            BlastRadius = blastRadius;
            BulletSpeed = bulletSpeed;
        }

    }
}
