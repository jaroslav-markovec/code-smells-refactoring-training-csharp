using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayGreetingsKata.Tests
{
    internal class DateHelper
    {
        internal static OurDate OurDate(string dateString)
        {
            var dateTime = ToDateTime(dateString);
            return new OurDate(dateTime);
        }

        internal static DateTime ToDateTime(string dateString)
        {
            return DateTime.ParseExact(dateString, "yyyy/MM/dd", null);
        }
    }
}
