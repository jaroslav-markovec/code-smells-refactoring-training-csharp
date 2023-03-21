using BirthdayGreetingsKata2.Core;
using BirthdayGreetingsKata2.Infrastructure.Repositories;
using Xunit;
using static BirthdayGreetingsKata2.Tests.helpers.OurDateFactory;


namespace BirthdayGreetingsKata2.Tests.Infrastructure.Repositories;

public class FileEmployeeRepositoryTest
{
    private readonly OurDate _anyDate;

    public FileEmployeeRepositoryTest()
    {
        _anyDate = OurDateFromString("2016/01/01");
    }

    [Fact]
    public void fails_when_the_file_does_not_exist()
    {
        IEmployeesRepository employeesRepository = new FileEmployeesRepository("non-existing.file");

        CannotReadEmployeesException exception = 
            Assert.Throws<CannotReadEmployeesException>(() => employeesRepository.WhoseBirthdayIs(_anyDate));

        Assert.Contains("cannot loadFrom file", exception.Message);
        Assert.Contains("non-existing.file", exception.Message);
    }

    [Fact]
    public void fails_when_the_file_does_not_have_the_necessary_fields()
    {
        IEmployeesRepository employeesRepository =
            new FileEmployeesRepository("Infrastructure/Repositories/wrong_data__wrong-date-format.csv");

        CannotReadEmployeesException exception = 
            Assert.Throws<CannotReadEmployeesException>(() => employeesRepository.WhoseBirthdayIs(_anyDate));

        Assert.Contains("Badly formatted employee birth date in", exception.Message);
    }
}