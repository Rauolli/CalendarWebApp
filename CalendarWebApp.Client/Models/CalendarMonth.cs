using System.Globalization;

namespace CalendarWebApp.Client.Models
{
    public class CalendarMonth
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public List<CalendarWeek> Weeks { get; set; } = [];

        public string MonthName => new DateOnly(Year, Month, 1).ToString("MMMM", CultureInfo.GetCultureInfo("de-DE"));
    }
}
