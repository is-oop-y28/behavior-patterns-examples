namespace ConsoleApp5.Command;

public interface ICommand
{
    void Execute();

    void Revert();
}

public interface ICommand<T>
{
    void Execute(T request);
    
    // todo: isp
    void Revert();
}