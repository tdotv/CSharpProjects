using System.Collections;

// Yield

class Sample6
{
    public void F()
    {
        Sample();

        // foreach (var item in Sample())
        // {
        //     System.Console.WriteLine($"Item is {item}");
        // }
    }

    private IEnumerable<int> Sample()
    {
        System.Console.WriteLine("Start");
        try
        {
            System.Console.WriteLine("Before first yield return. ");
            yield return 1;
            System.Console.WriteLine("After first yield return. ");
            yield return 2;
            System.Console.WriteLine("After second yield return. ");
        }
        finally
        {
            
            System.Console.WriteLine("Finished!");
        }
    }
}