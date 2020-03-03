using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public class Melee : Weapon
    {
        public Melee()
        {
            WeaponType = WeaponType.Melee;
        }

        public Melee(int id, WeaponType weaponType, string name, string desc) : base(id, weaponType, name, desc)
        {

        }

        public int Power { get; set; } 
        public int Range { get; set; } // ability_b in cgd
        public int RunSpeed {get; set;} // ability_c in cgd
        public int SecondaryPower { get; set; } // ability_d in cgd

        public Melee(int power, int range, int runSpeed, int secondaryPower) : this()
        {
            Power = power;
            Range = range;
            RunSpeed = runSpeed;
            SecondaryPower = secondaryPower;

        }
        
        
    }
}
