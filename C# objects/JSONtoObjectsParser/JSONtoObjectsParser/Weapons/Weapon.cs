using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public enum SwapSpeed
    {
        Slow,
        Medium,
        Fast
    }
    public abstract class Weapon : Item
    {
        public int Power { get; set; } 
        public int FiringRate { get; set; } 
        public int ReloadSpeed { get; set; }
        public int AmmoClip { get; set; } //wi_bullet_capacity
        public int TotalAmmo { get; set; } //wi_bullet_total
        public int ChangeTime { get; set; }
        public string IconFile { get; set;}
//        public int ChangeSkip { get; set; } always 500
//        public int ChangeDelay { get; set; } always 0
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
        public Weapon(int abilityA, int abilityB, int abilityC, int abilityD)
        {
        }

        public new string ToSQLQuery()
        {
            return "INSERT IGNORE INTO weapons (id, " + ToUniquePropertyList() + ") VALUES (" +
                Id + "," +
                "'" + WeaponType.ToString() + "'," +
                Power + "," +
                ReloadSpeed + "," +
                FiringRate + "," +
                AmmoClip + "," +
                TotalAmmo + ");";
        }
        public new string ToUniquePropertyList()
        {
            return "type, base_power, reload_speed, firing_rate, ammo_clip, ammo_amount";
        }
    }
}
