using NUnit.Framework;
using System;

namespace BirthdayGreetingsKata.Tests;

public class OurDateTest
{
    [Test]
    public void Is_Same_Date()
    {
        var ourDate = DateHelper.OurDate("1789/01/24");
        var sameDay = DateHelper.OurDate("2001/01/24");
        var notSameDay = DateHelper.OurDate("1789/01/25");
        var notSameMonth = DateHelper.OurDate("1789/02/25");

        Assert.That(ourDate.IsSameDay(sameDay), Is.True, "same");
        Assert.That(ourDate.IsSameDay(notSameDay), Is.False, "not same day");
        Assert.That(ourDate.IsSameDay(notSameMonth), Is.False, "not same month");
    }
   

    [Test]
    public void Equality()
    {
        var dateBase =  DateHelper.OurDate("2000/01/02");
        var same =  DateHelper.OurDate("2000/01/02");
        var different =  DateHelper.OurDate("2000/01/04");

        Assert.That(dateBase, Is.EqualTo(dateBase));
        Assert.That(dateBase, Is.EqualTo(same));
        Assert.That(dateBase, Is.Not.EqualTo(different));
    }
}