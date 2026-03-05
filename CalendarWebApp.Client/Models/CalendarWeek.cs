namespace CalendarWebApp.Client.Models
{
    public class CalendarWeek
    {
        public int WeekNumber { get; set; }
        public List<CalendarDay> Days { get; set; } = [];
    }
}
