using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var obj1 = new { Hello = "Hello", World = "World" };
            var obj2 = new { Hello = 11, World = new List<int>() };
            Console.WriteLine(obj1);
            Console.WriteLine(obj2);

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

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    result[0] = map[complement];
                    result[1] = i;
                    return result;
                }
                map[nums[i]] = i;
            }
            return result;
        }



    }
}