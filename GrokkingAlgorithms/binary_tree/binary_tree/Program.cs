namespace BinaryTree
{
    class Program
    {
        static void Main()
        {
            Tree tree = new Tree();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);
            Console.WriteLine(tree.Find(10) ? "TRUE" : "FALSE");
            Console.WriteLine(tree.Find(5));
            Console.WriteLine();

            Console.WriteLine(Factorial_it(4));
            Console.WriteLine(Factorial_it(5));

            tree.TraversePreOrder();
            tree.TraverseInOrder();
            tree.TraversePostOrder();
            Console.WriteLine(tree.Max());
            Console.WriteLine(tree.CountLeavels());

            Console.WriteLine("//////");
            Console.WriteLine(tree.Height());
            Console.WriteLine(tree.Min());
            Console.WriteLine(tree.Min_binarySearchTree());
            Tree tree2 = new Tree();
            tree2.Insert(7);
            tree2.Insert(4);
            tree2.Insert(9);
            tree2.Insert(1);
            tree2.Insert(6);
            tree2.Insert(8);
            tree2.Insert(10);
            Console.WriteLine((tree.Equals(tree2)));
            Tree tree3 = new Tree();
            tree3.Insert(7);
            tree3.Insert(4);
            tree3.Insert(9);
            tree3.Insert(1);
            tree3.Insert(6);
            tree3.Insert(8);

            Console.WriteLine((tree.Equals(tree3)));
            Console.WriteLine((tree.Equals(null)));

            Console.WriteLine((tree.IsBinarySearchTree()));
            tree2.SwapRoot();   //ubalance the tree
            Console.WriteLine((tree2.IsBinarySearchTree()));
            Console.WriteLine((tree.IsBinarySearchTree()));
            Console.WriteLine((tree2.IsBinarySearchTree()));

            Console.WriteLine(String.Join(",", tree.GetNodesAtDistance(0)));
            Console.WriteLine(String.Join(",", tree.GetNodesAtDistance(1)));
            Console.WriteLine(String.Join(",", tree.GetNodesAtDistance(2)));
            Console.WriteLine(String.Join(",", tree.GetNodesAtDistance(3)));
            Console.WriteLine(String.Join(",", tree.GetNodesAtDistance(30)));
            //BREADTH FIRST
            tree.TraverseLevelOrder();
            Console.WriteLine(tree.Size2());    //Recursion
            Console.WriteLine(tree.Size());
            Tree tree4 = new Tree();
            Console.WriteLine(tree4.Size());
            Console.WriteLine();

            tree3.Insert(5);
            Console.WriteLine(tree3.CountLeavels());
            Console.WriteLine("max");
            Console.WriteLine(tree.Max());
            Console.WriteLine(tree.Contains(4));

            Console.WriteLine("///////");
            Tree tree6 = new Tree();
            tree6.Insert(10);
            tree6.Insert(20);
            tree6.Insert(30);

            tree6.Insert(5);
            tree6.Insert(6);
            tree6.Insert(2);
            // tree6.Insert(15);

            Console.WriteLine(tree6.IsBalanced());
            Console.WriteLine(tree6.IsPerfect());

        }

        public static int Factorial_it(int n)
        { // iteration
            var factorial = 1;
            for (var i = n; i > 1; i--) factorial *= i;
            return factorial;
        }
        // 4! = 4 x 3!
        // 3! = 3 x 2!
        // n! = n x (n-1)!	// f(n) = n x f(n-1)
        public static int Factorial_re(int n)
        { // recursion
            if (n == 1) return 1;   //base condition for recursion
            return n * Factorial_re(n - 1);
        }
    }
}