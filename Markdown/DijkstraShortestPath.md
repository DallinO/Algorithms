# Dijkstra Shortest Path - Algorithm Report

(c) BYU-Idaho - It is an honor code violation to post this file completed in a public file sharing site. S4.

Name: 

## 1. Code (60%)

Make sure that you submit both the DijkstraShortestPath.cs file and this markdown file.

## 2. Methodology (20%)

NOTE: Do not copy/paste from an AI or the book.  Answer these questions in your own words without code.  You will either receive a grade of `Correct`, `More Detail Needed`, or `Incorrect` for each question.

1. Explain why Dijkstra relaxes the edges of verticies with the currently smallest calculated shortest path distance first.

The algorithm relaxes the edges of vertices with the currently smallest calculated shortest path distance first to ensure that it explores the graph in a manner that guarantees the shortest paths are found correctly and efficiently. By relaxing the edges of vertices with the smallest known distance first, it ensures that it explores the most promising paths first and guarantees that it explores the shortest paths incrementally, which generally leads to discovering shorter paths sooner. This approach minimizes redundant exploration of longer paths and focuses the algorithm's efforts on discovering the shortest paths efficiently.

2. Explain the process of relaxing the edges adjacent to a vertex.

Relaxing the edges adjacent to a vertex means to update the shortest known distances to the neighboring vertices if a shorter path is found through the current vertex. This process continues until the algorithm has explored all possible paths and found the shortest path to each vertex from the starting point.

3. Explain how the Priority Queue works and how it can be used with Dijkstra.

The priority queue is designed to facilitate the selection of vertices with the smallest known distances. This enables efficient exploration of the graph and ensures that the shortest paths are found correctly and efficiently. When a vertex is dequeued from the priority queue, it relaxes the edges outgoing from that vertex. If a shorter path to a neighboring vertex is found, the neighboring vertex is enqueued with its updated distance as the priority.


## 3. Performance (10%)

The performance for the shortest path (where $V$ is the number of vertices in the graph and $E$ is the number of edges):

* Using an Array:
    * Worst Case: $O(V * E)$
    * Best Case: $\Omega(V * E))$

* Using a Priority Queue:
    * Worst Case: $O(E * log(V))$
    * Best Case: $\Omega(E * log(V))$

## 4. AI Research (10%)

NOTE: Do not copy/paste from the AI.  Describe what you learned in at least 100 of your own words.

Using an AI, explore the use of the use of the A* algorithm to find the shortest path with road maps and compare it with Dijkstra.

Dijkstra's algorithm guarantees the shortest path but can be slow on large graphs. A* is generally faster but may return suboptimal paths if the heuristic is not accurate. A* is often more efficient than Dijkstra's algorithm, especially on large graphs, due to its ability to guide the search using the heuristic function. However the quality of the heuristic function used in A* greatly influences its performance. Dijkstra's algorithm is more versatile and can handle graphs with varying edge weights without modifications. A* requires a suitable heuristic tailored to the problem.