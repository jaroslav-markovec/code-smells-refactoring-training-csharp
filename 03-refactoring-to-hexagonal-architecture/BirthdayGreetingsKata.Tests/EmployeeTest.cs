using NUnit.Framework;

namespace BirthdayGreetingsKata.Tests;

public class EmployeeTest
{
    [Test]
    public void TestBirthday()
    {
        var employee = new Employee("foo", "bar", "1990/01/31", "a@b.c");
        Assert.That(employee.IsBirthday(new OurDate("2008/01/30")),
            Is.False,
            "not his birthday");
        Assert.That(employee.IsBirthday(new OurDate("2008/01/31")),
            Is.True,
            "his birthday");
    }

    [Test]
    public void Equality()
    {
        var employeeBase = new Employee("First", "Last", "1999/09/01",
            "first@last.com");
        var same = new Employee("First", "Last", "1999/09/01",
            "first@last.com");
        var different = new Employee("First", "Last", "1999/09/01",
            "boom@boom.com");

        Assert.That(employeeBase.Equals(same), Is.True);
        Assert.That(employeeBase.Equals(different), Is.False);
    }
}