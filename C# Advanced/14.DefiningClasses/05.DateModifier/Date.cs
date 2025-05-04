using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses;
internal class Date
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }

    public Date(string date)
    {
        string[] info = date.Split();
        Year = int.Parse(info[0]);
        Month = int.Parse(info[1]);
        Day = int.Parse(info[2]);
    }

    public bool EarlierThan(Date date)
    {
        if (this.Year < date.Year)
        {
            return true;
        }
        if (this.Year == date.Year)
        {
            if (this.Month < date.Month)
            {
                return true;
            }
            if (this.Month == date.Month)
            {
                if (this.Day < date.Day)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void AddDay()
    {
        if (Month == 1 ||
            Month == 3 ||
            Month == 5 ||
            Month == 7 ||
            Month == 8 ||
            Month == 10 ||
            Month == 12)
        {
            if (Day == 31)
            {
                Day = 1;
                Month++;
                if (Month == 13)
                {
                    Month = 1;
                    Year++;
                }
            }
            else
            {
                Day++;
            }
            return;
        }
        if (Month == 4 ||
            Month == 6 ||
            Month == 9 ||
            Month == 11)
        {
            if (Day == 30)
            {
                Day = 1;
                Month++;
            }
            else
            {
                Day++;
            }
            return;
        }
        bool leap = (Year % 4 == 0) &&
            ((Year % 100 != 0) || (Year % 400 == 0));
        if (Day < 28 + (leap ? 1 : 0))
        {
            Day++;
        }
        else
        {
            Day = 1;
            Month = 3;
        }
    }

    public bool Equals(Date date)
    {
        return this.Year == date.Year && this.Month == date.Month && this.Day == date.Day;
    }
}
