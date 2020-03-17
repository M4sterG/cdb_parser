using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using JSONtoObjectsParser.Parts;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;

namespace JSONtoObjectsParser
{
    public  class PartGetter
    {
        private const string PARTS_PATH = "iteminfo.json";
        public static List<Part> getParts()
        {
            List<Part> parts = new List<Part>();
            Console.WriteLine("!!! Debugger looks for the files in: " + Environment.CurrentDirectory);
            List<PrimitivePart> allPrimParts = new JSONToCSharpParser<PrimitivePart>().parse(PARTS_PATH);
            List<PrimitivePart> primitiveParts = new List<PrimitivePart>();
            var essences = allPrimParts.FindAll(part => part.ii_name_time.Contains("Unlimited"))
                .GroupBy(part => part.ii_name);
            foreach (var essence in essences)
            {
                primitiveParts.Add(essence.First());
            }
            primitiveParts.ForEach(p => figureOutPart(p, parts));
            parts.ForEach(part =>
            {
                Console.Write(part.Name + " " + setPrint(part.CharacterEquip));
                if (part.GetType() == typeof(Part))
                {
                    Console.Write(" | " + setPrint(((Part)part).PartEquip));
                }
                Console.WriteLine();
            });
           Console.WriteLine(parts.Count +" distinct parts were found");
            return parts;
        }

        private static void setPartStats(PrimitivePart primPart, Part part)
        {
            
            part.Id = primPart.ii_id;
            part.Description = primPart.ii_desc;
            part.Name = primPart.ii_name;
            part.MeshPath = primPart.ii_meshfilename;
        }
        
        
        private static Part handleSimplePart(PrimitivePart primPart, PartSlot slot)
        {
            Part part = new Part();
            part.PartEquip = new HashSet<PartSlot>();
            part.CharacterEquip = new HashSet<Character>();
            part.ItemType = ItemType.Part;
            part.PartEquip.Add(slot);
            setPartStats(primPart, part);
            setCharEquip(primPart, part);
            return part;
        }

        private static Part handleComplexPart(PrimitivePart primPart)
        {
            if (primPart.ii_type != 25)
            {
                throw new ArgumentException("Type needs to be 25");
            }

            Part part = new Part();
                part.PartEquip = new HashSet<PartSlot>();
                part.CharacterEquip = new HashSet<Character>();
                part.Name = primPart.ii_name;
                part.ItemType = ItemType.Part;
                
                    switch (primPart.ii_type_inven)
                    {
                        case 9:
                            // FULL SET
                            part.PartEquip.Add(PartSlot.Hair);
                            part.PartEquip.Add(PartSlot.Face);
                            part.PartEquip.Add(PartSlot.Top);
                            part.PartEquip.Add(PartSlot.Legs);
                            part.PartEquip.Add(PartSlot.Shoes);
                            part.PartEquip.Add(PartSlot.Hands);
                            part.PartEquip.Add(PartSlot.Skirt);
                            return part;
                        case 13:
                            part.PartEquip.Add(PartSlot.Top);
                            part.PartEquip.Add(PartSlot.Legs);
                            return part;
                        case 15:
                            part.PartEquip.Add(PartSlot.Legs);
                            part.PartEquip.Add(PartSlot.Shoes);
                            return part;
                        case 12:
                            part.PartEquip.Add(PartSlot.Hair);
                            part.PartEquip.Add(PartSlot.Face);
                            return part;
                        default:
                            Console.WriteLine("Name: " + primPart.ii_name + " | Unkown type_inven: " +
                                              primPart.ii_type_inven);
                            return null;
                    }
        }
        

        private static string setPrint<T>(HashSet<T> vals)
        {
            String res = "[ ";
            if (vals.Count == 0)
            {
                return "[ ]";
            }
            foreach (T val in vals)
            {
                res += val.ToString() + ", ";
            }

            res = res.Substring(0, res.Length - 2);
            res += " ]";
            return res;
        }

        private static void setCharEquip(PrimitivePart primPart, Part part)
        {
            if (primPart.ii_class_a)
            {
                part.CharacterEquip.Add(Character.Naomi);
            }
            if (primPart.ii_class_b)
            {
                part.CharacterEquip.Add(Character.Kai);
            }

            if (primPart.ii_class_c)
            {
                part.CharacterEquip.Add(Character.Pandora);
            }

            if (primPart.ii_class_e)
            {
                part.CharacterEquip.Add(Character.Knox);
            }

            if (primPart.ii_class_d)
            {
                part.CharacterEquip.Add(Character.CHIP);
            }
        }

        

        private static void figureOutPart(PrimitivePart primPart, List<Part> parts)
        {
            switch (primPart.ii_type)
            {
                case 0:
                    // HAIR
                    parts.Add(handleSimplePart(primPart, PartSlot.Hair));
                    break;
                case 1 :
                    // FACE
                    parts.Add(handleSimplePart(primPart, PartSlot.Face));
                    break;
                case 2 :
                    // TOP
                    parts.Add(handleSimplePart(primPart, PartSlot.Top));
                    break;
                case 3 :
                    // LEGS
                    parts.Add(handleSimplePart(primPart, PartSlot.Legs));
                    break;
                case 4:
                    // SKIRT
                parts.Add(handleSimplePart(primPart, PartSlot.Skirt));
                    break;
                case 5 :
                    // HANDS
                    parts.Add(handleSimplePart(primPart, PartSlot.Hands));
                    break;
                case 6 :
                    // SHOES
                    parts.Add(handleSimplePart(primPart, PartSlot.Shoes));
                    break;
                case 7: 
                    // HEAD ACC
                    parts.Add(handleSimplePart(primPart, PartSlot.HeadAcc));
                    break;
                case 8:
                    // WAIST ACC
                    parts.Add(handleSimplePart(primPart, PartSlot.WaistAcc));
                    break;
                case 9:
                    // BACK ACC
                    parts.Add(handleSimplePart(primPart, PartSlot.BackAcc));
                    break;
                case 21:
                    Console.WriteLine("Unknown type: " + primPart.ii_type
                                                       + " | Name: " + primPart.ii_name);
                    // MISC
                    break;
                case 22:
                    // DIORAMA
                    Console.WriteLine("Diorama type: " + primPart.ii_type
                                                       + " | Name: " + primPart.ii_name);
                    break;
                case 25:
                    // MULTIPLE SLOTS
                    Part part = handleComplexPart(primPart);
                    if (part != null)
                    {
                        parts.Add(part);
                    }
                    break;
                default:
                    Console.WriteLine("Unknown type: " + primPart.ii_type
                                                   + " | Name: " + primPart.ii_name);
                    break;

            }   
        }
    }
}