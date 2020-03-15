namespace JSONtoObjectsParser.Parts
{
    public class Part : Item
    {
        public Character[] CharacterEquip { get; set; }
        public PartSlot[] PartEquip { get; set; }
    }

    public enum PartSlot
    {
        HeadAcc,
        Hair,
        Face,
        Top,
        Skirt, // Naomi only
        Legs,
        Shoes,
        BackAcc,
        WaistAcc
    }

    public enum ExtraStats
    {
        Grenade9,
        Bazooka9,
        Sniper9,
        Shotgun9,
        Rifle60,
        Minigun60,
        Tank160,
        Tank80,
        Tank240,
        Tank480,
        Tank520,
        RunSpeed4,
        RunSpeed2,
        RunSpeed8,
        RunSpeed12,
        RunSpeed1,
        NoOption
    }
}