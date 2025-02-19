using FightClub.Interfaces;

namespace FightClub.Models
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int HPModifier { get; set; }
        public bool IsWeapon { get; set; }

        public Item(string name, string description, int hpmodifier, bool isWeapon = true)
        {
            Name = name;
            Description = description;
            HPModifier = hpmodifier;
            IsWeapon = isWeapon;
        }
    }
}