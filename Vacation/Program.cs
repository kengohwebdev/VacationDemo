using System;



public class TripDetails
{

    public static void Main(String[] args)
    {

        Console.WriteLine(Solution.solution(2014, "April", "May", "Wednesday") + " weeks");

    }

}

class MyCalendar
{

    // To store numeric values

    private int day, month, year;

    private int dayOfYear; // it will be in range from 0 to 6 ( Signifying Sunday to Saturday

    private static int[] numDays = {

31,

28,

31,

30,

31,

30,

31,

31,

30,

31,

30,

31

};

    public MyCalendar(int dayOfYear, int year)
    {

        day = 1;

        month = 0; // January

        this.year = year;

        this.dayOfYear = dayOfYear;

    }

    // check if a year is leap year or not

    private static bool isLeapYear(int year)
    {

        return ((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0);

    }

    private static int getDays(int month, int year)
    {

        if (isLeapYear(year) && month == 1)
        { // Feb

            return numDays[month] + 1;

        }
        else
        {

            return numDays[month];

        }

    }

    public void advance()
    {

        dayOfYear = (dayOfYear + 1) % 7;

        day++;

        int maxDaysInMonth = getDays(month, year);

        // if it was last day of month, then increment the month

        if (day > maxDaysInMonth)
        {

            day = 1;

            month++;

            // if it was 31st december, we need to change year also

            if (month > 12)
            {

                month = 0;

                year++;

            }

        }

    }

    public int getMonthIndex()
    {

        return month;

    }

    public int getDayOfMonthIndex()
    {

        return dayOfYear;

    }

    public override String ToString()
    {

        return "MyCalendar [\nday: " + day + "\nmonth: " + month + "\nyear: " + year + "\ndayOfYear: " + dayOfYear +

        "]";

    }

}

class Solution
{

    private static String[] Months = {

"January",

"February",

"March",

"April",

"May",

"June",

"July",

"August",

"September",

"October",

"November",

"December"

};

    private static String[] days = {

"Sunday",

"Monday",

"Tuesday",

"Wednesday",

"Thursday",

"Friday",

"Saturday"

};

    public static int solution(int year, String beginningMonth,

    String endMonth, String startDayOfYear)
    {

        MyCalendar calendar = new MyCalendar(Array.IndexOf(days, startDayOfYear), year);

        int startMonthIndex = Array.IndexOf(Months, beginningMonth);

        int endMonthIndex = Array.IndexOf(Months, endMonth);

        // Reach to the date on which journey will start

        while ((calendar.getMonthIndex() != startMonthIndex) ||

        (!String.Equals(days[calendar.getDayOfMonthIndex()].ToLower(), "monday")))
        {

            calendar.advance();

        }

        int numDaysSpent = 0;

        while (calendar.getMonthIndex() <= endMonthIndex)
        {

            numDaysSpent++;

            calendar.advance();

        }

        // We can divide the days spent by 7 to get weeks

        return numDaysSpent / 7;

    }

}


