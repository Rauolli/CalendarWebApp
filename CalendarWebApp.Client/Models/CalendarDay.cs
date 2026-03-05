namespace CalendarWebApp.Client.Models
{
    public class CalendarDay
    {
        public DateOnly Date { get; set; }

        public bool IsWeekend { get; set; }
        public bool IsHoliday { get; set; }
        public string? HolidayName { get; set; }

        public bool IsToday { get; set; }
        public bool IsInCurrentMonth { get; set; }

        public List<Appointment> Appointments { get; set; } = [];

    }
}
