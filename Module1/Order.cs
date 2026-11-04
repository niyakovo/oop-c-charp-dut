namespace Module1
{
    public class Order
    {
        public int Number { get; private set; }
        public string Description { get; private set; }
        public double Weight { get; private set; }
        public double Distance { get; private set; }

        public Order(int number, string description, double weight, double distance)
        {
            Number = number;
            Description = description;
            Weight = weight;
            Distance = distance;
        }

        public override string ToString()
        {
            return $"Замовлення #{Number} ({Description}, Вага: {Weight} кг, Відстань: {Distance} км)";
        }
    }
}