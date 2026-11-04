using System;

namespace Lab3
{
    public class Hunter
    {
        public string Name { get; private set; }
        public int Health { get; protected set; }
        public int Gold { get; protected set; }
        public int Arrows { get; protected set; }
        public int Prey { get; protected set; }

        protected static readonly Random rand = new Random();

        public Hunter(string name, int health, int gold, int arrows)
        {
            Name = name;
            Health = health;
            Gold = gold;
            Arrows = arrows;
            Prey = 0;
        }

        public virtual void Hunt()
        {
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} занадто виснажений для полювання (Здоров'я: {Health}).");
                return;
            }

            if (Arrows <= 0)
            {
                Console.WriteLine($"{Name} не має стріл для полювання!");
                return;
            }

            Arrows--;
            int healthLoss = rand.Next(10, 25);
            Health -= healthLoss;
            
            int earnedGold = rand.Next(10, 30);
            Gold += earnedGold;
            Prey++;

            Console.WriteLine($"{Name} вполював здобич! Витрачено 1 стрілу. Втрачено {healthLoss} здоров'я, знайдено {earnedGold} золота.");
        }

        public void BuyArrows(int amount)
        {
            int costPerArrow = 5;
            int totalCost = amount * costPerArrow;

            if (Gold >= totalCost)
            {
                Gold -= totalCost;
                Arrows += amount;
                Console.WriteLine($"{Name} купив {amount} стріл за {totalCost} золота.");
            }
            else
            {
                Console.WriteLine($"{Name} не має достатньо золота! Потрібно {totalCost}, а є {Gold}.");
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"[{Name}] Здоров'я: {Health} | Золото: {Gold} | Стріли: {Arrows} | Здобич: {Prey}");
        }
    }
}