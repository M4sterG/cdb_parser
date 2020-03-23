using System;
using System.Collections.Generic;
using System.Text;

namespace JSONtoObjectsParser
{
    public abstract class Gun : Weapon
    {
        public int Accuracy { set; get; }
        public new string ToUniquePropertyList()
        {
            return "accuracy";
        }
    }
}
