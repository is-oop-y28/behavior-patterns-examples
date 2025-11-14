namespace ConsoleApp5.Strategy;

public class FromMondayDayOfWeekSelector : IDayOfWeekSelector
{
    public ProcessPositionResult ProcessPosition(int position)
    {
        var hasNextValue = position < 6;
        return new ProcessPositionResult(position + 1, hasNextValue);
    }
}