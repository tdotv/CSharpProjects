using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkdedList
{
    public class LinkedList
    {
        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node(int value) { Value = value; }
        }
        private Node Head { get; set; }
        private Node Tail { get; set; }
        public int Size { get; private set; }
        public LinkedList() { ResetList(); }
        private void ResetList()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }
        private bool IsEmpty() { return Head == null; }
        public void AddLast(int item)
        {
            Node node = new Node(item);
            if (IsEmpty()) { Head = node; Tail = node; }
            else { Tail.Next = node; Tail = node; }
            Size++;
        }
        public void AddFirst(int item)
        {
            Node node = new Node(item);
            if (IsEmpty()) { Head = node; Tail = node; }
            else { node.Next = Head; Head = node; }
            Size++;
        }
        public int IndexOf(int item)
        {
            int index = 0;
            var current = Head;
            while (current != null)
            {
                if (current.Value == item) return index;
                current = current.Next;
                index++;
            }
            return -1;
        }
        public bool Contains(int item) { return IndexOf(item) != -1; }
        public void RemoveFirst()
        {
            if (IsEmpty()) throw new Exception();
            if (Head == Tail) { ResetList(); return; } //1 element only;
                                                       //[10 20 -> 30]
            var newHead = Head.Next;
            Head.Next = null;
            Head = newHead;
            Size--;
        }

        private Node GetPrevius(Node node)
        {   //n-1	n=last
            var current = Head;
            while (current != null)
            {
                if (current.Next == node) return current;
                current = current.Next;
            }
            return null;
        }
        public void RemoveLast()
        {
            //edge cases:
            if (IsEmpty()) throw new Exception();
            if (Head == Tail) { ResetList(); return; }
            //[10 -> 20  30]
            var previus = GetPrevius(Tail);
            Tail = previus;
            Tail.Next = null;
            Size--;
        }


        public int[] ToArray()
        {
            int[] array = new int[Size];
            var current = Head;
            var index = 0;
            while (current != null)
            {
                array[index] = current.Value;
                current = current.Next;
                index++;
            }
            return array;
        }
        public void Reverse()
        {
            if (IsEmpty()) return;
            LinkedList linkedList = new LinkedList();
            var current = Head;
            while (current != null)
            {
                linkedList.AddFirst(current.Value);
                current = current.Next;
            }
            this.Head = linkedList.Head;
            this.Tail = linkedList.Tail;
            //linkedList = null;
        }
        public void ReverseMosh()   //?
        { //Mosh
          //[10 <- 20 30]
          // p     c		
            if (IsEmpty()) return;
            var previus = Head;
            var current = Head.Next;
            Tail = Head;   //focus!
            Tail.Next = null;   //focus!
            while (current != null)
            {
                var next = current.Next;
                current.Next = previus;
                previus = current;
                current = next;
            }
            Head = previus;    //focus!
        }
        //Kth in one loop!
        public int Kth(int place)
        {   //from the end value
            if (IsEmpty()) throw new Exception();
            if (place <= 0 || place > Size) throw new Exception();
            var currentA = Head;
            var currentB = Head;
            for (int i = 0; i < place - 1; ++i) currentB = currentB.Next; //KTH facture for currentA
            while (currentB != Tail)
            {
                currentA = currentA.Next;
                currentB = currentB.Next;
            }
            return currentA.Value;
        }
        public String ToString2()
        {
            int[] arr = this.ToArray();
            return "the array is: " + String.Join(", ", arr);
        }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder("[");
            var current = Head;
            while (current != null)
            {
                str.Append(current.Value);
                str.Append(current.Next != null ? ", " : "");
                current = current.Next;
            }
            str.Append("]");
            return "the array is: " + str.ToString();
        }
    }
}