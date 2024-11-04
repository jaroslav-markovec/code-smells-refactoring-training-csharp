using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayGreetingsKata
{
    public class FileEmployeeRepository : IEmployeeRepository
    {
        private readonly string _fileName;

        public FileEmployeeRepository(string fileName)
        {
            _fileName = fileName;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            using var reader = new StreamReader(_fileName);
            var str = "";
            str = reader.ReadLine(); // skip header
            while ((str = reader.ReadLine()) != null)
            {
                var employeeData = str.Split(", ");

                var birthDate =  DateTime.ParseExact(employeeData[2], "yyyy/MM/dd", null);

                var employee = new Employee(employeeData[1], employeeData[0],
                    birthDate, employeeData[3]);

                employees.Add(employee);
            }

            return employees;
        }
    }
}
