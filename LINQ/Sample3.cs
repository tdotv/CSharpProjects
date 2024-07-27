using System.Collections;

// Select Enumerator

class Sample3
{
    public void F()
    {
        var arr = new int[] { 1, 20, 3, 70 };
        foreach (var item in new SelectEnumerable<int, string>(arr, x => "Hello! " + x.ToString()))
        {
            System.Console.WriteLine(item);
        }
    }
}

class SelectEnumerator<TIn, TOut> : IEnumerator<TOut>
{
    private readonly Func<TIn, TOut> _converter;
    private readonly IEnumerator<TIn> _enumerator;

    public SelectEnumerator(IEnumerable<TIn> enumerable, Func<TIn, TOut> converter)
    {
        _converter = converter;
        _enumerator = enumerable.GetEnumerator();
    }

    public TOut Current => _converter(_enumerator.Current);

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        _enumerator.MoveNext();
    }

    public void Reset()
    {
        _enumerator.Reset();
    }

}

class SelectEnumerable : IEnumerable<TOut>
{
    private readonly Func<TIn, TOut> _converter;
    private readonly IEnumerable<TIn> _enumerable;

    public SelectEnumerable(IEnumerable<TIn> enumerable, Func<TIn, TOut> converter)
    {
        _enumerable = enumerable;
        _converter = converter;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new SelectEnumerable<TIn, TOut>(_enumerable, _converter);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}