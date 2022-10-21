namespace CSharpTest
{
    public class Task1
    {
        public static void Start()
        {
            var rand = new Random();
            var randomInt = new List<int>();

            Console.WriteLine("\tTask 1\n");
            for (int i = 0; i < 9; i++) // Add random numbers in list
            {
                randomInt.Add(rand.Next(-15, 15));
            }

            var descendingNumbers = from i in randomInt // LINQ sort
                                    orderby i descending
                                    select i;
            ShowList();

            randomInt.RemoveAll(i => i % 2 == 0);   // Delete even numbers
            ShowList();

            List<string> randomString = randomInt.ConvertAll<string>(x => x.ToString());
            Console.WriteLine(String.Join(", ", randomString));

            void ShowList()
            {
                foreach (int i in descendingNumbers)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("\n\n\n");
            }
        }
    }
}