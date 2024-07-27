using System.Collections;

// Materialization

class Sample7
{
    public void F()
    {
        Sample().Skip(2).Take(2);   // Цепочка вызовов
        // Начинаем потреблять данные (метод (ToArray, ToDicitionary), foreach (Some, Min, Max)) - Материализация
        // var arr = Sample().Skip(2).Take(2).ToArray();
    }

    private IEnumerable<int> Sample()
    {
        System.Console.WriteLine("Enter");
        yield return 1;
        try
        {
            yield return 2;
            System.Console.WriteLine("After return 2");
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
            yield return 10;
            System.Console.WriteLine("After return");
        }
        finally
        {
            System.Console.WriteLine("Finally");
        }
    }
}