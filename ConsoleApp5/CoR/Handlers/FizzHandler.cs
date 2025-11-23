namespace ConsoleApp5.CoR.Handlers;

public class FizzHandler : BaseHandler<int>
{
    protected override OperationResult HandleInternal(int request)
    {
        if (request % 3 == 0 && request % 5 != 0)
            return new OperationResult.SuccessStrResult("Fizz");
        return new OperationResult.Failure("Not Fizz");
    }
}