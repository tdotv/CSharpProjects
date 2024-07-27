using System.Collections;

// Array Enumerator

class Sample1
{
    public void F()
    {
        var arr = new int[] { 1, 2, 3 };
        foreach (var item in new ArrayEnumerable<int>(arr))
        {
            System.Console.WriteLine(item);
        }
    }
}

class ArrayEnumerator<T> : IEnumerator<T>
{
    private int _current = -1;
    private readonly T[] _array;

    public ArrayEnumerator(T[] array)
    {
        _array = array;
    }

    public T Current => _array[_current];
    object IEnumerator.Current => Current;

    public void Dispose()
    {

    }

    public bool MoveNext()
    {
        return ++_current < _array.Length;
    }

    public void Reset()
    {
        _current = 0;
    }
}

class ArrayEnumerable<T> : IEnumerable<T>
{
    private readonly T[] _array;

    public ArrayEnumerable ArrayEnumerator(T[] arr)
    {
        _array = arr;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new ArrayEnumerator<T>(_array);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}