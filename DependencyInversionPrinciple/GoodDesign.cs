namespace DependencyInversionPrinciple.GoodDesign;

/*
 This is what DIP means:
 -> High level module should not depend on low level module. Rather they should depend on abstraction.
*/

// Abstraction
public interface IEmailSender
{
    void Send(string email, string content);
}

// Low level module
public class EmailSender : IEmailSender
{
    public void Send(string email, string content)
    {
        Console.WriteLine($"Sending email to {email}");
    }
}

// High level module
public class OrderService
{
    private readonly IEmailSender _emailSender;
    public OrderService(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public void CreateOrder()
    {
        Console.WriteLine("Creating order");

        //Sending order details
        _emailSender.Send("test@test.com", "This is order detail.");
    }
}

// We have inverted the dependencies. Now both high level and low level modules are dependent on the abstraction (IEmailSender).
