using System.Collections.Generic;

namespace BirthdayGreetingsKata2.Core;

public interface IEmployeesRepository
{
    List<Employee> GetAll();
}