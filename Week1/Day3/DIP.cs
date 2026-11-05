
using System;

// BAD APPROACH: Notifier directly depends on EmailService

public class EmailService
{
    public void SendEmail(string message)
    {
        Console.WriteLine("Sending Email: " + message);
    }
}

public class Notifier
{
    private EmailService _emailService = new EmailService();

    public void Notify(string message)
    {
        _emailService.SendEmail(message);
    }
}

// GOOD APPROACH: Depend on an interface

public interface IMessageService
{
    void SendMessage(string message);
}

public class EmailServiceGood : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine("Sending Email: " + message);
    }
}

public class SmsService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine("Sending SMS: " + message);
    }
}

public class NotifierGood
{
    private readonly IMessageService _messageService;

    public NotifierGood(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Notify(string message)
    {
        _messageService.SendMessage(message);
    }
}

// MAIN PROGRAM

public class Program
{
    public static void Main()
    {
        Console.WriteLine("BAD APPROACH");

        Notifier notifier = new Notifier();
        notifier.Notify("Hello World!");

        Console.WriteLine();

        Console.WriteLine("GOOD APPROACH (DIP)");

        // Using Email Service
        IMessageService email = new EmailServiceGood();
        NotifierGood emailNotifier = new NotifierGood(email);
        emailNotifier.Notify("Hello World!");

        // Using SMS Service
        IMessageService sms = new SmsService();
        NotifierGood smsNotifier = new NotifierGood(sms);
        smsNotifier.Notify("Hello World!");
    }
}
