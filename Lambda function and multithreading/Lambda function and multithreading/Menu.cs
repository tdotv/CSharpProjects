using System;

namespace test
{
    public static class Menu
    {
        private enum MeinMenuChoices
        {
            Show = 1,
            Add,
            Buy,
            Delete,
            Clear,
            Sort,
            Exit = 0
        }

        private static string GetMeinMenu => "1) Show Cart\n"
                                + "2) Add Coffee\n"
                                + "3) Buy Cart\n"
                                + "4. Delete Coffee\n"
                                + "5. Clear Cart\n"
                                + "6) Sort Cart\n"
                                + "0) EXIT\n";
        public static void MainMenu(Cart cart)
        {
            MeinMenuChoices choice;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(GetMeinMenu);
                choice = (MeinMenuChoices)Enum.Parse(typeof(MeinMenuChoices), Console.ReadLine(), ignoreCase: true);
                switch (choice)
                {
                    case MeinMenuChoices.Show:
                        cart.ShowCart();
                        break;

                    case MeinMenuChoices.Add:
                        cart.AddCoffee();
                        break;

                    case MeinMenuChoices.Buy:
                        cart.BuyCart();
                        break;

                    case MeinMenuChoices.Delete:
                        cart.RemoveAtCart();
                        break;

                    case MeinMenuChoices.Clear:
                        cart.ClearCart();
                        break;

                    case MeinMenuChoices.Sort:
                        cart.SortCart();
                        break;

                    case MeinMenuChoices.Exit:
                        return;

                    default:
                        Console.WriteLine("Choose menu option please!");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}