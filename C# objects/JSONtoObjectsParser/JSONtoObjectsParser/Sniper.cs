using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public class Sniper : Gun
    {
        public enum ZoomType
        {
            Reduced,
            Single,
            Single_double,
            Double,
            Double_reduced
        }
        public int ZoomSpeed { get; set; }  
        public ZoomType Zoom { get; set; }
        public Sniper()
        {
            WeaponType = WeaponType.Sniper;
        }
        public Sniper(int power, int firingRate, int zoomSpeed, int reloadSpeed) : this()
        {
            Power = power;  // ability_a in cgd  
            FiringRate = firingRate;    // ability_b in cgd  
            ZoomSpeed = zoomSpeed;  // ability_c in cgd  
            ReloadSpeed = reloadSpeed;  // ability_d in cgd 
        }
        public new string ToUniquePropertyList()
        {
            return "zoom_speed, zoom_type";
        }
        public string ToSQLQuery(int i)
        {
            return "INSERT IGNORE INTO sniper_base_stats (id , " + ToUniquePropertyList() + ") VALUES (" +
                i + "," +
                ZoomSpeed + "," +
                "'" + Zoom.ToString() + "');";
        }
    }
}
