namespace DependencyInversionPrinciple.BadDesign;

/*
 This is what DIP means:
 -> High level module should not depend on low level module. Rather they should depend on abstraction.
*/


// Low level module
public class EmailSender
{
    public void Send(string email, string content)
    {
        Console.WriteLine($"Sending email to {email}");
    }
}


// High level module
public class OrderService
{
    private readonly EmailSender _emailSender;
    public OrderService(EmailSender emailSender)
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

// The problem is: Here the high level module (OrderService) is tightly dependent on low level module (EmailSender)