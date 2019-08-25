using System;

namespace FightClub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Fighter fighter = new Fighter();
            fighter.Setup();
            fighter.DisplayTitle();
            fighter.StartingScenario();
            fighter.Run();
        }
    }
}
