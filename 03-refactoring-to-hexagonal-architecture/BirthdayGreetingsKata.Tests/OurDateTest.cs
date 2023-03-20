using Xunit;

namespace BirthdayGreetingsKata.Tests;

public class OurDateTest
{
    [Fact]
    public void Getters()
    {
        OurDate ourDate = new OurDate("1789/01/24");
        Assert.Equal(1, ourDate.GetMonth());
        Assert.Equal(24, ourDate.GetDay());
    }

    [Fact]
    public void IsSameDate()
    {
        OurDate ourDate = new OurDate("1789/01/24");
        OurDate sameDay = new OurDate("2001/01/24");
        OurDate notSameDay = new OurDate("1789/01/25");
        OurDate notSameMonth = new OurDate("1789/02/25");

        Assert.True(ourDate.IsSameDay(sameDay), "same");
        Assert.False(ourDate.IsSameDay(notSameDay), "not same day");
        Assert.False(ourDate.IsSameDay(notSameMonth), "not same month");
    }

    [Fact]
    public void Equality()
    {
        OurDate dateBase = new OurDate("2000/01/02");
        OurDate same = new OurDate("2000/01/02");
        OurDate different = new OurDate("2000/01/04");

        Assert.Equal(dateBase, dateBase);
        Assert.Equal(dateBase, same);
        Assert.NotEqual(dateBase, different);
    }
}