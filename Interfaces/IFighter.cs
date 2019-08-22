using System.Collections.Generic;

namespace FightClub.Interfaces
{
    public interface IFighter //NOTE this is the interface for what is normally our App.cs file. Name the class either Fighter or App but make sure it implements this interface and that you utilize the class like all of our App classes from previous projects.
    {
        bool AttendingFightClub { get; set; } //NOTE bool for main control flow loop
        string Name { get; set; } //eg., "iamporter"
        List<IItem> Inventory { get; set; } //the list to store all of the items you've looted
        int HealthPoints { get; set; } //eg., 100
        bool IsDead { get; } //eg., false NOTE utilize your getter! reference this file - https://github.com/BoiseCodeWorks/dotnet19-Vender-Actual/blob/master/Models/Product.cs - specifically the Product.Available
        IEnemy CurrentEnemy { get; set; }

        void Setup(); //NOTE 1) create all of your enemies and items, 2) give enemies items, 3) establish NearbyEnemies relationships, and 4) assign the CurrentEnemy
        void Run(); //NOTE main control flow method for while user is engaging with the application
        void DisplayMenu(); //TODO must provide options for fighting CurrentEnemy, looting (if enemy is dead), moving to a new enemy (CurrentEnemy.NearbyEnemies), using items from your inventory, and retreating/quitting the applicaton
        void Fight(); //NOTE utilize random number generators to determine your damage dealt to the CurrentEnemy and taken from the CurrentEnemy.
        void ListInventory();
        void UseItem(string itemName); //NOTE list items and then allow user to specify which item they would like to use HINT: List.Find(i => i.Name == itemName);
        void EngageNewEnemy(); //NOTE contains the logic for engaging a NearbyEnemy. (logic establishing the LinkedList)
    }
}