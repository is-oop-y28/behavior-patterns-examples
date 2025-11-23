namespace ConsoleApp5.CoR.Handlers;

public class FinallyHandler : BaseHandler<int>
{
    protected override OperationResult HandleInternal(int request)
    {
        return new OperationResult.SuccessStrResult(request.ToString());
    }
}