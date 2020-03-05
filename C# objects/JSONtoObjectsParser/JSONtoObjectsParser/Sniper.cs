using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public class Sniper : Weapon
    {
        public int Power { get; set; } // ability_a in cgd
        public int FiringRate { get; set; } // ability_b in cgd

        public int ZoomSpeed { get; set; } // ability_c in cgd

        public int ReloadSpeed { get; set; } // ability_d in cgd

        public Sniper()
        {
            WeaponType = WeaponType.Sniper;
        }

        public Sniper(int power, int firingRate, int zoomSpeed, int reloadSpeed) : this()
        {
            Power = power;
            FiringRate = firingRate;
            ZoomSpeed = zoomSpeed;
            ReloadSpeed = reloadSpeed;

        }
    }
}
