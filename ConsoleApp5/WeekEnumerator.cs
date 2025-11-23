using System.Collections;
using ConsoleApp5.Strategy;

namespace ConsoleApp5;

public class WeekEnumerator : IEnumerator<string>
{
    private readonly string[] _days;
    private readonly IDayOfWeekSelector _dayOfWeekSelector;
    private int _position;

    public WeekEnumerator(string[] days, IDayOfWeekSelector dayOfWeekSelector)
    {
        _days = days;
        _dayOfWeekSelector = dayOfWeekSelector;
        _position = -1;
    }

    public bool MoveNext()
    {
        var result = _dayOfWeekSelector.ProcessPosition(_position);
        _position = result.Position;
        return result.HasNextValue;
    }

    public void Reset() => throw new NotSupportedException();

    string IEnumerator<string>.Current
    {
        get
        {
            if (_position == -1 || _position > 7)
            {
                throw new InvalidOperationException("The enumerator has not started or already finished.");
            }

            return _days[_position];
        }
    }

    object? IEnumerator.Current
    {
        get
        {
            if (_position == -1 || _position > 7)
            {
                throw new InvalidOperationException("The enumerator has not started or already finished.");
            }

            return _days[_position];
        }
    }

    public void Dispose()
    {
    }
}