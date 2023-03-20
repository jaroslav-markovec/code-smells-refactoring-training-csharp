using System.Collections.Generic;
using System.Net.Mail;
using Xunit;

namespace BirthdayGreetingsKata.Tests;

public class AcceptanceTest
{
    private const int SmtpPort = 25;
    private readonly List<MailMessage> _messagesSent;
    private readonly BirthdayService _service;

    private class BirthdayServiceForTesting : BirthdayService
    {
        private readonly List<MailMessage> _messages;
        public BirthdayServiceForTesting(List<MailMessage> messages)
        {
            _messages= messages;
        }

        protected override void SendMessage(MailMessage msg, SmtpClient smtpClient)
        {
           _messages.Add(msg);  
        }
    }

    public AcceptanceTest()
    {
        _messagesSent = new List<MailMessage>();
        _service = new BirthdayServiceForTesting(_messagesSent);
    }

    [Fact]
    public void BaseScenario()
    {
        _service.SendGreetings("employee_data.txt",
            new OurDate("2008/10/08"), "localhost", SmtpPort);

        Assert.Equal(1, _messagesSent.Count);
        MailMessage message = _messagesSent[0];
        Assert.Equal("Happy Birthday, dear John!", message.Body);
        Assert.Equal("Happy Birthday!", message.Subject);
        Assert.Single(message.To);
        Assert.Equal("john.doe@foobar.com", message.To[0].Address);
    }

    [Fact]
    public void willNotSendEmailsWhenNobodysBirthday()
    {
        _service.SendGreetings("employee_data.txt",
            new OurDate("2008/01/01"), "localhost", SmtpPort);

        Assert.Equal(0, _messagesSent.Count);
    }
}