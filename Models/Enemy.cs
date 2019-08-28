using System;
using System.Collections.Generic;
using System.Linq;
using FightClub.Interfaces;

namespace FightClub.Models
{
    public class Enemy : IEnemy
    {
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public bool IsDead { get { return HealthPoints <= 0; } set { return; } }

        public List<IItem> Loot { get; set; }
        public Dictionary<string, IEnemy> NearbyEnemies { get; set; }

        public void AddNearbyEnemies(Enemy enemyToAdd, bool autoAdd = true)
        {
            NearbyEnemies.Add(enemyToAdd.Name, enemyToAdd);
            if (autoAdd)
            {
                enemyToAdd.AddNearbyEnemies(this, false);
            }
        }

        public void DisplayNearbyEnemies()
        {
            Console.Clear();
            Console.WriteLine("You look around and see these challengers nearby: ");
            foreach (var kvp in NearbyEnemies)
            {
                Console.WriteLine(kvp.Key);
            }

        }

        // NOTE Unsure if this method is needed 
        public void ListLoot()
        {
            Console.Clear();
            Console.WriteLine($"These are the items they were carrying.");
            int itemCount = 1;
            foreach (var item in Loot)
            {
                Console.WriteLine($"{itemCount}. {item.Name} - {item.Description}");
                itemCount++;
            }
            // LootTheLoot();
        }

        public IItem LootTheLoot()
        {
            IItem item = null;
            if (!Loot.Any())
            {
                Console.WriteLine("Enemy doesn't have any items.");
                Console.WriteLine("");
            }
            else
            {
                ListLoot();
                Console.WriteLine("You can (take 'item') or go (back).");
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
                    case "take":
                        IItem targetItem = Loot.Find(l => l.Name.ToLower() == option);
                        Console.Clear();
                        if (targetItem is null)
                        {
                            Console.WriteLine("They don't have whatever it is you're wanting, buddy.");
                        }
                        else
                        {
                            Loot.Remove(targetItem);
                            item = targetItem;
                        }
                        break;
                    case "back":
                        // Console.Clear();
                        return null;
                    default:
                        Console.WriteLine("What's wrong with you?! Hurry up! Everyone's waiting!");
                        break;
                }
            }
            // NOTE Take enemy items and add to inventory (How to get it into Fighter inventory from here...)
            // NOTE Remove items from enemy Loot
            // NOTE Display what the Fighter took
            return item;
        }

        public Enemy(string name, int hp)
        {
            Name = name;
            HealthPoints = hp;
            NearbyEnemies = new Dictionary<string, IEnemy>();
            Loot = new List<IItem>();
        }
    }
}