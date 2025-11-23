namespace ConsoleApp5.CoR;

public abstract class BaseHandler<T> : IHandler<T>
{
    private IHandler<T>? _next = null;
    
    public OperationResult Handle(T request)
    {
        var internalResult = HandleInternal(request);
        if (internalResult is not OperationResult.Failure)
            return internalResult;
        return _next?.Handle(request) 
               ?? new OperationResult.Failure("No more handlers to resolve request");
    }

    public void SetNext(IHandler<T> next)
    {
        if (_next == null)
            _next = next;
        else 
            _next.SetNext(next);
    }
    
    protected abstract OperationResult HandleInternal(T request);
}