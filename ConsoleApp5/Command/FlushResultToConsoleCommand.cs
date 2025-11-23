namespace ConsoleApp5.Command;

public class FlushResultToConsoleCommand : ICommand
{
    private readonly Context _context;
    private bool? _reverted = null;
        
    public FlushResultToConsoleCommand(Context context)
    {
        _context = context;
    }

    public void Execute()
    {
        _reverted = false;
        var result = _context.LastResult;
        switch (result)
        {
            case null:
                Console.Error.WriteLine("Result was not set");
                break;
            case OperationResult.SuccessStrResult strResult:
                Console.WriteLine(strResult.Value);
                break;
            case OperationResult.Failure failureResult:
                Console.Error.WriteLine(failureResult.Reason);
                break;
            default:
                throw new NotSupportedException($"Result type of {result.GetType().Name} is not supported");
        }
    }

    public void Revert()
    {
        if (!_reverted.HasValue)
            throw new InvalidOperationException("You cannot revert command which was not executed");
        _reverted = true;
        Console.Clear();
    }
}