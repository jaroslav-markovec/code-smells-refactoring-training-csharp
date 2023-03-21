using System.Collections.Generic;
using System.Linq;

namespace BirthdayGreetingsKata2.Core;

public class GreetingMessage
{
    private readonly string _to; 
    private readonly Greeting _greeting;

    private GreetingMessage(string to, Greeting greeting) {
        _to = to;
        _greeting = greeting;
    }

    public static List<GreetingMessage> GenerateForSome(List<Employee> employees)
    {
        return employees.Select(GenerateFor).ToList();
    }

    private static GreetingMessage GenerateFor(Employee employee) {
        Greeting greeting = Greeting.ForBirthdayOf(employee);
        string recipient = employee.Email;
        return new GreetingMessage(recipient, greeting);
    }

    public string Subject() {
        return _greeting.Header;
    }

    public string Text() {
        return _greeting.Content;
    }

    public string To()
    {
        return _to;
    }

}