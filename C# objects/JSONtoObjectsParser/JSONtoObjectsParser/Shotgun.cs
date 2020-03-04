using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public class Shotgun : Weapon
    {
        public int Power { get; set; } // ability_a in cgd
        public int FiringRate { get; set; } // ability_b in cgd

        public int Accuracy { get; set; } // ability_c in cgd

        public int ReloadSpeed { get; set; } // ability_d in cgd

        public Shotgun()
        {
            WeaponType = WeaponType.Shotgun;
        }

        public Shotgun(int power, int firingRate, int accuracy, int reloadSpeed) : this()
        {
            Power = power;
            FiringRate = firingRate;
            Accuracy = accuracy;
            ReloadSpeed = reloadSpeed;

        }
    }
}
