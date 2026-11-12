using System;
using System.Collections.Generic;

namespace DSA.Lab06
{
    public sealed class DijkstraRouteFinder
    {
        public RouteResult FindRoute(WeightedGraph graph, string start, string goal)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            if (!graph.ContainsNode(start) || !graph.ContainsNode(goal))
            {
                return RouteResult.NotFound(0);
            }

            if (start == goal)
            {
                return RouteResult.Success(new[] { start }, 0, 0);
            }

            var bestCost = new Dictionary<string, int>();
            var cameFrom = new Dictionary<string, string>();
            var frontier = new MinFrontier<string>();

            bestCost[start] = 0;
            frontier.Enqueue(start, 0);

            int expandedNodes = 0;

            // TODO Lab 6A:
            // 1. Repeatedly remove the smallest-priority frontier candidate.
            // 2. Ignore stale entries when a cheaper cost is already known.
            // 3. Finalize/expand the current node.
            // 4. If it is the goal, reconstruct the route using cameFrom.
            // 5. Relax each outgoing edge:
            //      candidate = bestCost[current] + edge.Cost
            //    If candidate improves the known cost, update both bestCost and cameFrom,
            //    then enqueue the neighbor with the improved total cost.
            //
            // Implement one small piece at a time and run the relevant tests.

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                string currentName = current.Value;
                    
                if(current.Priority > bestCost[currentName])
                {
                    continue;
                }

                expandedNodes++;

                if (currentName == goal)
                {
                    List<string> route = new();

                    route.Add(currentName);


                    while (currentName != start)
                    {
                        currentName = cameFrom[currentName];
                        route.Add(currentName);
                    }

                    route.Reverse();

                    return RouteResult.Success(route, bestCost[goal], expandedNodes);

                }

                foreach (WeightedEdge edge in graph.GetOutgoing(currentName))
                {
                    int cost = bestCost[currentName] + edge.Cost;

                    if(!bestCost.TryGetValue(edge.To, out int knownCost) || cost < knownCost)
                    {
                        bestCost[edge.To] = cost;

                        cameFrom[edge.To] = currentName;

                        frontier.Enqueue(edge.To, cost);
                    }
                }
            }

            return RouteResult.NotFound(expandedNodes);
        }
    }
}
