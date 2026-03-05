using CalendarWebApp.Client.Models.Enums;

namespace CalendarWebApp.Client.Models
{
    public class RecurrenceRule
    {
        public RecurrenceType Type { get; set; }
        public int Interval { get; set; } = 1; // z.B. alle 2 Wochen
        public  DateOnly? EndDate { get; set; }
    }
}
