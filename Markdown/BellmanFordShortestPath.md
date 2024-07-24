# Bellman Ford - Algorithm Report

(c) BYU-Idaho - It is an honor code violation to post this file completed in a public file sharing site. S4.

Name: 

## 1. Code (60%)

Make sure that you submit both the BellmanFord.cs file and this markdown file.

## 2. Methodology (20%)

NOTE: Do not copy/paste from an AI or the book.  Answer these questions in your own words without code.  You will either receive a grade of `Correct`, `More Detail Needed`, or `Incorrect` for each question.

1. Explain why the Bellman Ford algorithm attempts to relax all the edges V-1 times (where V is the number of verticies).

The Bellman-Ford algorithm attempts to relax all the edges V-1 times to ensure that it finds the shortest paths in a graph without negative cycles. During each iteration, the algorithm updates the distance estimates for each vertex by considering all the edges in the graph. By performing V-1 iterations, the algorithm ensures that the shortest path distances are propagated through the graph from the source vertex to all the other vertices which captures the shortest paths within the graph.

2. Explain how this algorithm is a better choice for graphs with negative weights as compared with Dijkstra.

The Bellman-Ford algorithm is a better choice for graphs with negative weights compared to Dijkstra's algorithm because it can handle negative weight edges without any issues, as long as there are no negative cycles reachable from the source vertex. Bellman-Ford also has the ability to detect the presence of negative cycles. If there is a negative cycle reachable from the source vertex, Bellman-Ford detects it during its execution and reports that no shortest paths exist due to the presence of the negative cycle.

3. Explain how this algorithm can detect a negative cycle.  Can the algorithm detect a positive cycle?

During the relaxation step, the algorithm iterates over all edges multiple times, updating the distance estimates for vertices. In each iteration, it attempts to improve the shortest path estimates by considering all edges. After performing V-1 iterations, if the algorithm continues to find shorter paths in subsequent iterations, it indicates the presence of a negative cycle. By observing that the algorithm still finds shorter paths after V-1 iterations, it finds that there must be a negative cycle reachable from the source vertex. The algorithm then terminates and reports that no shortest paths exist due to the presence of the negative cycle.

## 3. Performance (10%)

The performance for the shortest path (where $V$ is the number of vertices in the graph and $E$ is the number of edges):

* Worst Case: $O(V + E)$
* Best Case: $\Omega(V * E)$

## 4. AI Research (10%)

NOTE: Do not copy/paste from the AI.  Describe what you learned in at least 100 of your own words.

Using an AI, explore the different ways that searching for negative cycles with Bellman Ford is useful. 

In finance, negative cycles can represent arbitrage opportunities, where you can profit from a series of trades without any initial investment. Negative cycles in certain types of data can indicate flaws or errors. For example, in transportation networks, a negative cycle might indicate a problem with the data, such as a road segment being erroneously marked as allowing travel in both directions. Negative cycles can lead to infinite loops in algorithms that traverse graphs. By detecting negative cycles, you can prevent algorithms like pathfinding or resource allocation from getting stuck in such loops and ensure termination. In resource allocation problems, negative cycles can represent inefficiencies or redundancies. Negative cycles in networks can indicate vulnerabilities or points of failure. In game theory models, negative cycles can indicate inconsistencies or contradictions in strategies or payoffs.

