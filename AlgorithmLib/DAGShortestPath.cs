/* CSE 381 - DAG Shortest Path
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S4.
*
*  Instructions: Implement the Sort and Search functions per the instructions
*  in the comments.  Run all tests in DAGShortestPathTest.cs to verify your code.
*  Submit this file and the completed DAGShortestPath.md file into Canvas.
*/

using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace AlgorithmLib;

public static class DAGShortestPath
{
    /* Topologically sort all vertices in a graph and return the sorted
     * list of vertex ID's.  Use a Stack object (available in C#).
     *
     *  Inputs:
     *     g - Graph
     *  Outputs:
     *     Return a sorted list of vertex ID's
     */
    public static List<int> Sort(Graph g)
    {
        // Sorted vertex idexes
        List<int> sorted = new List<int>();
        // The purpose of the stack in the Sort method is to keeptrack of the
        // order in which vertices are visited during the depth-first search
        // traversal of the graph. This stack helps ensure that vertices are
        // added to the sorted list in the correct topological order.
        Stack<int> stack = new Stack<int>();
        // The visited boolean array is used to keep track of whether a vertex
        // has been visited during the depth-first search(DFS) traversal of the
        // graph. This array helps prevent revisiting vertices that have already
        // been explored, ensuring that the traversal process terminates and
        // that each vertex is processed only once.
        bool[] visited = new bool[g.Size()];


        /* Topological sort method using DFS.
         *
         *  Inputs:
         *     v - vertext index position in the graph.
         *  Outputs:
         *     void
         */
        void TopologicalSort(int v)
        {
            // Mark the we have visited the 
            visited[v] = true;
            // Iterate through the edged
            foreach (var edge in g.Edges(v))
            {
                // Check to see if we have already
                // visited the destination vertex
                if (!visited[edge.DestId])
                {
                    // If we havent visited the vertex
                    // we recusivly call TopologicalSort
                    // to furthur deepen our search.
                    TopologicalSort(edge.DestId);
                }
            }

            // After having visited every edge destination vertex
            // we now know we are as deep in the graph as we can
            // get so we push the current vertex on the Stack
            stack.Push(v);
        }


        // Execute the topoligcal sort method on each vertex
        for (int i = 0; i < g.Size(); i++)
        {
            // Check if we have visited the vertex
            if (!visited[i])
            {
                TopologicalSort(i);
            }
        }

        // Empty the stack into the sorted list
        while (stack.Count > 0)
        {
            sorted.Add(stack.Pop());
        }

        return sorted;
    }



    /* Find the shortest path from a starting vertex to all
     * vertices in a DAG.  This function will need to
     * call the Sort function to obtain the topologically
     * sorted list of vertices from the graph.
     *
     *  Inputs:
     *     g - Directed Acyclic Graph
     *     startVertex - Starting vertex ID
     *  Outputs:
     *     (distance list, predecessor list) 
     */
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        // Variable to represent infinity or the highest
        // distance cost
        int inf = int.MaxValue;
        // Obtain a list of verteces from the Sort method
        List<int> sorted = Sort(g);
        // A list of distances where the element at index `i`
        // represents the shortest distance from `startVertex`
        // to vertex `i`
        List<int> distance = new List<int>();
        List<int> predecessor = new List<int>();

   
        // Initialize all the elements in the distance list
        // and the predecessor list to INF.
        for (int i = 0; i < g.Size(); i++)
        {
            distance.Add(inf);
            predecessor.Add(inf);
        }

        // Set the distance of the start vertex to 0
        distance[startVertex] = 0;

        //loop through 
        foreach (int u in sorted)
        {
            // Only relax the edges if the distance to the current
            // vertex `u` is not infinity
            if (distance[u] != inf)
            {
                // Loop through each edge (u, v) with weight
                // from vertex `u`
                foreach (var edge in g.Edges(u))
                {
                    // Store the current edge destination and weight
                    int v = edge.DestId; 
                    int weight = edge.Weight;

                    // Relax the edge (u, v)
                    if (distance[u] + weight < distance[v])
                    {
                        distance[v] = distance[u] + weight;
                        predecessor[v] = u;
                    }
                }
            }
        }

        return (distance, predecessor);

    }

}