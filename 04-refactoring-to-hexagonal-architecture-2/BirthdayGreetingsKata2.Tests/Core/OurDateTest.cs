using NUnit.Framework;
using static BirthdayGreetingsKata2.Tests.helpers.OurDateFactory;

namespace BirthdayGreetingsKata2.Tests.Core;

public class OurDateTest
{
    [Test]
    public void identifies_if_two_dates_were_in_the_same_day()
    {
        var ourDate = OurDateFromString("1789/01/24");
        var sameDay = OurDateFromString("2001/01/24");
        var notSameDay = OurDateFromString("1789/01/25");
        var notSameMonth = OurDateFromString("1789/02/25");

        Assert.That(ourDate.IsSameDay(sameDay), Is.True, "same");
        Assert.That(ourDate.IsSameDay(notSameDay), Is.False, "not same day");
        Assert.That(ourDate.IsSameDay(notSameMonth), Is.False, "not same month");
    }
}