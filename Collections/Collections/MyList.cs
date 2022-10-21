using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class MyList
    {
        public readonly List<int> intList;
        public MyList() => intList = new List<int>();


        public void AddNumber() // Добавление числа
        {
            Console.Write("Введите число, которое вы хотите добиавить в список: ");
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
                Console.WriteLine("\nОшибка ввода! Введите целое число a");
            intList.Add(number);
        }

        public void RemoveNumber()  // Удаление числа
        {
            Console.Write("Введите порядковый номер числа, которого вы хотите удалить: ");
            int index = int.Parse(Console.ReadLine()!);

            if (index < 0 || index > intList.Count)
                Console.WriteLine("\nВы не можете удалить не существующий номер!");
            else
                intList.RemoveAt(index);
        }

        public void FindClosestNumber()  // Найти близкое число
        {
            Console.Write("Пожалуйста, введите число для поиска наиболее близкого в списке: ");
            int number = int.Parse(Console.ReadLine()!);
            int closest = intList.Aggregate((x, y) => Math.Abs(x - number) < Math.Abs(y - number) ? x : y);
            Console.WriteLine("\nСамое близкое число это " + closest);
        }

        public void ShowList()
        {
            Console.WriteLine("Ваш список содержит:");
            foreach (int i in intList)
            {
                Console.WriteLine(i);
            }
        }

    }
}