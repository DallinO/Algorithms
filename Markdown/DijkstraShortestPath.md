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

A heuristic function is a problem-solving approach used in various fields like computer science and artificial intelligence when finding an exact solution is either computationally impractical or too time-consuming. These functions provide approximate solutions quickly by leveraging domain-specific knowledge or rules of thumb. Unlike exact methods, heuristics prioritize efficiency over precision, aiming to deliver solutions that are sufficiently good for practical purposes but may not be optimal. They are designed to be computationally efficient, making them suitable for complex problems where exhaustive search or exact computation is infeasible.


## 3. Performance (10%)

The performance for the shortest path (where $V$ is the number of vertices in the graph and $E$ is the number of edges):

* Using an Array:
    * Worst Case: $O(V^2 + E)$
    * Best Case: $\Omega((V+E) * log(V))$

* Using a Priority Queue:
    * Worst Case: $O((V+E) * log(V))$
    * Best Case: $\Omega((V+E) * log(V))$

## 4. AI Research (10%)

NOTE: Do not copy/paste from the AI.  Describe what you learned in at least 100 of your own words.

Using an AI, explore the use of the use of the A* algorithm to find the shortest path with road maps and compare it with Dijkstra.

Dijkstra's algorithm is renowned for its ability to find the shortest path in graphs with varying edge weights, making it versatile in various scenarios without needing adjustments. However, its performance can lag on large graphs due to its exhaustive nature. In contrast, A* algorithmically enhances efficiency by employing heuristic functions that guide pathfinding towards the goal, offering potential speed gains. Yet, A* relies heavily on the accuracy of these heuristics; inaccurate heuristics can lead to suboptimal path choices. This characteristic demands careful consideration and tailoring of heuristics to specific problem domains to achieve optimal performance gains over Dijkstra's algorithm, particularly noticeable in larger and more complex graph structures.