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
        public string IconFile { get; set; }

        public virtual string ToUniquePropertyList()
        {
            return "name, description, file_path, type";
        }
        public string ToSQLQuery()
        {
            return "INSERT IGNORE INTO items (item_id, " + ToUniquePropertyList() + ") VALUES (" +
                Id + "," +
                "'" + Name.Replace("'", "''") + "'," +
                "'" + Description.Replace("'", "''") + "'," +
                "'" + MeshPath.Replace("'", "''") + "'," +
                "'" + ItemType.ToString() + "');";
        }
    }

    public enum ItemType
    {
        Weapon,
        Part,
        Accessory,
        Convenience,
        Package
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
