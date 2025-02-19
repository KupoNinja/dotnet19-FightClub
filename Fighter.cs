using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            Item brick = new Item("Brick", "A brick is building material used to make walls, pavements and other elements in masonry construction.", 15);
            Item bottle = new Item("Bottle", "A bottle designed as a container for beer.", 10);
            Item rock = new Item("Rock", "An American actor, producer, and former professional wrestler.", 60);
            Item apple = new Item("Apple", "A sweet, edible fruit produced by an apple tree", 10, false);
            Item milk = new Item("Milk", "A nutrient-rich, white liquid food produced by the mammary glands of mammals.", 15, false);
            Item sandwich = new Item("Sandwich", "A  food typically consisting of vegetables, sliced cheese or meat, placed on or between slices of bread.", 25, false);

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
            // boss.AddNearbyEnemies(tyler);

            greeter.Loot.Add(bottle);
            tiny.Loot.Add(brick);
            tiny.Loot.Add(apple);
            glasses.Loot.Add(sandwich);
            boss.Loot.Add(rock);
            boss.Loot.Add(milk);

            // NOTE Take these out after testing.
            Inventory.Add(brick);
            Inventory.Add(apple);

            CurrentEnemy = greeter;
        }
        public void DisplayMenu()
        {
            //TODO must provide options for fighting CurrentEnemy, looting (if enemy is dead), 
            //     moving to a new enemy (CurrentEnemy.NearbyEnemies), using items from your inventory, 
            //     and retreating/quitting the applicaton
            // TODO Finish this
            string menuOptions = "You can (a)ttack, (l)ook at your items, or (r)un like a coward.";

            if (CurrentEnemy.IsDead)
            {
                // NOTE Dialogue still shows after user chooses an option.
                // NOTE Have user type out word when done.
                Console.WriteLine("\nPress enter to continue.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"{CurrentEnemy.Name} hits the ground hard.");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("You handled yourself well!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("================================================");
                Console.WriteLine("");
                Console.WriteLine("(L)oot the enemy, (s)how nearby enemies, or (r)un like a coward?");
                switch (Console.ReadLine().ToLower())
                {
                    // TODO Finish this
                    case "l":
                        if (!CurrentEnemy.Loot.Any())
                        {
                            Console.WriteLine("The enemy has no loot.");
                        }
                        else
                        {
                            IItem takenLoot = CurrentEnemy.LootTheLoot();
                            if (takenLoot is IItem)
                            {
                                Inventory.Add(takenLoot);
                                Console.WriteLine("You took " + takenLoot.Name + ".");
                            }
                            // Do I need to handle if takeLoot is not an IItem? back returns null
                        }
                        break;
                    case "s":
                        CurrentEnemy.DisplayNearbyEnemies();
                        break;
                    case "r":
                        Coward();
                        break;
                }
            }
            else
            {
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
                        Coward();
                        break;
                    default:
                        Console.WriteLine("Try again.");
                        // Console.WriteLine("");
                        break;
                }
            }
        }

        public void DisplayHP()
        {
            Console.WriteLine(CurrentEnemy.Name + "- HP: " + CurrentEnemy.HealthPoints);
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(Name + "- HP: " + HealthPoints);
            Console.WriteLine("");
            Console.WriteLine("================================================");
            Console.WriteLine("");
        }

        public void DisplayTitle()
        {
            Console.Clear();
            string title = @"
 __     __     ______     __         ______     ______     __    __     ______                
/\ \  _ \ \   /\  ___\   /\ \       /\  ___\   /\  __ \   /\ \-./  \   /\  ___\               
\ \ \/ \.\ \  \ \  __\   \ \ \____  \ \ \____  \ \ \/\ \  \ \ \-./\ \  \ \  __\               
 \ \__/ .~\_\  \ \_____\  \ \_____\  \ \_____\  \ \_____\  \ \_\ \ \_\  \ \_____\             
  \/_/   \/_/   \/_____/   \/_____/   \/_____/   \/_____/   \/_/  \/_/   \/_____/             
                                                                                              
 ______   ______                                                                              
/\__  _\ /\  __ \                                                                             
\/_/\ \/ \ \ \/\ \                                                                            
   \ \_\  \ \_____\                                                                           
    \/_/   \/_____/                                                                           
                                                                                              
 ______   __     ______     __  __     ______      ______     __         __  __     ______    
/\  ___\ /\ \   /\  ___\   /\ \_\ \   /\__  _\    /\  ___\   /\ \       /\ \/\ \   /\  == \   
\ \  __\ \ \ \  \ \ \__ \  \ \  __ \  \/_/\ \/    \ \ \____  \ \ \____  \ \ \_\ \  \ \  __<   
 \ \_\    \ \_\  \ \_____\  \ \_\ \_\    \ \_\     \ \_____\  \ \_____\  \ \_____\  \ \_____\ 
  \/_/     \/_/   \/_____/   \/_/\/_/     \/_/      \/_____/   \/_____/   \/_____/   \/_____/ 
                                                                                              
";
            Console.WriteLine(title);
            Console.WriteLine("=============================================================================================");

            Console.WriteLine("");
            Console.WriteLine("Press any key to start or Ctrl+C to exit.");
            Console.ReadKey();
            Console.WriteLine("");
        }

        public void StartingScenario()
        {
            Console.Clear();
            Console.WriteLine("A man greets you at the door.");
            Console.WriteLine("");
            Typewrite("\"Welcome to Fight Club.\"\n\"What's your name?\"");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------");
            Name = Console.ReadLine();

            Console.Clear();
            Typewrite($"\"I hope you know what you're doing, {Name}...\"");
            Console.WriteLine("");
            Console.WriteLine("================================================");
            Console.WriteLine("");
            Console.WriteLine("Type (look) to see your opponents or (run) like a coward.");
            Thread.Sleep(2500);

            Console.Clear();
            Typewrite("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("");
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("The man talking to you takes a swift swing at you.");
            Console.WriteLine("You jump back to dodge and put your fists up.");
            Console.WriteLine("================================================");
        }

        private void Coward()
        {
            Console.Clear();
            Console.WriteLine($"You attempt to run and a beat up man that looks like Edward Norton stands in your way.");
            Thread.Sleep(2000);
            Console.WriteLine("");
            Typewrite("\"I don't think we've met yet, " + Name + ", my name's Tyler.\"");
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine("The last thing you see is Tyler's bloody grin as he shoves a bag over your head.");
            Console.WriteLine("================================================");
            Console.WriteLine("");
            Console.WriteLine("BETTER LUCK NEXT TIME!");
            AttendingFightClub = false;
        }

        private static void Typewrite(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(50);
            }
            Console.WriteLine("");
        }

        public void EngageNewEnemy()
        {

        }

        // TODO Do I create enemy actions in here (if you attack, enemy attacks) or create enemy actions in Enemy
        public void Fight()
        {
            while (CurrentEnemy.HealthPoints > 0)
            {
                Console.WriteLine("\nPress enter to continue.");
                Console.ReadLine();
                Console.Clear();
                if (HealthPoints <= 0)
                {
                    Typewrite("First you have to give up, first you have to know not fear — Know that someday you’re gonna die.");
                    Thread.Sleep(1000);
                    Typewrite("Today is that day.");
                    AttendingFightClub = false;
                }

                DisplayHP();
                Console.WriteLine("You can (p)unch, roundhouse (k)ick, or (u)se an item.");
                switch (Console.ReadLine().ToLower())
                {
                    case "p":
                        Console.WriteLine("You punch " + CurrentEnemy.Name + " in the face.");
                        Console.WriteLine("");
                        // Thread.Sleep(1000);
                        CurrentEnemy.HealthPoints -= 5;
                        break;
                    case "k":
                        Console.WriteLine("You summon your inner Chuck Norris and land a stunning roundhouse on " + CurrentEnemy.Name + "'s chest.");
                        Console.WriteLine("");
                        // Thread.Sleep(2000);
                        CurrentEnemy.HealthPoints -= 7;
                        break;
                    case "u":
                        ListInventory();
                        break;
                    default:
                        Console.WriteLine("You ain't gonna survive long with your fat fingers. Try again.");
                        // Thread.Sleep(2000);
                        break;
                }
            }

            // NOTE After enemy loses can loot
            // NOTE Set another menu here to view nearbyenemies?
        }

        public void ListInventory()
        {
            Console.Clear();
            if (Inventory.Any())
            {
                int itemCount = 1;
                Console.WriteLine("");
                Console.WriteLine("Items:");
                foreach (var item in Inventory)
                {
                    Console.WriteLine($"{itemCount}. {item.Name} - {item.Description}");
                    itemCount++;
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("You don't have any items.");
                Console.WriteLine("");
                return;
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
                    Console.Clear();
                    DisplayHP();
                    Fight();
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
            IItem targetItem = Inventory.Find(i => i.Name.ToLower() == itemName);
            // NOTE Just practicing casting
            // Item myItem = (Item)targetItem;

            if (targetItem is null)
            {
                Console.Clear();
                DisplayHP();
                Console.WriteLine("");
                Console.WriteLine("You get hit too hard? That isn't in your inventory.\nTry again!");
                Console.WriteLine("");
            }
            else
            {
                if (targetItem.IsWeapon)
                {
                    CurrentEnemy.HealthPoints -= targetItem.HPModifier;
                    Inventory.Remove(targetItem);
                    Console.Clear();
                    DisplayHP();
                    Console.WriteLine($"{CurrentEnemy.Name} lost -{targetItem.HPModifier} from {targetItem.Name}.");
                    Console.WriteLine("");
                }
                if (!targetItem.IsWeapon)
                {
                    HealthPoints += targetItem.HPModifier;
                    Inventory.Remove(targetItem);
                    Console.Clear();
                    DisplayHP();
                    Console.WriteLine($"You gained +{targetItem.HPModifier} from {targetItem.Name}.");
                    Console.WriteLine("");
                }
            }
        }

        public Fighter()
        {
            AttendingFightClub = true;
            HealthPoints = 50;
            Inventory = new List<IItem>();
        }
    }
}