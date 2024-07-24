/* CSE 381 - Dijkstra Shortest Path
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S4.
*
*  Instructions: Implement the ShortestPath function per the instructions
*  in the comments.  Run all tests in DijkstraShortestPathTest.cs to verify your code.
*  Submit this file and the completed DijkstraShortestPath.md file into Canvas.
*/

using System.Collections.Generic;
using static AlgorithmLib.ConvexHull;

namespace AlgorithmLib;

public static class DijkstraShortestPath
{

    /* Find the shortest path from a starting vertex to all
     * vertices in a graph using Dijkstra.  Use a Priority Queue
     * (code already provided for you) in your implementation.
     *
     *  Inputs:
     *     g - Graph
     *     startVertex - Starting vertex ID
     *  Outputs:
     *     (distance list, predecessor list)
     */
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        // A reference to the number of vertecies in the graph.
        int numVertices = g.Size();
        // A list that will store the shortest known distance
        // from the starting vertex to each vertex in the graph.
        var distance = new List<int>();
        // A list that will store the previous vertex on the
        // shortest path to each vertex.
        var predecessor = new List<int>();
        // A hash set that will keep track of vertices that
        // have already been processed by the algorithm.
        var visited = new HashSet<int>();

        // Initialize all the elements in the distance list
        // and the predecessor list to INF.
        for (int i = 0; i < g.Size(); i++)
        {
            distance.Add(Graph.INF);
            predecessor.Add(Graph.INF);
        }

        // Set the distance of the start vertex to 0.
        distance[startVertex] = 0;


        // Create a priority queue to store vertices along with
        // their distances from the start vertex
        var pQueue = new PriorityQueue<(int vertex, int dist), int>();

        // Enqueue the start vertex with distance 0 into the
        // priority queue
        pQueue.Enqueue((startVertex, 0), 0);

        // Process vertices in the priority queue until all
        // vertices have been visited
        while (pQueue.Count > 0)
        {
            // Dequeue the vertex with the smallest known distance
            var (currentVertex, currentDistance) = pQueue.Dequeue();

            // Skip processing if the vertex has already been visited
            if (visited.Contains(currentVertex))
                continue;

            // Mark the current vertex as visited
            visited.Add(currentVertex);

            // Explore all outgoing edges from the current vertex
            foreach (var edge in g.Edges(currentVertex))
            {
                // Get the neighboring vertex and the weight of the edge
                int neighbor = edge.DestId;
                int weight = edge.Weight;

                // Calculate the new distance to the neighboring vertex
                int newDistance = currentDistance + weight;

                // Update the shortest distance and predecessor
                // if a shorter path is found
                if (newDistance < distance[neighbor])
                {
                    // Update the shortest distance and predecessor
                    distance[neighbor] = newDistance;
                    predecessor[neighbor] = currentVertex;
                    // Enqueue the neighboring vertex with its new
                    // distance into the priority queue
                    pQueue.Enqueue((neighbor, newDistance), newDistance);
                }
            }
        }


        return (distance, predecessor);
    } 
}



///* Generate a Convex Hull from a list of points.
//     *
//     *  Inputs:
//     *     points - List of points to create hull around
//     *  Outputs:
//     *     Return list of points in the hull
//     *
//     * NOTE: If no hull exists, then return an empty list.
//     */
//public static List<Point> GenerateHull(List<Point> points)
//{
//    if (points.Count < 3)
//        return new List<Point>(); // Return an empty list if less than 3 points

//    // Sort points lexicographically (by x and then by y)
//    points.Sort((a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));

//    // Helper function to build the hull
//    List<Point> BuildHull(List<Point> input)
//    {
//        int n = input.Count;
//        if (n <= 1)
//            return input;

//        // Build lower hull
//        var lowerHull = new List<Point>();
//        foreach (var p in input)
//        {
//            while (lowerHull.Count >= 2 && Orientation(lowerHull[lowerHull.Count - 2], lowerHull[lowerHull.Count - 1], p) != Angle.Convex)
//                lowerHull.RemoveAt(lowerHull.Count - 1);
//            lowerHull.Add(p);
//        }

//        // Build upper hull
//        var upperHull = new List<Point>();
//        for (int i = input.Count - 1; i >= 0; i--)
//        {
//            Point p = input[i];
//            while (upperHull.Count >= 2 && Orientation(upperHull[upperHull.Count - 2], upperHull[upperHull.Count - 1], p) != Angle.Convex)
//                upperHull.RemoveAt(upperHull.Count - 1);
//            upperHull.Add(p);
//        }

//        // Remove the last point of each half because it's repeated at the beginning of the other half
//        lowerHull.RemoveAt(lowerHull.Count - 1);
//        upperHull.RemoveAt(upperHull.Count - 1);

//        // Concatenate lower and upper hull to get the full hull
//        lowerHull.AddRange(upperHull);
//        return lowerHull;
//    }

//    // Build and return the hull
//    var hull = BuildHull(points);

//    // Ensure the hull is closed by adding the first point again at the end
//    hull.Add(hull[0]);

//    return hull;
//}