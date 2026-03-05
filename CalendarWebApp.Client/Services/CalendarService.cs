using CalendarWebApp.Client.Models;
using CalendarWebApp.Client.Models.Enums;
using System.Globalization;

namespace CalendarWebApp.Client.Services
{
    public class CalendarService
    {
        private readonly HolidayService _holidayService = new();
        public CalendarMonth GenerateMonth(int year, int month)
        {
            var holidays = _holidayService.GetHolidays(year);

            var calendarMonth = new CalendarMonth
            {
                Year = year,
                Month = month
            };

            var firstOfMonth = new DateOnly(year, month, 1);
            var lastOfMonth = new DateOnly(year, month, DateTime.DaysInMonth(year, month));

            // Montag der ersten sichtbaren Woche berechnen
            var firstCalendarMonday = GetStartOfWeek(firstOfMonth);

            var currentDate = firstCalendarMonday;
            var IsInMonthOrWeek = true;
            while(IsInMonthOrWeek)
            {
                var week = CreateWeek(currentDate, month, holidays);
                calendarMonth.Weeks.Add(week);

                currentDate = currentDate.AddDays(7);

                // Abbruch: wenn die Woche komplett nach dem Monat liegt
                if (currentDate > lastOfMonth && currentDate.Month != month) 
                    IsInMonthOrWeek = false;
            }

            return calendarMonth;
        }

        private CalendarWeek CreateWeek(DateOnly firstDayOfWeek, int currentMonth, Dictionary<DateOnly, string> holidays)
        {
            var week = new CalendarWeek
            {
                WeekNumber = ISOWeek.GetWeekOfYear(firstDayOfWeek)
            };

            for(int i = 0; i < 7; i++)
            {
                var date = firstDayOfWeek.AddDays(i);

                week.Days.Add(CreateDay(
                    date,
                    date.Month == currentMonth,
                    holidays));
            }
            return week;
        }

        private CalendarDay CreateDay(
            DateOnly date,
            bool isCurrentMonth,
            Dictionary<DateOnly, string> holidays)
        {
            holidays.TryGetValue(date, out var holidayName);

            return new CalendarDay
            {
                Date = date,
                IsWeekend = date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday,
                IsHoliday = holidayName != null,
                HolidayName = holidayName,
                IsToday = date == DateOnly.FromDateTime(DateTime.Today),
                IsInCurrentMonth = isCurrentMonth
            };
        }

        private DateOnly GetStartOfWeek(DateOnly date)
        {
            int offset = ((int)date.DayOfWeek + 6) % 7;
            return date.AddDays(-offset);
        }
    }
}
