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
        public bool IsDead { get { return HealthPoints < 0; } set { return; } }

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
            foreach (var kvp in NearbyEnemies)
            {
                Console.WriteLine(kvp.Key);
            }
        }
        public void ListLoot()
        {
            // NOTE Do I need to account for if the enemy is alive? Shouldn't be an option if enemy is still alive.
            if (IsDead == true && Loot.Any())
            {
                int itemCount = 1;
                foreach (var item in Loot)
                {
                    Console.WriteLine($"{itemCount}. {item.Name} - {item.Description}");
                    itemCount++;
                }
            }
            else
            {
                Console.WriteLine("Enemy doesn't have any items.");
                Console.WriteLine("");
                return;
            }

            LootTheLoot();
        }

        public IItem LootTheLoot()
        {
            Console.WriteLine("(T)ake the items or go (b)ack.");
            Console.WriteLine("");
            switch (Console.ReadLine().ToLower())
            {
                case "t":

            }
            return null;
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