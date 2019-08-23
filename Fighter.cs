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

        }
        public void DisplayMenu()
        {
            //TODO must provide options for fighting CurrentEnemy, looting (if enemy is dead), 
            //     moving to a new enemy (CurrentEnemy.NearbyEnemies), using items from your inventory, and retreating/quitting the applicaton
            while (AttendingFightClub)
            {
                string menuOptions = "Type (look) to see your opponents or (run) to be a coward.";

                Console.WriteLine("Welcome to Fight Club.");
                // Maybe delay as if it types out the text below.
                Console.WriteLine("I hope you know what you're doing...");
                Console.WriteLine("================================================");
                Console.WriteLine("The man talking you takes a swift swing at you.");

                Console.WriteLine(menuOptions);
                switch (Console.ReadLine().ToLower())
                {
                    case "look":
                        // Enemy.DisplayNearbyEnemies();
                        break;

                }
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