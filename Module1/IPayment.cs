using System;

namespace Module1
{
    public interface IPayment
    {
        void Pay(decimal amount);
    }

    public class CardPayment : IPayment
    {
        public void Pay(decimal amount) => Console.WriteLine($"Оплата карткою пройшла успішно: {amount} грн");
    }

    public class CashPayment : IPayment
    {
        public void Pay(decimal amount) => Console.WriteLine($"Оплата готівкою пройшла успішно: {amount} грн");
    }
}