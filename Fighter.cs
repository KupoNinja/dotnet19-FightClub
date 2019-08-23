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
            // NOTE Maybe add an item that stuns the enemy giving you another turn?
            Item brick = new Item("brick", "A brick is building material used to make walls, pavements and other elements in masonry construction.", 15);
            Item bottle = new Item("bottle", "A bottle designed as a container for beer.", 10);
            Item rock = new Item("rock", "An American actor, producer, and former professional wrestler.", 60);
            Item apple = new Item("apple", "A sweet, edible fruit produced by an apple tree", 10);
            Item milk = new Item("milk", "A nutrient-rich, white liquid food produced by the mammary glands of mammals.", 50);

            // NOTE Maybe set up Tyler to be OP at the start if they try to run and make the player actually fight him. Can be true ending boss.
            Enemy greeter = new Enemy("The Greeter", 40);
            Enemy tiny = new Enemy("Tiny", 25);
            Enemy glasses = new Enemy("Glasses", 30);
            Enemy boss = new Enemy("The Boss", 60);
            // Enemy tyler = new Enemy("Tyler", 100);

            greeter.AddNearbyEnemies(tiny);
            tiny.AddNearbyEnemies(boss);
            tiny.AddNearbyEnemies(glasses);
            boss.AddNearbyEnemies(glasses);
            // boss.AddNearbyEnemies(boss);

            greeter.Loot.Add(bottle);
            tiny.Loot.Add(brick);
            tiny.Loot.Add(apple);
            boss.Loot.Add(rock);
            boss.Loot.Add(milk);

            CurrentEnemy = greeter;
        }
        public void DisplayMenu()
        {
            //TODO must provide options for fighting CurrentEnemy, looting (if enemy is dead), 
            //     moving to a new enemy (CurrentEnemy.NearbyEnemies), using items from your inventory, and retreating/quitting the applicaton
            StartingScenario();

            // string startingMenuOptions = "Type (look) to see your opponents or (run) like a coward.";
            // TODO Finish this
            string menuOptions = "You can (a)ttack, (l)ook at your items, or (r)un like a coward.";

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

        public void StartingScenario()
        {
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
        }

        public void EngageNewEnemy()
        {

        }

        public void Fight()
        {
            // NOTE After enemy loses can loot
            // NOTE Set another menu here to view nearbyenemies?
        }

        public void ListInventory()
        {
            int itemCount = 0;
            foreach (var item in Inventory)
            {
                Console.WriteLine(itemCount + ". " + item);
                itemCount++;
            }
            Console.WriteLine("================================================");
            Console.WriteLine("You can (use 'item') or go (back) to using your fists like a man.");

            string userInput = Console.ReadLine().ToLower();
            string[] words = userInput.Split(' ');
            string command = words[0];
            string option = "";

            if (words.Length > 1)
            {
                option = words[1];
            }
            switch (command)
            {
                case "back":
                    DisplayMenu();
                    break;
                case "use":
                    UseItem(option);
                    break;
                default:
                    Console.WriteLine("Quit wasting time! Do something!");
                    break;
            }
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
            if (HealthPoints < 50)
            {
                // NOTE Could use a bool IsWeapon for Items to determine if it heals or damages.
            }
        }

        public Fighter()
        {
            AttendingFightClub = true;
            HealthPoints = 50;
        }
    }
}