using System.Collections.Generic;

namespace FightClub.Interfaces
{
    public interface IEnemy
    {
        string Name { get; set; } //eg., "GlassJawJoe"
        int HealthPoints { get; set; } //eg., 25
        bool IsDead { get; } //eg., false NOTE utilize your getter! reference this file - https://github.com/BoiseCodeWorks/dotnet19-Vender-Actual/blob/master/Models/Product.cs - specifically the Product.Available
        List<IItem> Loot { get; set; } //eg., [GolfClub, HealthPotion]
        Dictionary<string, IEnemy> NearbyEnemies { get; set; } //eg., { "StrongManStan", StrongManStan }

        void DisplayNearbyEnemies();

        void ListLoot(); //NOTE list the names (and descriptions) of items this enemy possesses

        IItem LootTheLoot(); //NOTE method containing logic for if the enemy is dead then remove desired items from his/her List loot and add to your inventory of Items for future use
    }
}