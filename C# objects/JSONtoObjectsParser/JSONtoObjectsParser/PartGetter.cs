using System;
using System.Collections.Generic;
using JSONtoObjectsParser.Parts;
using Newtonsoft.Json;

namespace JSONtoObjectsParser
{
    public  class PartGetter
    {
        private const string PARTS_PATH = "iteminfo.json";
        public static List<Part> getParts()
        {
            Console.WriteLine("!!! Debugger looks for the files in: " + Environment.CurrentDirectory);
            List<PrimitivePart> primitiveParts = new JSONToCSharpParser<PrimitivePart>().parse(PARTS_PATH);
            return null;
        }
    }
}