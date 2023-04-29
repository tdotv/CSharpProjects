using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var book = new Dictionary<string, decimal>
            {
                { "apple", 0.67m },
                { "milk", 1.49m },
                { "avocado", 1.49m }
            };

            foreach (var item in book)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}