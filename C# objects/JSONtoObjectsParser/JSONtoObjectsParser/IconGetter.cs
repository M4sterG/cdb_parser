using System;
using System.Collections.Generic;
using JSONtoObjectsParser.Icons;
using JSONtoObjectsParser.Parts;
using Console = Colorful.Console;

namespace JSONtoObjectsParser
{
    public class IconGetter
    {
        private const string MV_ICONS_PATH = "MV/iconsinfo.json";
        private const string TW_ICONS_PATH = "TW/iconsinfo.json";

        public static List<PrimitiveIcon> getPrimIcons()
        {
            return getPrimIcons(MV_ICONS_PATH);
        }

        public static List<PrimitiveIcon> getPrimIcons(string iconsPath)
        {
            Console.WriteLine("!!! Debugger looks for the files in: " + Environment.CurrentDirectory);
            List<PrimitiveIcon> icons = new JSONToCSharpParser<PrimitiveIcon>().parse(iconsPath);
            return icons;
        }
        
         
    }
}