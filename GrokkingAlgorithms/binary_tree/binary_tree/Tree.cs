using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTree
{
    public class Tree
    {
        private class Node
        {
            public int Value { set; get; }
            public Node ChildLeft { set; get; }
            public Node ChildRight { set; get; }
            public Node(int value) { Value = value; }
        }
        private Node Root { set; get; }
        public Tree() { }
        private bool IsNull(Node node) { return node == null; }
        private bool IsLeaf(Node node) { return IsNull(node.ChildLeft) && IsNull(node.ChildRight); }

        public void Insert(int value)
        {
            if (IsNull(Root)) { Root = new Node(value); return; }
            var current = Root;
            while (true)
            {
                if (value < current.Value)
                {
                    if (IsNull(current.ChildLeft)) { current.ChildLeft = new Node(value); break; }
                    current = current.ChildLeft;
                }
                else if (value > current.Value)
                {
                    if (IsNull(current.ChildRight)) { current.ChildRight = new Node(value); break; }
                    current = current.ChildRight;
                }
                else /*==*/ break;
            }
        }
        public bool Find(int value)
        {
            var current = Root;
            while (!IsNull(current))
            {
                if (value == current.Value) return true;
                current = value < current.Value ? current.ChildLeft : current.ChildRight;
            }
            return false;
        }


        public int Height() { return Height(Root); }
        private int Height(Node node)
        {
            if (IsNull(node)) return -1; //int.MinValue;
            if (IsLeaf(node)) return 0; // base condition
            return 1 + Math.Max(Height(node.ChildLeft), Height(node.ChildRight));
        }

        public int Min() { return Min(Root); }
        private int Min(Node node)
        { // O(n)
            if (IsNull(node)) return int.MaxValue;
            if (IsLeaf(node)) return node.Value;    //base condition
            var left = Min(node.ChildLeft);
            var right = Min(node.ChildRight);
            return Math.Min(Math.Min(left, right), node.Value);
        }

        public int Min_binarySearchTree()
        { // O(log(n)) --> O(n)
            if (IsNull(Root)) throw new Exception();
            var current = Root;
            while (!IsNull(current.ChildLeft)) current = current.ChildLeft;
            return current.Value;
        }

        public bool Equals(Tree other)
        {
            if (other == null) return false;
            return Equals(Root, other.Root);
        }
        private bool Equals(Node a, Node b)
        {
            if (IsNull(a) && IsNull(b)) return true;
            if (!IsNull(a) && !IsNull(b))
                return a.Value == b.Value
                        && Equals(a.ChildLeft, b.ChildLeft)
                        && Equals(a.ChildRight, b.ChildRight);
            return false;
        }

        public bool IsBinarySearchTree() { return IsBinarySearchTree(Root, int.MinValue, int.MaxValue); }
        private bool IsBinarySearchTree(Node node, int min, int max)
        {
            if (IsNull(node)) return true;
            if (node.Value < min || node.Value > max) return false;
            return IsBinarySearchTree(node.ChildLeft, min, node.Value) && IsBinarySearchTree(node.ChildRight, node.Value, max);
        }
        public void SwapRoot() { var temp = Root.ChildLeft; Root.ChildLeft = Root.ChildRight; Root.ChildRight = temp; }

        public List<int> GetNodesAtDistance(int distance)
        {
            var list = new List<int>();
            GetNodesAtDistance(Root, distance, list); /*Console.WriteLine("");*/
            return list;
        }

        private void GetNodesAtDistance(Node node, int distance, List<int> list)
        {
            if (IsNull(node)) return;
            if (distance == 0) { list.Add(node.Value); /*System.out.print( node.value + " " );*/ return; }
            GetNodesAtDistance(node.ChildLeft, distance - 1, list);
            GetNodesAtDistance(node.ChildRight, distance - 1, list);
        }


        public void TraverseLevelOrder()
        {
            for (var i = 0; i <= Height(); ++i)
            {
                var list = GetNodesAtDistance(i);
                Console.WriteLine(i + "| " + String.Join(", ", list));
            }
        }


        /*1*/
        public int Size() { return Size(Root); }
        private int Size(Node node)
        {
            if (IsNull(node)) return 0;
            return 1 + (!IsNull(node.ChildLeft) ? Size(node.ChildLeft) : 0)
                     + (!IsNull(node.ChildRight) ? Size(node.ChildRight) : 0);
        }

        /*2*/
        public int CountLeavels()
        {
            return CountLeavels(Root, 0);
        }
        private int CountLeavels(Node node, int level)
        {
            if (IsNull(node)) return level;
            return 1 + Math.Max(CountLeavels(node.ChildLeft, level), CountLeavels(node.ChildRight, level));
        }

        /*3*/
        public int Max()
        {
            if (IsNull(Root)) throw new Exception();
            return Math.Max(Max(Root), Root.Value);
        }
        private int Max(Node node)
        {
            if (IsNull(node)) return int.MinValue;
            return Math.Max(IsNull(node.ChildLeft) ? node.Value : Max(node.ChildLeft)
                            , IsNull(node.ChildRight) ? node.Value : Max(node.ChildRight)
            );
        }

        public bool Contains(int value)
        {
            return Contains(Root, value);
        }
        private bool Contains(Node node, int value)
        { //O(log(n))!!! /O(n)
            if (IsNull(node)) return false;
            if (value == node.Value) return true;
            /*binary search tree O(log(n))*///return value < node.Value ? Contains(node.ChildLeft, value) : Contains(node.ChildRight, value); //	O(log(n))
            return Contains(node.ChildLeft, value) || Contains(node.ChildRight, value); //O(n)
        }


        public void TraversePreOrder()      // Root, Left, Right
        {
            TraversePreOrder(Root);
            Console.WriteLine();
        }
        private void TraversePreOrder(Node node)
        {
            if (IsNull(node)) return;   //base condition
            Console.Write(node.Value + " ");
            TraversePreOrder(node.ChildLeft);
            TraversePreOrder(node.ChildRight);
        }

        public void TraverseInOrder()       // Left, Root, Right
        {
            TraverseInOrder(Root);
            Console.WriteLine();
        }
        private void TraverseInOrder(Node node)
        {   // from low to high  1 2 3 4 ...
            if (IsNull(node)) return;   //base condition
            TraverseInOrder(node.ChildLeft);
            Console.Write(node.Value + " "); //Root
            TraverseInOrder(node.ChildRight);
        }

        public void TraversePostOrder()     // Left, Right, Root
        {
            TraversePostOrder(Root);
            Console.WriteLine();
        }
        private void TraversePostOrder(Node node)
        {
            if (IsNull(node)) return;   //base condition
            TraversePostOrder(node.ChildLeft);
            TraversePostOrder(node.ChildRight);
            Console.Write(node.Value + " "); //Root
        }


        public int Size2()  //with recursion
        {
            List<int> list = new List<int>();
            TraverseInOrder2(Root, list);
            int size = list.Count;
            return size;
        }

        private void TraverseInOrder2(Node node, List<int> list)    //the recursion
        {   // from low to high  1 2 3 4 ...
            if (IsNull(node)) return;   //base condition
            TraverseInOrder2(node.ChildLeft, list);
            list.Add(node.Value);
            TraverseInOrder2(node.ChildRight, list);
        }
        public override string ToString()
        {

            var list = new List<int>();
            TraverseInOrder2(Root, list);
            String str = String.Join(", ", list);
            return str;
        }


        /*AVL*/
        /*1*/
        private bool IsBalanced(Node node)
        {
            if (IsNull(node)) return true;
            return Math.Abs(Height(node.ChildLeft) - Height(node.ChildRight)) <= 1
                && IsBalanced(node.ChildLeft)
                && IsBalanced(node.ChildRight);
        }
        public bool IsBalanced()
        {
            if (IsNull(Root)) return true;
            return IsBalanced(Root);
        }
        /*2*/
        private bool IsPerfect(Node node)
        {
            if (IsNull(node)) return true;
            return Height(node.ChildLeft) - Height(node.ChildRight) == 0
                && IsPerfect(node.ChildLeft)
                && IsPerfect(node.ChildRight);
        }
        public bool IsPerfect()
        {
            if (IsNull(Root)) return true;
            return IsPerfect(Root);
        }
    }
}