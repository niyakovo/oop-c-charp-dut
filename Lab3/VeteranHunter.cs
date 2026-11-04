using System;

namespace Lab3
{
    public class VeteranHunter : Hunter
    {
        public VeteranHunter(string name, int health, int gold, int arrows) 
            : base(name, health, gold, arrows)
        {
        }

        public override void Hunt()
        {
            if (Health <= 0 || Arrows <= 0)
            {
                base.Hunt();
                return;
            }

            Arrows--;
            int healthLoss = rand.Next(1, 10);
            Health -= healthLoss;
            
            int earnedGold = rand.Next(20, 50);
            Gold += earnedGold;
            Prey++;

            Console.WriteLine($"{Name} (Ветеран) майстерно вполював здобич! Втрачено {healthLoss} здоров'я, знайдено {earnedGold} золота.");
        }
    }
}