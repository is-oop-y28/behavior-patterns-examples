namespace ConsoleApp5.Strategy;

public interface IDayOfWeekSelector
{
    ProcessPositionResult ProcessPosition(int position);
}