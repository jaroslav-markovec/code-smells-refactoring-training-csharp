using Xunit;

namespace BirthdayGreetingsKata.Tests;

public class EmployeeTest
{
    [Fact]
    public void TestBirthday()
    {
        var employee = new Employee("foo", "bar", "1990/01/31", "a@b.c");
        Assert.False(employee.IsBirthday(new OurDate("2008/01/30")),
            "not his birthday");
        Assert.True(employee.IsBirthday(new OurDate("2008/01/31")),
            "his birthday");
    }

    [Fact]
    public void Equality()
    {
        var employeeBase = new Employee("First", "Last", "1999/09/01",
            "first@last.com");
        var same = new Employee("First", "Last", "1999/09/01",
            "first@last.com");
        var different = new Employee("First", "Last", "1999/09/01",
            "boom@boom.com");

        Assert.True(employeeBase.Equals(same));
        Assert.False(employeeBase.Equals(different));
    }
}