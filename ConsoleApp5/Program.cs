// See https://aka.ms/new-console-template for more information

using System.Globalization;
using ConsoleApp5;
using ConsoleApp5.Observables;
using ConsoleApp5.Strategy;

internal class Program
{
    public static void Main(string[] args)
    {
        var week = new Week();
        week.AddObserver(new FaultingObserver());
        week.AddObserver(new FlushToConsoleObserver());
        foreach (var dayOfWeek in week)
        {
            Console.Write($"{dayOfWeek}, ");
        }
        Console.WriteLine();
        week.SetFirstDayOfWeekSelector(DayOfWeekHelper.FromSunday);
        foreach (var dayOfWeek in week)
        {
            Console.Write($"{dayOfWeek}, ");
        }
    }
}