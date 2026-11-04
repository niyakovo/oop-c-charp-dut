using System;

namespace Module1
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DeliveryService service = new DeliveryService();

            Transport bike = new Bike();
            Transport car = new Car();
            Transport truck = new Truck();

            service.AddTransport(bike);
            service.AddTransport(car);
            service.AddTransport(truck);

            Order order1 = new Order(101, "Документи", 2, 5);
            Order order2 = new Order(102, "Побутова техніка", 60, 15); // Тільки авто або вантажівка (бо > 10 км і вага)
            Order order3 = new Order(103, "Будівельні матеріали", 1500, 50); // Тільки вантажівка

            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);

            service.ShowAvailableTransportsAndCosts(order1);
            service.ShowAvailableTransportsAndCosts(order2);

            Console.WriteLine("\n--- Призначення замовлень ---");
            service.AssignOrder(order1, bike);
            service.AssignOrder(order2, car);

            service.AssignOrder(order3, car);
            service.AssignOrder(order3, truck);

            service.ShowActiveOrders();

            IPayment card = new CardPayment();
            IPayment cash = new CashPayment();

            service.DeliverOrder(order1, card);
            service.DeliverOrder(order2, cash);

            service.ShowActiveOrders();
            service.ShowHistory();
        }
    }
}