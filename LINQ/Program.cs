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
            // Console.WriteLine(string.Join(" ", "aaa;xabbx;abb;ccc;dap".Split(';').OrderByDescending(w => w.Length).First()))
            // Console.WriteLine(string.Join(" ", "aaa;xabbx;abb;ccc;dap".Split(';').Aggregate((longest, next) => next.Length > longest.Length ? next : longest)));

            // 8. Calculate average length of word in string "aaa;xabbx;abb;ccc;dap"
            // Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Average(w => w.Length));
            // Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Select(word => word.Length).Average());

            // 9. Print the shortest word reversed in string "aaa;xabbx;abb;ccc;dap;zh"
            // Console.WriteLine(new string("aaa;xabbx;abb;ccc;dap;zh".Split(';').OrderBy(word => word.Length).First().Reverse().ToArray()));
            // Console.WriteLine("aaa;xabbx;abb;ccc;dap;zh".Split(';').Aggregate((shortest, next) => next.Length < shortest.Length ? next : shortest).Reverse().ToArray());

            // ??? 10. Print true if in the first word that starts from "aa" all letters are 'b' otherwise false "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh"
            // Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').FirstOrDefault(w => w.StartsWith("aa"))?.All(c => c == 'b'));

            // 11. Print last word in sequence that excepting first two elements that ends with "bb"
            // Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').Skip(2).LastOrDefault(word => word.EndsWith("bb")));
        }
    }
}

