using System;

namespace BirthdayGreetingsKata;

public class OurDate
{
    private readonly DateTime date;


    public OurDate(String yyyyMMdd)
    {
        date = DateTime.ParseExact(yyyyMMdd, "yyyy/MM/dd", null);
    }

    public int GetDay()
    {
        return date.Day;
    }

    public int GetMonth()
    {
        return date.Month;
    }

    public Boolean IsSameDay(OurDate anotherDate)
    {
        return anotherDate.GetDay() == this.GetDay()
               && anotherDate.GetMonth() == this.GetMonth();
    }

    private bool Equals(OurDate other)
    {
        return date.Equals(other.date);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OurDate)obj);
    }

    public override int GetHashCode()
    {
        return date.GetHashCode();
    }
}