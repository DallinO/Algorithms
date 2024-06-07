/* CSE 381 - Bellman Ford
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S4.
*
*  Instructions: Implement the ShortestPath function per the instructions
*  in the comments.  Run all tests in BellmanFordTest.cs to verify your code.
*  Submit this file and the completed BellmanFord.md file into Canvas.
*/

namespace AlgorithmLib;

public static class BellmanFordShortestPath
{
    /* Find the Shortest Path in a graph using the Bellman Ford Algorithm
    *  with the ability to detect a negative cycle.
    *
    *  Inputs:
    *     g - The Graph (using the Graph class provided)
    *     startVertex - The vertex ID to calculate shortest path from
    *  Outputs:
    *     (Distance List, Predecessor List)
    *
    *  Note: If a negative cycle exists, then the function must return
    *  a tuple of two empty lists. 
    */
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        int n = g.Size();
        // Initialize distances and predecessors to INF
        List<int> distances = Enumerable.Repeat(Graph.INF, n).ToList(); 
        List<int> predecessors = Enumerable.Repeat(Graph.INF, n).ToList();
        // Set distance to startVertex to 0
        distances[startVertex] = 0; 

        // Relax edges repeatedly
        for (int i = 0; i < n - 1; i++)
        {
            for (int u = 0; u < n; u++)
            {
                foreach (var edge in g.Edges(u))
                {
                    int v = edge.DestId;
                    int weight = edge.Weight;
                    if (distances[u] != Graph.INF && distances[u] + weight < distances[v])
                    {
                        distances[v] = distances[u] + weight;
                        predecessors[v] = u;
                    }
                }
            }
        }

        // Check for negative cycles
        for (int u = 0; u < n; u++)
        {
            foreach (var edge in g.Edges(u))
            {
                int v = edge.DestId;
                int weight = edge.Weight;
                if (distances[u] != Graph.INF && distances[u] + weight < distances[v])
                {
                    // Negative cycle detected
                    return (new List<int>(), new List<int>());
                }
            }
        }

        return (distances, predecessors);
    }
    
}