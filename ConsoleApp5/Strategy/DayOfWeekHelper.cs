namespace ConsoleApp5.Strategy;

public static class DayOfWeekHelper
{
    public static IDayOfWeekSelector FromMonday => new FromMondayDayOfWeekSelector();
    public static IDayOfWeekSelector FromSunday => new FromSundayDayOfWeekSelector();
}