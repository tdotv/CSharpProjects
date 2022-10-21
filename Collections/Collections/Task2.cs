namespace CSharpTest
{
    public class Task2
    {
        public static void Start(MyList myList)
        {
            int option = -1;

            while (option != 0)
            {
                Console.WriteLine("\n\tВыберите функцию для работы со списком чисел:\n1. Добавить Число\n2. Удалить Число\n3. Найти самое близкое по значению число\n4. Показать Список\n0. EXIT");
                option = int.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        myList.AddNumber();
                        break;
                    case 2:
                        myList.RemoveNumber();
                        break;
                    case 3:
                        myList.FindClosestNumber();
                        break;
                    case 4:
                        myList.ShowList();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Пожалуйста, выберите целое число между 0 - 4 ");
                        break;
                }
            }
        }
    }
}