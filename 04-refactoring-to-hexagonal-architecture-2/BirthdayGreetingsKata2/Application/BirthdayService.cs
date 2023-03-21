using System;
using System.Collections.Generic;
using System.Net.Mail;
using BirthdayGreetingsKata2.Core;

namespace BirthdayGreetingsKata2.Application;

public class BirthdayService
{
    private readonly IEmployeesRepository _employeesRepository;

    public BirthdayService(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public void SendGreetings(OurDate date, String smtpHost, int smtpPort, String sender)
    {
        Send(GreetingMessagesFor(EmployeesHavingBirthday(date)),
            smtpHost, smtpPort, sender);
    }

    private static List<GreetingMessage> GreetingMessagesFor(List<Employee> employees)
    {
        return GreetingMessage.GenerateForSome(employees);
    }

    private List<Employee> EmployeesHavingBirthday(OurDate today)
    {
        return _employeesRepository.WhoseBirthdayIs(today);
    }

    private void Send(List<GreetingMessage> messages, String smtpHost, int smtpPort, String sender)
    {
        foreach (var message in messages)
        {
            String recipient = message.To();
            String body = message.Text();
            String subject = message.Subject();
            SendMessage(smtpHost, smtpPort, sender, subject, body, recipient);
        }
    }

    private void SendMessage(String smtpHost, int smtpPort, String sender,
        String subject, String body, String recipient)
    {
        // Create a mail session
        var smtpClient = new SmtpClient(smtpHost)
        {
            Port = smtpPort,
        };

        // Construct the message
        var msg = new MailMessage
        {
            From = new MailAddress(sender),
            Subject = subject,
            Body = body,
        };
        msg.To.Add(recipient);

        // Send the message
        SendMessage(msg, smtpClient);
    }

    // made protected for testing :-(
    protected virtual void SendMessage(MailMessage msg, SmtpClient smtpClient)
    {
        smtpClient.Send(msg);
    }
}