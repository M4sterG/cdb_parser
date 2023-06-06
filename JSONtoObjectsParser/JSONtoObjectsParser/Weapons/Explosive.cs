using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
   public abstract class Explosive : Weapon
   {
        protected double BlastRadius { set; get; }
        public new string ToUniquePropertyList()
        {
            return "blast_radius";
        }
    }
}
