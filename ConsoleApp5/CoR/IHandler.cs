namespace ConsoleApp5.CoR;

public interface IHandler<T>
{
    OperationResult Handle(T request);
    void SetNext(IHandler<T> next);
}