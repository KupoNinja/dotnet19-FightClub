namespace FightClub.Interfaces
{
    public interface IItem
    {
        string Name { get; set; } //eg., "Hammer" || "HealthPotion"
        string Description { get; set; } //eg., "It's a bludger." || "Made from the leafs of a thousand Avandesora trees."
        int HPModifier { get; set; } //eg. -10 || +20
        bool IsWeapon { get; set; }
    }
}