namespace ConsoleApp5.Strategy;

public class FromSundayDayOfWeekSelector : IDayOfWeekSelector
{
    public ProcessPositionResult ProcessPosition(int position)
    {
        if (position == -1)
            return new ProcessPositionResult(6, true);
        
        var hasNextValue = position != 5;
        return new ProcessPositionResult(position == 6 ? 0 : position + 1, hasNextValue);
    }
}