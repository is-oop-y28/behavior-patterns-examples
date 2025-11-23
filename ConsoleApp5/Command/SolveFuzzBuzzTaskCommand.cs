using ConsoleApp5.CoR;

namespace ConsoleApp5.Command;

public class SolveFuzzBuzzTaskCommand : ICommand<int>
{
    private readonly Context _context;
    private readonly IHandler<int> _fizzBuzzHandler;

    public SolveFuzzBuzzTaskCommand(Context context, IHandler<int> fizzBuzzHandler)
    {
        _context = context;
        _fizzBuzzHandler = fizzBuzzHandler;
    }

    public void Execute(int request)
    {
        _context.LastResult = _fizzBuzzHandler.Handle(request);
    }

    public void Revert()
    {
    }
}