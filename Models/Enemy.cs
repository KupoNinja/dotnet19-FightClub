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
        }
    }
}