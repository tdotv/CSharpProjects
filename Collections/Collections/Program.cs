using System.Threading.Tasks;

namespace CSharpTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task1.Start();
            Console.ReadLine();
            Task2.Start(new MyList());
        }
    }
}