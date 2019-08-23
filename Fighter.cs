using System.Collections.Generic;
using FightClub.Interfaces;

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

        public void DisplayMenu()
        {
            
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
            
        }

        public void Setup()
        {
            
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