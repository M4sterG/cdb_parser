using System.Collections.Generic;
using JSONtoObjectsParser.Parts;

namespace JSONtoObjectsParser
{
    public class Program
    {
        public static void Main(string[] args)
        { 
           List<Weapon> weapons = WeaponGetter.getWeapons();
           List<Part> parts = PartGetter.getParts();
        }
    }
}