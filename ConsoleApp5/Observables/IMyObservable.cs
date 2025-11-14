namespace ConsoleApp5.Observables;

public interface IMyObservable<T>
{
    void Notify(T data);
    void AddObserver(IMyObserver<T> observer);
    void RemoveObserver(IMyObserver<T> observer);
}

public interface IMyObserver<in T>
{
    void ProcessEvent(T data);
}