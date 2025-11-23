namespace ConsoleApp5;

public abstract record OperationResult
{
    private OperationResult() {}

    public sealed record SuccessStrResult(string Value) : OperationResult;

    public sealed record Failure(string Reason) : OperationResult;
}