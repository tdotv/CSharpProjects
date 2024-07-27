using System.Collections;

// Combining and introducing extensions

class Sample4
{
    public void F()
    {
        var arr = new ArrayEnumerable<int>(new int[] { 1, 20, 3, 70 });
        var withAppliedWhere = new WhereGreaterThanEnumerable(arr, 5);
        var multiplied = withAppliedWhere.MySelect(x => x * 2); // var multipled = new SelectEnumerable<int, int>(withAppliedWhere, x => x * 2);

        foreach (var item in new SelectEnumerable<int, string>(multipled, x => "Hello! " + x.ToString()))
        {
            System.Console.WriteLine(item);
        }
    }
}

static class MyEnumerableExtensions
{
    public static IEnumerable<TOut> MySelect<TIn, TOut>(this IEnumerable<TIn> enumerator, Func<TIn, TOut> converter)
    {
        return new SelectEnumerable<TIn, TOut>(enumerator, converter);
    }
}