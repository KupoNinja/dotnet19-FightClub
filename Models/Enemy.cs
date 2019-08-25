using System;
using System.Collections.Generic;
using FightClub.Interfaces;

namespace FightClub.Models
{
    public class Enemy : IEnemy
    {
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public bool IsDead { get { return HealthPoints > 0; } set { return; } }

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

        }

        public IItem LootTheLoot()
        {
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