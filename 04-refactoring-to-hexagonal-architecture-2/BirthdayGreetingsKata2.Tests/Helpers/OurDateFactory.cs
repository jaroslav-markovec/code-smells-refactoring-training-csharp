using BirthdayGreetingsKata2.Core;
using BirthdayGreetingsKata2.Infrastructure.Repositories;

namespace BirthdayGreetingsKata2.Tests.helpers;

public static class OurDateFactory
{
    public static OurDate OurDateFromString(string dateAsString) {
        return new DateRepresentation(dateAsString).ToDate();
    }
}