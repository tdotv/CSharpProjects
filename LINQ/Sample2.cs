using System.Collections;

// Array Enumerator

class Sample2
{
    public void F()
    {
        var arr = new int[] { 1, 20, 3, 70 };
        foreach (var item in new WhereGreaterThanEnumerable(arr, 5))
        {
            System.Console.WriteLine(item);
        }
    }
}

class WhereGreaterThanEnumerable : IEnumerator<int>
{
    private int _n;
    private readonly IEnumerator <int> _enumerator;

    public WhereGreaterThanEnumerable(int n, <int> enumerable)
    {
        _n = n;
        _enumerator = enumerable.GetEnumerator();
    }

    public int Current => _enumerator.Current;

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        while (_enumerator.MoveNext())
        {
            if (_enumerator.Current > _n)
            {
                return true;   
            }
        }
    }

    public void Reset()
    {
        _enumerator.Reset();
    }

}

class WhereGreaterThanEnumerable : IEnumerable<int>
{
    private readonly int _n;
    private readonly IEnumerable<int> _enumerable;

    public WhereGreaterThanEnumerable(IEnumerable<int> enumerable, int n)
    {
        _enumerable = enumerable;
        _n = n;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new WhereGreaterThanEnumerable(_enumerable, _n);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}