using System.Collections;

// Infinite Enumerables

class Sample5
{
    public void F()
    {
        var range = new RangeEnumerable(10, 200_000_000);   // Это ленивые вычисления: мы еще не перебрали эту коллекцию, но можем с ней взаимодействовать
        var withAppliedWhere = new WhereGreaterThanEnumerable(range, 5);
        var multiplied = new SelectEnumerable<int, int>(withAppliedWhere, x => x * 2);
        int x = 0;
        foreach (var item in multiplied)
        {
            x++;
            System.Console.WriteLine(item);
            if (x > 20)
            {
                break;
            }
        }
    }
}

class RangeEnumerator : IEnumerator<int>
{
    private int _current;
    private readonly int _from, _to;

    public int Current => _current;

    object IEnumerator.Current => Current;

    public RangeEnumerator(int from, int to)
    {
        _current = from - 1;
        _from = from;
        _to = to;
    }

    public bool MoveNext()
    {
        return ++_current < _to;
    }

    public void Reset()
    {
        _current = _from;
    }

    public void Dispose()
    {

    }
}

class RangeEnumerable
{
    
}