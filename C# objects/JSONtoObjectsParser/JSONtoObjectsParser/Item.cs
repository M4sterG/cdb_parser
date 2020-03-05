using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string MeshPath { get; set; }
        public ItemType ItemType { get; set; }
    }

    public enum ItemType
    {
        Weapon,
        Part,
        Convenience
    }

    public enum WeaponType
    {
        Melee,
        Rifle,
        Shotgun,
        Sniper,
        Minigun,
        Bazooka,
        Grenade
    }
}
