﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public class Grenade : Weapon
    {
        public int Power { get; set; } // ability_a in cgd
        public int FiringRate { get; set; } // ability_b in cgd

        public int BlastRadius { get; set; } // ability_c in cgd

        public int ReloadSpeed { get; set; } // ability_d in cgd

        public Grenade()
        {
            WeaponType = WeaponType.Grenade;
        }

        public Grenade(int power, int firingRate, int blastRadius, int reloadSpeed) : this()
        {
            Power = power;
            FiringRate = firingRate;
            BlastRadius = blastRadius;
            ReloadSpeed = reloadSpeed;
        }
    }
}
