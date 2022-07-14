using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vacation
{
    public class Vacation
    {

        public int vacation(int year, string startMonth, string endMonth, string startDay)
        {
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] months = { "January", "February", "March",
                "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] weekDay = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            
            if (LeapYear(year))
            {
                days[1] = 29;
            }

            
            int minus = 0;
            for (int i = 0; i < weekDay.Length; i++)
            {
                if (weekDay[i] == startDay && i != 0)
                {
                    minus = i - 7;
                }
            }
            int daysNot = minus;
            bool start = false;
            int daysStart = 0;

            //Count Days for not in vacation and vacation duration
            for (int i = 0; i < months.Length; i++)
            {
                if (endMonth == months[i])
                {
                    daysStart += days[i];
                    break;
                }
                else if (start || startMonth == months[i])
                {
                    start = true;
                    daysStart += days[i];
                }
                else
                {
                    daysNot += days[i];
                }
            }

            //Takes the days not in vacation to detect any changes away from set day Monday
            int dayBeforeVacation = daysNot % 7;
            //If Not Monday
            if (dayBeforeVacation != 0)
            {
                dayBeforeVacation -= 7;
            }
            //remove excess days before monday.
            daysStart += dayBeforeVacation;

            //reset day for detecting Sunday. Add 1 back in at the end.
            daysStart -= 6;
            int weeks = (daysStart / 7); //Detects only number of sundays.
            return weeks + 1; // Add the week back in
        }
        public bool LeapYear(int year)
        {
            if (year % 4 == 0) return true;
            else return false;
        }


    }

        class Program
        {
            public static void Main(string[] args)
            {
                Vacation vacation = new Vacation();
                Console.WriteLine(vacation.vacation(2024, "April", "August", "Wednesday"));
            }
        }
    }


