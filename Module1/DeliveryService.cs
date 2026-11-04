using System;
using System.Collections.Generic;

namespace Module1
{
    public class DeliveryService
    {
        private List<Transport> _transports = new List<Transport>();
        private List<Order> _activeOrders = new List<Order>();
        private List<Order> _history = new List<Order>();
        private Dictionary<Order, Transport> _assignments = new Dictionary<Order, Transport>();

        public void AddTransport(Transport transport) => _transports.Add(transport);
        public void AddOrder(Order order) => _activeOrders.Add(order);

        public void ShowAvailableTransportsAndCosts(Order order)
        {
            Console.WriteLine($"\n--- Розрахунок для: {order} ---");
            bool canBeDelivered = false;

            foreach (var transport in _transports)
            {
                if (transport.CanTake(order))
                {
                    string status = transport.IsBusy ? "(Зайнятий)" : "(Вільний)";
                    Console.WriteLine($"- {transport.Name} {status}: {transport.CalculateCost(order)} грн");
                    canBeDelivered = true;
                }
            }

            if (!canBeDelivered)
                Console.WriteLine("Немає відповідного транспорту для цього замовлення.");
        }

        public void AssignOrder(Order order, Transport transport)
        {
            if (transport.IsBusy)
            {
                Console.WriteLine($"[Помилка] {transport.Name} зараз зайнятий.");
                return;
            }

            if (!transport.CanTake(order))
            {
                Console.WriteLine($"[Помилка] {transport.Name} не може взяти це замовлення через обмеження.");
                return;
            }

            transport.SetBusy(true);
            _assignments[order] = transport;
            Console.WriteLine($"[Успіх] Замовлення #{order.Number} призначено на {transport.Name}.");
        }

        public void DeliverOrder(Order order, IPayment paymentMethod)
        {
            if (!_assignments.ContainsKey(order))
            {
                Console.WriteLine($"[Помилка] Замовлення #{order.Number} не призначено жодному транспорту.");
                return;
            }

            Transport transport = _assignments[order];
            decimal cost = transport.CalculateCost(order);

            Console.WriteLine($"\n--- Виконання доставки #{order.Number} ---");
            paymentMethod.Pay(cost);
            
            transport.SetBusy(false);
            _activeOrders.Remove(order);
            _history.Add(order);
            _assignments.Remove(order);

            Console.WriteLine($"Замовлення #{order.Number} успішно доставлено. Транспорт {transport.Name} тепер вільний.");
        }

        public void ShowActiveOrders()
        {
            Console.WriteLine("\n--- Активні замовлення ---");
            if (_activeOrders.Count == 0) Console.WriteLine("Немає активних замовлень.");
            foreach (var order in _activeOrders)
            {
                string assignedTo = _assignments.ContainsKey(order) ? _assignments[order].Name : "Очікує призначення";
                Console.WriteLine($"{order} -> Транспорт: {assignedTo}");
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("\n--- Історія доставок ---");
            if (_history.Count == 0) Console.WriteLine("Історія порожня.");
            foreach (var order in _history)
            {
                Console.WriteLine(order.ToString());
            }
        }
    }
}