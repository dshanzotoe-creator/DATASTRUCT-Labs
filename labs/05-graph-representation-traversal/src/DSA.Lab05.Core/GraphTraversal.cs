using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DSA.Lab05
{
    /// <summary>
    /// Iterative graph traversals.
    ///
    /// Complete these methods after the adjacency representation is working.
    /// Think in terms of:
    /// frontier + visited + neighbors.
    /// </summary>
    public static class GraphTraversal
    {
        public static IReadOnlyList<string> BreadthFirstOrder(AdjacencyGraph graph, string start) 
        {
            HashSet<string> visited = new HashSet<string>();
            List<string> res = new List<string>();

            string src = start;
            Queue<string> queue = new Queue<string>();


            visited.Add(src);
            queue.Enqueue(src);

            while (queue.Count > 0)
            {
                string curr = queue.Dequeue();
                res.Add(curr);
                

                foreach(string neighbor in graph.GetNeighbors(curr))
                {
                    if (visited.Add(neighbor))
                        queue.Enqueue(neighbor);
                    
                }
            }

            return res;
        }

        public static IReadOnlyList<string> DepthFirstOrder( AdjacencyGraph graph, string start)
        {
            HashSet<string> visited = new HashSet<string>();
            List<string> res = new List<string>();

            string src = start;
            Stack<string> stack = new Stack<string>();

            visited.Add(src); 
            stack.Push(src);

            while (stack.Count > 0)
            {
                string curr = stack.Pop();
                res.Add(curr);

                IReadOnlyList<string> neighbors = graph.GetNeighbors(curr);

                for (int i = neighbors.Count - 1; i >= 0; i--)
                {
                    string neighbor = neighbors[i];

                    if(visited.Add(neighbor))
                        stack.Push(neighbor);
                }
            }

            return res;
        }

        public static bool IsReachableBfs(AdjacencyGraph graph, string start,  string target)
        {
            HashSet<string> visited = new HashSet<string>();

            string src = start;
            Queue<string> queue = new Queue<string>();


            visited.Add(src);
            queue.Enqueue(src);

            while (queue.Count > 0)
            {
                string curr = queue.Dequeue();
                if (curr.Equals(target))
                {
                    return true;
                }


                foreach (string neighbor in graph.GetNeighbors(curr))
                {
                    if (visited.Add(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }

                }
            }

            return false;
        }
    }
}
