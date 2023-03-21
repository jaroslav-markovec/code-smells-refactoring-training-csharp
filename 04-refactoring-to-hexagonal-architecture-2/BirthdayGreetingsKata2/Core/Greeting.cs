using System;

namespace BirthdayGreetingsKata2.Core;

public class Greeting
{
    public string Header { get; }
    public string Content { get; }

    private Greeting(string header, string content) {
        Header = header;
        Content = content;
    }

    public static Greeting ForBirthdayOf(Employee employee){
        String content = $"Happy Birthday, dear {employee.FirstName}!";
        String header = "Happy Birthday!";
        return new Greeting(header, content);
    }

}