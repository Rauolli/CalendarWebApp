using CalendarWebApp.Client.Models.Enums;

namespace CalendarWebApp.Client.Models
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

        public bool IsAllDay { get; set; }

        public AppointmentCategory Category { get; set; } = AppointmentCategory.Default;
        public RecurrenceRule? Recurrence { get; set; } // Wiederholungen (täglich, wöchentlich, ...)  des Termins

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatetAt { get; set; }
    }
}