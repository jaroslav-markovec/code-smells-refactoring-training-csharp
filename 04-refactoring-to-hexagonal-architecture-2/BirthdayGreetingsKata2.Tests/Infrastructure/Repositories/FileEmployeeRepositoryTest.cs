using BirthdayGreetingsKata2.Core;
using BirthdayGreetingsKata2.Infrastructure.Repositories;
using NUnit.Framework;
using static BirthdayGreetingsKata2.Tests.helpers.OurDateFactory;


namespace BirthdayGreetingsKata2.Tests.Infrastructure.Repositories;

public class FileEmployeeRepositoryTest
{
    [Test]
    public void Fails_When_The_File_Does_Not_Exist()
    {
        IEmployeesRepository employeesRepository = new FileEmployeesRepository("non-existing.file");

        var exception = 
            Assert.Throws<CannotReadEmployeesException>(() => employeesRepository.GetAll());

        Assert.That(exception, Has.Message.Contains("cannot loadFrom file"));
        Assert.That(exception, Has.Message.Contains("non-existing.file"));
    }

    [Test]
    public void Fails_When_The_File_Does_Not_Have_The_Necessary_Fields()
    {
        IEmployeesRepository employeesRepository =
            new FileEmployeesRepository("Infrastructure/Repositories/wrong_data__wrong-date-format.csv");

        var exception = 
            Assert.Throws<CannotReadEmployeesException>(() => employeesRepository.GetAll());

        Assert.That(exception, Has.Message.Contains("Badly formatted employee birth date in"));
    }
}