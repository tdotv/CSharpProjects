using System;

namespace test
{
    enum Shape
    {
        Traditional = 1,
        Peaberries
    }
    enum Type
    {
        Arabica = 1,
        Robusta
    }

    public class Coffee
    {
        private string shape;
        private string type;
        private int cost;

        public Coffee(string shape, string type, int cost)
        {
            this.shape = shape;
            this.type = type;
            this.cost = cost;
        }

        public string Shape
        {
            get { return shape; }
            set { shape = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Cost
        {
            get { return cost; }
            set
            {
                if (value >= 0)
                    cost = value;
                else
                    Console.WriteLine("Value can't be negative");

            }
        }

        //public override string ToString() => $"Shape {shape} : Type {type}$ : Cost {cost}$";

    }
}