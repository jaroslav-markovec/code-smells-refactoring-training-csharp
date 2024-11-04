using System.Net.Mail;

namespace BirthdayGreetingsKata;

public class BirthdayService
{
    private readonly IEmployeeRepository _employeeRepository;

    public BirthdayService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public void SendGreetings(string fileName, OurDate ourDate,
        string smtpHost, int smtpPort)
    {
        var employees = _employeeRepository.GetAll();

        foreach (var employee in employees)
        {
            if (employee.IsBirthday(ourDate))
            {
                var recipient = employee.Email;
                var body = "Happy Birthday, dear %NAME%!".Replace("%NAME%",
                    employee.FirstName);
                var subject = "Happy Birthday!";
                SendMessage(smtpHost, smtpPort, "sender@here.com", subject,
                    body, recipient);
            }
        }
    }
    

    private void SendMessage(string smtpHost, int smtpPort, string sender,
        string subject, string body, string recipient)
    {
        // Create a mail session
        var smtpClient = new SmtpClient(smtpHost)
        {
            Port = smtpPort
        };

        // Construct the message
        var msg = new MailMessage
        {
            From = new MailAddress(sender),
            Subject = subject,
            Body = body
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