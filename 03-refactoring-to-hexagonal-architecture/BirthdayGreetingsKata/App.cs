using System;

namespace BirthdayGreetingsKata
{
    public class App
    {

        static void Main(string[] args)
        {
            var employeeFileName = "employee_data.txt";
            IEmployeeRepository employeeRepository = new FileEmployeeRepository(employeeFileName);

            var service = new BirthdayService(employeeRepository);

            try
            {
                var dateTime = DateTime.ParseExact("2008/10/08", "yyyy/MM/dd", null);
                service.SendGreetings(employeeFileName,
                    new OurDate(dateTime), "localhost", 25);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }

    }
}
