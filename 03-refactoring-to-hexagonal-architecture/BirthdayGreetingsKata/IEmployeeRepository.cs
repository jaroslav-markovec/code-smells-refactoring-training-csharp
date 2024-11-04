using System.Collections.Generic;

namespace BirthdayGreetingsKata;

public interface IEmployeeRepository
{
    List<Employee> GetAll();
}       