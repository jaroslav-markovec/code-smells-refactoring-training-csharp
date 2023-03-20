using System;
using System.IO;
using System.Net.Mail;

namespace BirthdayGreetingsKata;

public class BirthdayService
{
     public void SendGreetings(String fileName, OurDate ourDate,
            String smtpHost, int smtpPort)
     {
         using StreamReader reader = new StreamReader(fileName);
         String str = "";
         str = reader.ReadLine(); // skip header
         while ((str = reader.ReadLine()) != null)
         {
             String[] employeeData = str.Split(", ");
             Employee employee = new Employee(employeeData[1], employeeData[0],
                 employeeData[2], employeeData[3]);
             if (employee.IsBirthday(ourDate)) {
                 String recipient = employee.Email;
                 String body = "Happy Birthday, dear %NAME%!".Replace("%NAME%",
                     employee.FirstName);
                 String subject = "Happy Birthday!";
                 SendMessage(smtpHost, smtpPort, "sender@here.com", subject,
                     body, recipient);
             } 
         }
     }

    private void SendMessage(String smtpHost, int smtpPort, String sender,
            String subject, String body, String recipient) {
        
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
    protected virtual void SendMessage(MailMessage msg, SmtpClient smtpClient) {
        smtpClient.Send(msg);
    }

    static void Main(String[] args) {
        BirthdayService service = new BirthdayService();
        try {
            service.SendGreetings("employee_data.txt",
                    new OurDate("2008/10/08"), "localhost", 25);
        } catch (Exception e) {
            Console.Write(e.StackTrace);
        }
    }
}