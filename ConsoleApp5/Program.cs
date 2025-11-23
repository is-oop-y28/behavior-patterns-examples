using ConsoleApp5.Command;
using ConsoleApp5.CoR;
using ConsoleApp5.CoR.Handlers;
using ConsoleApp5.Observables;
using ConsoleApp5.Strategy;

namespace ConsoleApp5;

internal static class Program
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
        
        // ---- 
        
        IHandler<int>[] handlers =
        [
            new FooBarHandler(),
            new FizzBuzzHandler(),
            new FizzHandler(),
            new BuzzHandler(),
            new FinallyHandler()
        ];
        var root = handlers.Aggregate((acc, next) =>
        {
            acc.SetNext(next);
            return acc;
        });
        
        var ctx = new Context();
        var flushCmd = new FlushResultToConsoleCommand(ctx);
        var resolveCmd = new SolveFuzzBuzzTaskCommand(ctx, root);
        var array = Enumerable.Range(1, 30).ToArray();
        foreach (var i in array)
        {
            resolveCmd.Execute(i);
            flushCmd.Execute();
            // if (i == 29) flushCmd.Revert();
        }
    }
}