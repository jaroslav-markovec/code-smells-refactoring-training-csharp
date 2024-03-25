using System;
using BirthdayGreetingsKata2.Core;
using BirthdayGreetingsKata2.Infrastructure.Repositories;
using NSubstitute;
using NUnit.Framework;
using static BirthdayGreetingsKata2.Tests.helpers.OurDateFactory;


namespace BirthdayGreetingsKata2.Tests.Infrastructure.Repositories;

public class FileEmployeeRepositoryTest
{
    private readonly OurDate _anyDate;

    public FileEmployeeRepositoryTest()
    {
        _anyDate = OurDateFromString("2016/01/01");
    }

    [Test]
    public void fails_when_the_file_does_not_exist()
    {
        IEmployeesRepository employeesRepository = new FileEmployeesRepository("non-existing.file");

        var exception = 
            Assert.Throws<CannotReadEmployeesException>(() => employeesRepository.WhoseBirthdayIs(_anyDate));

        Assert.That(exception, Has.Message.Contains("cannot loadFrom file"));
        Assert.That(exception, Has.Message.Contains("non-existing.file"));
    }

    [Test]
    public void fails_when_the_file_does_not_have_the_necessary_fields()
    {
        IEmployeesRepository employeesRepository =
            new FileEmployeesRepository("Infrastructure/Repositories/wrong_data__wrong-date-format.csv");

        var exception = 
            Assert.Throws<CannotReadEmployeesException>(() => employeesRepository.WhoseBirthdayIs(_anyDate));

        Assert.That(exception, Has.Message.Contains("Badly formatted employee birth date in"));
    }
}