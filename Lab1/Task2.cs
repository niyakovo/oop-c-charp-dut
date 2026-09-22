namespace Lab1
{
    internal class Task2
    {
        public void Run()
        {
            int[] numbers = new int[10];
        }

        public void InitializeArrayRandom(int[] numbers)
        {
            Random random = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 101);
            }
        }
    }
}