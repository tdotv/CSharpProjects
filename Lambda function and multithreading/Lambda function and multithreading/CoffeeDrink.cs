namespace test
{
    enum Drink
    {
        Latte = 1,
        Cappuccino,
        Americano,
        Espresso,
        FlatWhite
    }

    public class CoffeeDrink : Coffee
    {
        private int coffeine;
        private int milk;

        public CoffeeDrink(string shape, string type, int cost, int coffeine, int milk) : base(shape, type, cost)
        {
            this.coffeine = coffeine;
            this.milk = milk;
        }

        public int Coffeine
        {
            get { return coffeine; }
            set { coffeine = value; }
        }

        public int Milk
        {
            get { return milk; }
            set { milk = value; }
        }
    }
}
