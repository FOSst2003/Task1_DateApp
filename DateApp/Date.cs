using System;

namespace DateApp
{
    public class Date
    {
        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }

        public Date(int day, int month, int year)
        {
            if (!IsValid(year, month, day))
                throw new ArgumentException("Invalid date");

            Day = day;
            Month = month;
            Year = year;
            UpdateDayOfWeek();
        }

        private void UpdateDayOfWeek()
        {
            DateTime dt = new DateTime(Year, Month, Day);
            var dotNetDay = dt.DayOfWeek;
            DayOfWeek = (DayOfWeek)(((int)dotNetDay + 6) % 7);
        }

        public static bool IsValid(int year, int month, int day)
        {
            if (year < 1 || year > 9999)
                return false;

            if (month < 1 || month > 12)
                return false;

            if (day < 1)
                return false;

            int daysInMonth = GetDaysInMonth(month, year);
            return day <= daysInMonth;
        }

        public static int GetDaysInMonth(int month, int year)
        {
            if (month < 1 || month > 12)
                throw new ArgumentException("Invalid month");

            if (month == 2)
                return IsLeapYear(year) ? 29 : 28;
            else if (new[] { 4, 6, 9, 11 }.Contains(month))
                return 30;
            else
                return 31;
        }

        private static bool IsLeapYear(int year) =>
            year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);

        public void AddDays(int days)
        {
            DateTime dt = new DateTime(Year, Month, Day);
            dt = dt.AddDays(days);
            Year = dt.Year;
            Month = dt.Month;
            Day = dt.Day;
            UpdateDayOfWeek();
        }

        public void AddMonths(int months)
        {
            DateTime dt = new DateTime(Year, Month, Day);
            dt = dt.AddMonths(months);
            Year = dt.Year;
            Month = dt.Month;
            Day = dt.Day;
            UpdateDayOfWeek();
        }

        public void AddYears(int years)
        {
            DateTime dt = new DateTime(Year, Month, Day);
            dt = dt.AddYears(years);
            Year = dt.Year;
            Month = dt.Month;
            Day = dt.Day;
            UpdateDayOfWeek();
        }
    }
}