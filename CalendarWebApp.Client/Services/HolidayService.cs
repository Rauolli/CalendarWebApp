namespace CalendarWebApp.Client.Services
{
    public class HolidayService
    {
        public DateOnly GetEasterSunday(int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;

            int month = (h + l - 7 * m + 114) / 31;
            int day = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateOnly(year, month, day);
        }

        public Dictionary<DateOnly, string> GetHolidays(int year)
        {
            var holidays = new Dictionary<DateOnly, string>();

            // Feste Feiertage
            holidays[new DateOnly(year, 1, 1)] = "Neujahr";
            holidays[new DateOnly(year, 5, 1)] = "Tag der Arbeit";
            holidays[new DateOnly(year, 10, 3)] = "Tag der Deutschen Einheit";
            holidays[new DateOnly(year, 12, 25)] = "1. Weihnachtstag";
            holidays[new DateOnly(year, 12, 26)] = "2. Weihnachtstag";

            // Bewegliche Feiertage
            var easter = GetEasterSunday(year);

            holidays[easter.AddDays(-48)] = "Rosenmontag";
            holidays[easter.AddDays(-2)] = "Karfreitag";
            holidays[easter] = "Ostersonntag";
            holidays[easter.AddDays(1)] = "Ostermontag";
            holidays[easter.AddDays(39)] = "Christi Himmelfahrt";
            holidays[easter.AddDays(49)] = "Pfingstsonntag";
            holidays[easter.AddDays(50)] = "Pfingstmontag";
            holidays[easter.AddDays(60)] = "Fronleichnam";

            return holidays;
        }
    }
}
