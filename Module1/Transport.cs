using System;

namespace Module1
{
    public abstract class Transport
    {
        public string Name { get; protected set; }
        public double MaxWeight { get; protected set; }
        public bool IsBusy { get; private set; }

        public void SetBusy(bool isBusy) => IsBusy = isBusy;

        public virtual bool CanTake(Order order)
        {
            return order.Weight <= MaxWeight;
        }

        public abstract decimal CalculateCost(Order order);
    }

    public class Bike : Transport
    {
        public Bike() 
        { 
            Name = "Велосипед"; 
            MaxWeight = 15;
        }

        public override bool CanTake(Order order)
        {
            return base.CanTake(order) && order.Distance <= 10;
        }

        public override decimal CalculateCost(Order order)
        {
            return 20m + 5m * (decimal)order.Distance;
        }
    }

    public class Car : Transport
    {
        public Car() 
        { 
            Name = "Автомобіль"; 
            MaxWeight = 500; 
        }

        public override decimal CalculateCost(Order order)
        {
            return 50m + 8m * (decimal)order.Distance + 1m * (decimal)order.Weight;
        }
    }

    public class Truck : Transport
    {
        public Truck() 
        { 
            Name = "Вантажівка"; 
            MaxWeight = 5000; 
        }

        public override decimal CalculateCost(Order order)
        {
            return 200m + 15m * (decimal)order.Distance + 0.5m * (decimal)order.Weight;
        }
    }
}