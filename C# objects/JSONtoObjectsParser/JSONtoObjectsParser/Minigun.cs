using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public class Minigun : Weapon
    {

        public int Power { get; set; } // ability_a in cgd
        public int WarmUpTime { get; set; } // ability_b in cgd

        public int RunSpeed { get; set; } // ability_c in cgd

        public int Accuracy { get; set; } // ability_d in cgd
        public Minigun()
        {
            WeaponType = WeaponType.Minigun;
        }

        public Minigun(int power, int warmUpTime, int runSpeed, int accuracy) : this()
        {
            Power = power;
            WarmUpTime = warmUpTime;
            RunSpeed = runSpeed;
            Accuracy = accuracy;

        }
    }
}
