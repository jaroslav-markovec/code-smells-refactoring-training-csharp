using System;
using System.Collections.Generic;
using System.Linq;
using BirthdayGreetingsKata2.Core;

namespace BirthdayGreetingsKata2.Infrastructure.Repositories;

public class FileEmployeesRepository : IEmployeesRepository
{
    private readonly String _path;

    public FileEmployeesRepository(String path)
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
        EmployeesFile employeesFile = EmployeesFile.LoadFrom(_path);
        return employeesFile.ExtractEmployees();
    }
}