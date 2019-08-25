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
            // NOTE Do I need to account for if the enemy is alive? Shouldn't be an option if enemy is still alive depending on current menu.
            int itemCount = 1;
            foreach (var item in Loot)
            {
                Console.WriteLine($"{itemCount}. {item.Name} - {item.Description}");
                itemCount++;
            }
        }

        public IItem LootTheLoot()
        {
            if (IsDead == true && Loot.Any())
            {
                ListLoot();
            }
            else
            {
                Console.WriteLine("Enemy doesn't have any items.");
                Console.WriteLine("");
            }
            // NOTE Take enemy items and add to inventory (How to get it into Fighter inventory from here...)
            // NOTE Remove items from enemy Loot
            // NOTE Display what the Fighter took
            // this.
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