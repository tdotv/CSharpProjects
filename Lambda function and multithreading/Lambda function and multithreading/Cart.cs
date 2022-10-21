using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace test
{
    public class Cart
    {
        private List<Coffee> _listCart;
        static Coffee coffee;

        public Cart()
        {
            _listCart = new List<Coffee>();
        }

        public Cart(List<Coffee> _listCart)
        {
            this._listCart = _listCart;
        }

        public List<Coffee> Coffees
        {
            get { return _listCart; }
            set { _listCart = value; }
        }

        public void AddCoffee()
        {
            int cost;

            try
            {
                Console.WriteLine("\n\tChoose your coffee shape:\n1. Traditional\n2. Peaberries");
                string chooseShape = Console.ReadLine();
                Shape shape = (Shape)Enum.Parse(typeof(Shape), chooseShape, ignoreCase: true);

                Console.WriteLine("\n\tNow choose your coffee type:\n1. Arabica\n2. Robusta");
                string chooseType = Console.ReadLine();
                Type type = (Type)Enum.Parse(typeof(Type), chooseType, ignoreCase: true);

                switch (shape)
                {
                    case Shape.Traditional:
                        switch (type)
                        {
                            case Type.Arabica:
                                Console.WriteLine("You have chosen Traditional Arabica coffee beans");
                                cost = 1000;
                                coffee = new Coffee(chooseShape, chooseType, cost);
                                _listCart.Add(coffee);
                                break;
                            case Type.Robusta:
                                Console.WriteLine("You have chosen Traditional Robusta coffee beans");
                                cost = 750;
                                coffee = new Coffee(chooseShape, chooseType, cost);
                                _listCart.Add(coffee);
                                break;
                        }
                        break;
                    case Shape.Peaberries:
                        switch (type)
                        {
                            case Type.Arabica:
                                Console.WriteLine("You have chosen Peaberries Arabica coffee beans");
                                cost = 500;
                                coffee = new(chooseShape, chooseType, cost);
                                _listCart.Add(coffee);
                                break;
                            case Type.Robusta:
                                Console.WriteLine("You have chosen Peaberries Robusta coffee beans");
                                cost = 250;
                                coffee = new Coffee(chooseShape, chooseType, cost);
                                _listCart.Add(coffee);
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\tError: {ex.Message}\n");
                throw;
            }
        }

        public void RemoveAtCart()
        {
            int index;

            Console.Write("Enter the cart number you want to delete: ");
            index = int.Parse(Console.ReadLine());

            if (index < 0 || index > _listCart.Capacity)
                Console.WriteLine("You can't delete unexisted cart number!");
            else
                _listCart.RemoveAt(index);
        }

        public void ClearCart()
        {
            Console.WriteLine("All orders are deleted from the cart\n");
            _listCart.Clear();
        }

        public void ShowCart()
        {
            Console.WriteLine("Coffee in the Cart:");
            foreach (Coffee coffee in _listCart)
            {
                Console.WriteLine("Shape: " + coffee.Shape + "\tType: " + coffee.Type + "\t\tCost: " + coffee.Cost);
                Console.WriteLine();
            }
        }

        public void BuyCart()
        {
            Console.Write("Cost of the Cart: ");
            var findSum = () =>
            {
                int result = 0;
                if (_listCart.Count != 0)
                {
                    foreach (Coffee coffee in _listCart)
                    {
                        result += coffee.Cost;
                    }
                    Console.WriteLine(result);
                }
                else
                    Console.WriteLine("Your Cart is already empty!");
            };
            findSum();
        }

        public void SortCart()
        {
            Thread myThread1 = new(AscendingSort);
            myThread1.Start();
            Thread.Sleep(300);
            Thread myThread2 = new(DescendingSort);
            myThread2.Start();
        }

        private void AscendingSort()
        {
            Console.WriteLine("\n\tSort ascending by cost:");
            _listCart = _listCart.OrderBy(g => g.Cost).ToList();
            ShowCart();
        }

        private void DescendingSort()
        {
            Console.WriteLine("\n\tSort descending by cost:");
            _listCart = _listCart.OrderByDescending(g => g.Cost).ToList();
            ShowCart();
        }

    }
}