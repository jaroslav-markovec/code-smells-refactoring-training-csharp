using System;
using System.Collections.Generic;
using System.Net.Mail;
using BirthdayGreetingsKata2.Application;
using BirthdayGreetingsKata2.Core;
using BirthdayGreetingsKata2.Infrastructure.Repositories;
using Xunit;
using static BirthdayGreetingsKata2.Tests.helpers.OurDateFactory;

namespace BirthdayGreetingsKata2.Tests.Application;

public class AcceptanceTest
{
    private const int SmtpPort = 25;
    private const String SmtpHost = "localhost";
    private const String From = "sender@here.com";
    private readonly List<MailMessage> _messagesSent;
    private readonly BirthdayService _service;
    private const String EmployeesFilePath = "Application/employee_data.txt";

    private class BirthdayServiceForTesting : BirthdayService
    {
        private readonly List<MailMessage> _messages;

        public BirthdayServiceForTesting(List<MailMessage> messages, IEmployeesRepository employeesRepository) : base(
            employeesRepository)
        {
            _messages = messages;
        }

        protected override void SendMessage(MailMessage msg, SmtpClient smtpClient)
        {
            _messages.Add(msg);
        }
    }

    public AcceptanceTest()
    {
        _messagesSent = new List<MailMessage>();
        _service = new BirthdayServiceForTesting(_messagesSent, new FileEmployeesRepository(EmployeesFilePath));
    }

    [Fact]
    public void BaseScenario()
    {
        OurDate today = OurDateFromString("2008/10/08");

        _service.SendGreetings(today, SmtpHost, SmtpPort, From);

        Assert.Single(_messagesSent);
        MailMessage message = _messagesSent[0];
        Assert.Equal("Happy Birthday, dear John!", message.Body);
        Assert.Equal("Happy Birthday!", message.Subject);
        Assert.Single(message.To);
        Assert.Equal("john.doe@foobar.com", message.To[0].Address);
    }

    [Fact]
    public void WillNotSendEmailsWhenNobodysBirthday()
    {
        OurDate today = OurDateFromString("2008/01/01");

        _service.SendGreetings(today, SmtpHost, SmtpPort, From);

        Assert.Empty(_messagesSent);
    }
}