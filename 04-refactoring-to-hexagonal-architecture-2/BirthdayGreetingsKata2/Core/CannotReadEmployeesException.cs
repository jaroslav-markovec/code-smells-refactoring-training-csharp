using System;

namespace BirthdayGreetingsKata2.Core;

public class CannotReadEmployeesException : Exception
{
    public CannotReadEmployeesException(String cause, Exception exception) : base(cause, exception) { } 
}