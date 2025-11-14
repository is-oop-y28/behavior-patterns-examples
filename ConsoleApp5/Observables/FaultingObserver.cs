namespace ConsoleApp5.Observables;

public class FaultingObserver : IMyObserver<object>
{
    public void ProcessEvent(object data)
    {
        throw new InvalidOperationException("Сбой делает бррр...");
    }
}