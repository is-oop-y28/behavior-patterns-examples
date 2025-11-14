namespace ConsoleApp5.Observables;

public class FlushToConsoleObserver : IMyObserver<string>
{
    public void ProcessEvent(string data)
    {
        Console.WriteLine(data);
    }
}