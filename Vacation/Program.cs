using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vacation
{
    public class Solution
    {

       

        // stores days for each month
        private int[] daysPerMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        // stores months
        private String[] months = {"January", "February", "March", "April", "May",
            "June", "July", "August", "September", "October", "November", "December"};
        // stores days
        private String[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        private bool isLeapYear(int Y)
        {
            return Y % 4 == 0;
        }

        // getting the index of the day at a given da5y
        public int getDayIndex(String day)
        {
            for (int i = 0; i < days.Length; i += 1)
            {
                if (days[i].Equals(day))
                    return i;
            }
            return -1;
        }

        // getting the index of the month at a given month
        public int getMonthIndex(String month)
        {
            for (int i = 0; i < months.Length; i += 1)
            {
                if (months[i].Equals(month))
                    return i;
            }
            return -1;
        }

        // getting the day index provided the index of the first day of january, the index of the month,
        // and the day of that month
        public int getDayOfGivenMonth(String firstDayOfJanuary, int monthIndex, int day)
        {
            int firstDayIndex = getDayIndex(firstDayOfJanuary);
            int totalDays = 0;
            for (int i = 0; i < monthIndex; i += 1)
                totalDays += daysPerMonth[i];
            return (firstDayIndex + (totalDays - 1) % 7 + day) % 7;
        }

        /*
        Main driver function that gives how many weeks can john have vacation
        Y -> the year (always between 2001 and 2099)
        A -> starting month
        B -> ending month
        W -> the day on the January 1 of the year
         */
        public int solution(int Y, String A, String B, String W)
        {
            // we check if the year is leap year or not
            if (isLeapYear(Y))
            {
                daysPerMonth[1] = 29;
            }

            /*
            Now we need to calculate the total days between a vacation
             */

            // getting the index of the starting month
            int startingMonthIndex = getMonthIndex(A);
            // getting the index of the last month
            int endingMonthIndex = getMonthIndex(B);

            // if ending month is less than starting month return -1
            if (endingMonthIndex < startingMonthIndex)
                return -1;

            // else we calculate the total days within the month
            int totalDays = 0;
            for (int i = startingMonthIndex; i <= endingMonthIndex; i += 1)
            {
                totalDays += daysPerMonth[i];
            }

            // next we calculate the index first day of the starting month
            int firstDayOfTheMonth = getDayOfGivenMonth(W, startingMonthIndex, 1);
            // next we get the first monday of the starting month
            int nextMondayIndex = firstDayOfTheMonth + (7 - firstDayOfTheMonth) % 7;
            // we subtract the total days between first day and first monday from the total amount of days
            // calculated

            totalDays -= (nextMondayIndex - 1);

            // finally returning total number of weeks spent for vacation
            return totalDays / 7;
            
        }

        class Program
        {
            public static void Main(string[] args)
            {
                Solution solution = new Solution();
                Console.WriteLine(solution.solution(2014, "April", "August", "Wednesday"));
            }
        }
    }
}