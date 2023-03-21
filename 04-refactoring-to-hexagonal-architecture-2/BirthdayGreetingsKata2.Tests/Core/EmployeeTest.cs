using BirthdayGreetingsKata2.Core;
using Xunit;
using static BirthdayGreetingsKata2.Tests.helpers.OurDateFactory;

namespace BirthdayGreetingsKata2.Tests.Core;

public class EmployeeTest
{
    [Fact]
    public void TestBirthday()
    {
        Employee employee = new Employee("foo", "bar", OurDateFromString("1990/01/31"), "a@b.c");

        Assert.False(employee.IsBirthday(OurDateFromString("2008/01/30")), "no birthday");
        Assert.True(employee.IsBirthday(OurDateFromString("2008/01/31")), "birthday");
    }
}