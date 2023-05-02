using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph
    {
        private class Node //Vertice
        {
            public String Label { get; private set; }
            public Node(String lable) { Label = lable; }
            public override String ToString() { return Label; }
        }

        private Dictionary<String, Node> Nodes { get; set; } //NodeList
        private Dictionary<Node, List<Node>> Edges { get; set; } //AdjecencyList
        public Graph() { Nodes = new(); Edges = new(); }
        private bool IsNull(Node node) { return node == null; }

        public void AddNode(String label)
        {
            Nodes.TryAdd(label, new Node(label));
            var node = Nodes[label];
            Edges.TryAdd(node, new());  //new List
        }

        public void RemoveNode(String label)
        {
            var node = Nodes[label];
            if (IsNull(node)) return;
            Edges.Remove(node);
            Nodes.Remove(label);
        }

        public void AddEdge(String fromString, String toString)
        {   //relationship from -> to
            try { Edges[Nodes[fromString]].Add(Nodes[toString]); }
            catch (Exception) { throw new ArgumentException(); }    //IsNull
        }

        public void RemoveEdge(String fromString, String toString)
        {   //remove from.to
            try { Edges[Nodes[fromString]].Remove(Nodes[toString]); }
            catch (Exception) { return; }    //IsNull
        }

        //Iteration
        public void TraverseDepthFirst(String rootString)
        {
            HashSet<Node> visited = new();
            Stack<Node> stack = new();
            var root = Nodes?[rootString];
            if (IsNull(root!)) return;
            stack.Push(root!);   //Link
            while (stack.Count != 0)
            {
                var node = stack.Pop(); //currernt
                if (visited.Contains(node)) continue;
                else visited.Add(node);
                Console.Write(node + " ");
                foreach (var neighbour in Edges[node])   //Links
                    if (!visited.Contains(neighbour)) stack.Push(neighbour);
            }
        }

        public void TraverseBreadthFirst(String rootString)
        {
            HashSet<Node> visited = new();
            Queue<Node> queue = new();
            var root = Nodes?[rootString];
            if (IsNull(root!)) return;
            queue.Enqueue(root!);   //Link
            while (queue.Count != 0)
            {
                var node = queue.Dequeue(); //currernt
                if (visited.Contains(node)) continue;
                else visited.Add(node);
                Console.Write(node + " ");
                foreach (var neighbour in Edges[node])   //Links
                    if (!visited.Contains(neighbour)) queue.Enqueue(neighbour);
            }
        }

        public void TraverseDepthFirst_recursion(String rootString)
        {
            try
            {
                Node root = Nodes[rootString];
                TraverseDepthFirst_recursion(root, new());
                Console.WriteLine();
            }
            catch (ArgumentNullException) { return; }
        }

        private void TraverseDepthFirst_recursion(Node node, HashSet<Node> visited)
        {
            Console.Write(node + " ");
            visited.Add(node);
            foreach (var neighbour in Edges[node])
                if (!visited.Contains(neighbour)) TraverseDepthFirst_recursion(neighbour, visited);
        }

        public List<String> TopologicalSort()  //לחזור 
        {   //right order
            Stack<Node> stack = new();
            HashSet<Node> visitedSet = new();
            foreach (var node in Nodes.Values) TopologicalSort(node, visitedSet, stack);
            return ToList(stack);
        }

        private List<String> ToList(Stack<Node> stack)
        {
            List<String> sortedList = new();
            while (stack.Count != 0) sortedList.Add(stack.Pop().Label);
            return sortedList;
        }

        private void TopologicalSort(Node node, HashSet<Node> visitedSet, Stack<Node> stack)
        {
            if (visitedSet.Contains(node)) return;
            visitedSet.Add(node);
            foreach (var neighbour in Edges[node])
                TopologicalSort(neighbour, visitedSet, stack);
            stack.Push(node);
        }

        public bool HasCycle()
        {
            HashSet<Node> all = new();
            all.UnionWith(Nodes.Values);
            HashSet<Node> visiting = new();
            HashSet<Node> visited = new();
            foreach (var current in all) if (HasCycle(current, all, visiting, visited)) return true; ;

            return false;
        }

        private bool HasCycle(Node node, HashSet<Node> all, HashSet<Node> visiting, HashSet<Node> visited)
        {
            all.Remove(node);
            visiting.Add(node);
            foreach (var neighbour in Edges[node])
            {
                if (visited.Contains(neighbour)) continue;
                if (visiting.Contains(neighbour)) return true;
                if (HasCycle(neighbour, all, visiting, visited)) return true;
            }
            visiting.Remove(node);
            visited.Add(node);
            return false;
        }

        public override String ToString()
        {
            StringBuilder str = new StringBuilder("");
            foreach (var source in Edges.Keys)
            {
                var targets = Edges[source];
                if (targets.Count != 0) str.Append(source + " is connected to [" + String.Join(", ", targets) + "]\n");
            }
            return str.ToString();
        }
    }
}