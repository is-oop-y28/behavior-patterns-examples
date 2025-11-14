using System.Collections;
using ConsoleApp5.Observables;
using ConsoleApp5.Strategy;

public class Week : IEnumerable<string>, IMyObservable<string>
{
    private List<IMyObserver<string>> _observers = new();
    private IDayOfWeekSelector _dayOfWeekSelector = DayOfWeekHelper.FromMonday;
    private string[] _days = ["ПН", "ВТ", "СР", "ЧТ", "ПТ", "СБ", "ВС"];

    public IEnumerator<string> GetEnumerator()
    {
        return new WeekEnumerator(_days, _dayOfWeekSelector);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void SetFirstDayOfWeekSelector(IDayOfWeekSelector dayOfWeekSelector)
    {
        _dayOfWeekSelector = dayOfWeekSelector;
        var message = $"Неделя начнётся с {this.First()}";
        Notify(message);
    }

    public void Notify(string data)
    {
        foreach (var myObserver in _observers)
        {
            try
            {
                myObserver.ProcessEvent(data);
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }

    public void AddObserver(IMyObserver<string> observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IMyObserver<string> observer)
    {
        _observers.Remove(observer);
    }
}