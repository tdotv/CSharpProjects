namespace LINQ
{
    public class Program
    {
        public static void Main()
        {
            // new Sample1().F();
            // new Sample2().F();
            // new Sample3().F();
            // new Sample4().F();
            // new Sample5().F();
            // new Sample6().F();
            // new Sample7().F();
            // await new Sample8().F();

            // ---------------------------------------------------------

            // 1. Print all numbers from 10 to 50 separated by commas
            // System.Console.WriteLine(string.Join(",", Enumerable.Range(10,41)));

            // 2.  Print only that numbers from 10 to 50 that can be divided by 3
            // System.Console.WriteLine(string.Join(" ", Enumerable.Range(10,41).Where(n => n % 3 == 0)));

            // 3. Output word "Linq" 10 times
            // System.Console.WriteLine(string.Join(" ", Enumerable.Repeat("LINQ", 10)));

            // 4. Output all words with letter 'a' in string "aaa;abb;ccc;dap"
            // System.Console.WriteLine(string.Join(" ", "aaa;abb;ccc;dap".Split(";").Where(word => word.Contains("a"))));

            // 5. Output number of letters 'a' in the words with this letter in string "aaa;abb;ccc;dap" separated by comma
            // System.Console.WriteLine("aaa;abb;ccc;dap".Split(";").Where(w => w.Contains('a')).Sum(w => w.Count(c => c == 'a')));

            // 6. Output true if word "abb" exists in line  "aaa;xabbx;abb;ccc;dap", otherwise false
            // System.Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(";").Contains("abb"));

            // 7. Get the longest word in string "aaa;xabbx;abb;ccc;dap"
            System.Console.WriteLine("aaa;xabbx;abb;ccc;dap");
        }
    }
}

