namespace ConsoleApp5.CoR.Handlers;

public class FizzBuzzHandler : BaseHandler<int>
{
    protected override OperationResult HandleInternal(int request)
    {
        if (request % 3 == 0 && request % 5 == 0)
            return new OperationResult.SuccessStrResult("FizzBuzz");
        return new OperationResult.Failure("Not FizzBuzz");
    }
}