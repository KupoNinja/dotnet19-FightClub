using System;
using System.Collections.Generic;
using FightClub.Interfaces;
using FightClub.Models;

namespace FightClub
{
    public class Fighter : IFighter
    {
        public bool AttendingFightClub { get; set; }
        public string Name { get; set; }
        public List<IItem> Inventory { get; set; }
        public int HealthPoints { get; set; }

        public bool IsDead { get; set; } = false;

        public IEnemy CurrentEnemy { get; set; }

        public void Setup()
        {
            Enemy greeter = new Enemy("The Greeter", 40);
            Enemy tiny = new Enemy("Tiny", 25);
            Enemy boss = new Enemy("The Boss", 60);
            // Enemy tyler = new Enemy("Tyler", 100);

            greeter.AddNearbyEnemies(tiny);
            tiny.AddNearbyEnemies(boss);
            // boss.AddNearbyEnemies(boss);

            CurrentEnemy = greeter;
        }
        public void DisplayMenu()
        {
            //TODO must provide options for fighting CurrentEnemy, looting (if enemy is dead), 
            //     moving to a new enemy (CurrentEnemy.NearbyEnemies), using items from your inventory, and retreating/quitting the applicaton
            string startingMenuOptions = "Type (look) to see your opponents or (run) like a coward.";
            // TODO Finish this
            string menuOptions = "You can (a)ttack, (l)ook at your items, or (r)un like a coward.";

            Console.WriteLine("Welcome to Fight Club.\nWhat's your name?");
            Name = Console.ReadLine();
            // NOTE Maybe delay as if it types out the text below.
            Console.WriteLine("I hope you know what you're doing...");
            Console.WriteLine("================================================");
            Console.WriteLine("");
            // Console.WriteLine(startingMenuOptions);
            // NOTE Can you delay this?
            // Console.Clear();
            Console.WriteLine("The man talking to you takes a swift swing at you. You jump back to dodge and put your fists up.");

            Console.WriteLine(menuOptions);
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    Fight();
                    break;
                case "l":
                    ListInventory();
                    break;
                case "r":
                    Console.Clear();
                    Console.WriteLine($"You attempt to run and a man that looks like Edward Norton stands in your way.");
                    Console.WriteLine("");
                    Console.WriteLine("\"I don't think we've met yet, " + Name + ", my name's Tyler.\"");
                    Console.WriteLine("");
                    Console.WriteLine("The last thing you see is Tyler's toothy grin as he shoves a bag over your head.");
                    Console.WriteLine("================================================");
                    Console.WriteLine("");
                    Console.WriteLine("BETTER LUCK NEXT TIME!");
                    AttendingFightClub = false;
                    break;
                default:
                    Console.WriteLine("Try again.");
                    break;
            }

        }

        public void EngageNewEnemy()
        {

        }

        public void Fight()
        {

        }

        public void ListInventory()
        {

        }

        public void Run()
        {
            while (AttendingFightClub)
            {
                DisplayMenu();
            }
        }

        public void UseItem(string itemName)
        {

        }

        public Fighter()
        {
            AttendingFightClub = true;
        }
    }
}