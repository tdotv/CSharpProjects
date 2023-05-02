using System.Collections.Generic;

namespace LinkdedList
{
    class Program
    {
        static void Main()
        {
            LinkedList list = new LinkedList();
            Console.WriteLine(list.Size);    //0
            list.AddLast(10);   //deleted
            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(50);   //deleted
            Console.WriteLine(list);
            Console.WriteLine(list.Size);    //3
            list.RemoveFirst();
            list.RemoveLast();

            Console.WriteLine();

            Console.WriteLine(list.IndexOf(20));   //0
            Console.WriteLine(list.IndexOf(40));   //-1
            Console.WriteLine(list.Contains(40));  //false
            Console.WriteLine(list.Contains(20));  //true

            var array1 = list.ToArray();
            Console.WriteLine(String.Join(", ", array1));


            Console.WriteLine("reverse");
            Console.WriteLine(list);
            list.Reverse();
            Console.WriteLine(list);

            list.AddLast(10);

            var array2 = list.ToArray();
            Console.WriteLine(String.Join(", ", array2));

            Console.WriteLine();
            Console.WriteLine(list.Kth(2));
            Console.WriteLine(list);
        }
    }
}