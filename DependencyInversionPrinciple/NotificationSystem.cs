namespace DependencyInversionPrinciple;

/*
 This is what DIP means:
 -> High level module should not depend on low level module. Rather they should depend on abstraction.
*/

/*
 Let's consider a scenario where we're building a notification system. We have different types of notification senders, such as email and SMS.
 We'll use the Dependency Inversion Principle to ensure that the high-level modules (notification services) depend on abstractions (interfaces),
 and the low-level modules (notification senders) also depend on the same abstractions.
 */

// Abstractions
interface INotificationSender
{
    void SendNotification(string message);
}

// Low-level modules
class EmailSender : INotificationSender
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

class SMSSender : INotificationSender
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

// High-level module
class NotificationService
{
    private readonly INotificationSender _sender;

    public NotificationService(INotificationSender sender)
    {
        _sender = sender;
    }

    public void NotifyUser(string message)
    {
        _sender.SendNotification(message);
    }
}

/*
 In this example:

We have an INotificationSender interface that represents the abstraction for different types of notification senders.

We have two low-level modules, EmailSender and SMSSender, which implement the INotificationSender interface. These modules represent the concrete implementations of the notification sender mechanisms.

The high-level module, NotificationService, depends on the INotificationSender abstraction. This service class encapsulates the notification logic and utilizes a notification sender to send messages.

By adhering to the Dependency Inversion Principle:

High-level modules (NotificationService) do not depend on low-level modules (EmailSender and SMSSender). Both depend on the common abstraction INotificationSender.
Abstractions (INotificationSender) do not depend on details (concrete sender classes). Instead, details depend on the abstraction.
This design promotes flexibility and modularity. We can easily add new types of notification senders without modifying the high-level NotificationService class,
and We can reuse the same NotificationService with different sender implementations.
 */