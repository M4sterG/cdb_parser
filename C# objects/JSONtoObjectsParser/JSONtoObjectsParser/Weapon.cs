using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public /*abstract*/ class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }
        public Weapon(int id, WeaponType weaponType, string name, string desc)
        {
            Id = id;
            Name = name;
            Description = desc;
            WeaponType = weaponType;
        }

        public Weapon()
        {

        }
       

    }

    
}
