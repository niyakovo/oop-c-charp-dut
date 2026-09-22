namespace Lab1
{
    public class Task1
    {
        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public void PrintEvenResult(bool isEven)
        {
            if (isEven)
            {
                Console.WriteLine("The number is even.");
            }
            else
            {
                Console.WriteLine("The number is odd.");
            }
        }
    }
}