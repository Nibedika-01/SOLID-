using System;

public interface IPayment
{
    void Pay(decimal amount);
}

public class EsewaPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} via Esewa");
    }
}

public class KhaltiPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} via Khalti");
    }
}

public class BankTransferPayment : IPayment
{
    public void Pay(decimal amount)
    {
        if (amount > 10000)
        {
            throw new NotSupportedException("Limit exceeded"); //doesnt support Lisknov
        }
        Console.WriteLine($"Paid {amount} via Bank");
    }
}


public class PaymentProcessor
{
    private readonly IPayment payment;

    public PaymentProcessor(IPayment payment)
    {
        this.payment = payment;
    }

    public void Process(decimal amount)
    {
        payment.Pay(amount);
    }
}


//No DIP
//class PaymentProcessor
//{
//    private EsewaPayment esewa = new EsewaPayment();

//    public void Process(decimal amount)
//    {
//        esewa.Pay(amount); // Boss knows exact helper name → tight coupling
//    }
//}


class Program
{
    static void Main()
    {
        PaymentProcessor p1 = new PaymentProcessor(new EsewaPayment());
        p1.Process(100);

        PaymentProcessor p2 = new PaymentProcessor(new KhaltiPayment());
        p2.Process(500);
    }
}







//No ISP
//public interface IPayment
//{
//    void Pay(decimal amount);
//    void Refund(decimal amount);  wrong wrong
//    void SchedulePayment(DateTime date, decimal amount);
//}

//With ISP
//public interface IPayment
//{
//    void Pay(decimal amount);
//}
//public interface IRefundable
//{
//    void Refund(decimal amount);
//}
//public interface ISchedulable
//{
//    void SchedulePayment(DateTime date, decimal amount);
//}



