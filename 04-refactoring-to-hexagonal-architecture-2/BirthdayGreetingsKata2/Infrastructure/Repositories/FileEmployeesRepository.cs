using System.Collections.Generic;
using System.Linq;
using BirthdayGreetingsKata2.Core;

namespace BirthdayGreetingsKata2.Infrastructure.Repositories;

public class FileEmployeesRepository : IEmployeesRepository
{
    private readonly string _path;

    public FileEmployeesRepository(string path)
    {
        _path = path;
    }

    public List<Employee> WhoseBirthdayIs(OurDate today)
    {
        return AllEmployees()
            .FindAll(employee => employee.IsBirthday(today))
            .ToList();
    }

    private List<Employee> AllEmployees()
    {
        var employeesFile = EmployeesFile.LoadFrom(_path);
        return employeesFile.ExtractEmployees();
    }
}