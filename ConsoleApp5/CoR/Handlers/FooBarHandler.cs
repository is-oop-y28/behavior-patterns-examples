namespace ConsoleApp5.CoR.Handlers;

public class FooBarHandler : BaseHandler<int>
{
    protected override OperationResult HandleInternal(int request)
    {
        if (request % 3 == 0 && request % 5 == 0 && request % 2 == 0)
            return new OperationResult.SuccessStrResult("FooBar");
        return new OperationResult.Failure("Not FooBar");
    }
}