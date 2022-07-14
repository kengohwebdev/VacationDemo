using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vacation
{
    public class Vacation
    {

       

        private int[] daysPerMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
   
        private String[] months = {"January", "February", "March", "April", "May",
            "June", "July", "August", "September", "October", "November", "December"};
    
        private String[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        private bool isLeapYear(int Y)
        {
            return Y % 4 == 0;
        }

   
        public int getDayIndex(String day)
        {
            for (int i = 0; i < days.Length; i += 1)
            {
                if (days[i].Equals(day))
                    return i;
            }
            return -1;
        }


        public int getMonthIndex(String month)
        {
            for (int i = 0; i < months.Length; i += 1)
            {
                if (months[i].Equals(month))
                    return i;
            }
            return -1;
        }

 
        public int getDayOfGivenMonth(String firstDayOfJanuary, int monthIndex, int day)
        {
            int firstDayIndex = getDayIndex(firstDayOfJanuary);
            int totalDays = 0;
            for (int i = 0; i < monthIndex; i += 1)
                totalDays += daysPerMonth[i];
            return (firstDayIndex + (totalDays - 1) % 7 + day) % 7;
        }

    
        public int vacation(int year, String begin_Month, String end_Month, String DayOne)
        {
      
            if (isLeapYear(year))
            {
                daysPerMonth[1] = 29;
            }


            int startingMonthIndex = getMonthIndex(begin_Month);
 
            int endingMonthIndex = getMonthIndex(end_Month);


            if (endingMonthIndex < startingMonthIndex)
                return -1;

            int totalDays = 0;
            for (int i = startingMonthIndex; i <= endingMonthIndex; i += 1)
            {
                totalDays += daysPerMonth[i];
            }


            int firstDayOfTheMonth = getDayOfGivenMonth(DayOne, startingMonthIndex, 1);
      
            int nextMondayIndex = firstDayOfTheMonth + (7 - firstDayOfTheMonth) % 7;
            

            totalDays -= (nextMondayIndex - 1);

            
            return totalDays / 7;
            
        }

        class Program
        {
            public static void Main(string[] args)
            {
                Vacation vacation = new Vacation();
                Console.WriteLine(Vacation.vacation(2022, "August", "September", "Thursday"));
            }
        }
    }
}
