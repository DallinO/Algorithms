# CSE 381 - Performance Study Guide

(c) BYU-Idaho - It is an honor code violation to post this file completed in a public file sharing site. S4.

Name: 

**Instructions**

1. Complete this document throughout the semester and submit during Week 12. We will discuss these topics during class.

2. This document is worth 25% of your final exam.  The teacher will not check for correctness.  After submitting during Week 12, we will review the correct answers to everything in this document.  You will want to correct any mistakes in your copy.

3. Some of the questions on the multiple choice section of the Final Exam will be related to content in this document.  You can use this document during the exam.

## Performance Table

|Algorithm                        |Worst Case $O$     |Best Case $\Omega$      |Average Case $\Theta$   |
|---------------------------------|-------------------|------------------------|------------------------|
|Binary Search                    |$O(\log n)$|$\Omega(1)$|$\Theta(\log n)$|
|Merge Sort                       |$O(n \log n)$|$\Omega(n \log n)$|$\Theta(n \log n)$|
|Quick Sort                       |$O(n^2)$|$\Omega(n \log n)$|$\Theta(n \log n)$|
|DAG Shortest Path (^)            |$O(V + E)$|$\Omega(V + E)$|$\Theta(V + E)$|
|Dijkstra Shortest Path - Array   |$O(V^2)$|$\Omega(V^2)$|$\Theta(V^2)$|     
|Dijkstra Shortest Path - PriQueue|$O((V + E) \log V)$|$\Omega(V \log V)$|$\Theta((V + E) \log V)$|     
|Bellman-Ford Shortest Path       |$O(VE)$|$\Omega(E)$|$\Theta(VE)$|
|String Matcher (KMP) (^^)        |$O(m + n)$|$\Omega(m + n)$|$\Theta(m + n)$|
|Modular Exponentiation           |$O(\log n)$|$\Omega(\log n)$|$\Theta(\log n)$|
|Huffman Tree (^^^)               |$O(n \log n)$|$\Omega(n \log n)$|$\Theta(n \log n)$|
|Convex Hull (Graham Scan)        |$O(n \log n)$|$\Omega(n \log n)$|$\Theta(n \log n)$|

Notes:
* ^ - Including the Topo Sort
* ^^ - Excluding FSM generation
* ^^^ - Encoding and Decoding

If Best Case or Average Case is different from Worst Case, then explain why for each algorithm:

Binary Search:

    Worst case occurs when the element is not present or is located at one of the extremes of the search space. Best case occurs when the target element is found at the middle position in the first comparison. The best case is different from the worst case because, in the best case, the search terminates immediately after the first comparison.

Quick Sort:

    Worst case occurs when the pivot selection results in highly unbalanced partitions, such as when the array is already sorted and the first or last element is always chosen as the pivot. Best case occurs when the pivot selection leads to balanced partitions, dividing the array into roughly equal halves. Average case generally achieved with good pivot selection, resulting in reasonably balanced partitions. The pivot selection strategy significantly affects the performance. Balanced partitions minimize the depth of the recursion tree, leading to logarithmic height, whereas unbalanced partitions maximize it.

Dijkstra's Shortest Path - PriQueue:

    Worst case happens when every edge needs to be relaxed and the priority queue operations are extensive. Best case occurs in sparse graphs where the number of edges is much smaller than the number of vertices. The number of edges influences the number of priority queue operations, making the algorithm faster in sparse graphs and slower in dense graphs.

Bellman-Ford Shortest Path:

    Worst case occurs when the algorithm needs to relax the edges $V-1$ times to ensure the shortest path is found. Best case occurs when the shortest path is found in the first pass through the edges. If all shortest paths are found early, fewer iterations are needed. However, in the worst case, all $V-1$ iterations are required to find the shortest path for all vertices.

Best case is when the target element is found at the middle position in the first comparison.

## Master Theorem

1. What is the master theorem formula?

The Master Theorem provides a way to analyze the time complexity of recursive algorithms that can be expressed in the form of a recurrence relation:

T(n)=aT(bn​)+f(n)

2. What are the 3 cases?

* Case 1:

    If f(n)=O(nc) for some c<logb​a, then T(n)=Θ(nlogb​a).

* Case 2:

    If f(n)=Θ(nlogb​a), then T(n)=Θ(nlogb​alogn).

* Case 3:

    If f(n)=Ω(nc) for some c>log⁡bac>logb​a and af(bn​)≤kf(n) for some constant k<1 and sufficiently large n, then T(n)=Θ(f(n)).

3. Use Master Theorem with Binary Search:

Start with its recurrence relation: T(n)=T(2n​)+O(1). Here, a=1, b=2, and f(n)=O(1). We apply the Master Theorem, which compares f(n) with nlog⁡banlogb​a. For Binary Search, logb​a=log2​1=0, so nlogb​a=1. Since f(n)=O(1) matches O(n0), we fall into Case 1 of the Master Theorem, where f(n) grows slower than nlog⁡banlogb​a. Thus, T(n)=Θ(nlogb​a)=Θ(1). However, considering the actual recurrence, each step reduces the problem size by half, requiring log2​n steps, each taking constant time O(1). This results in an overall time complexity of O(logn). Therefore, Binary Search has a time complexity of O(logn), confirmed by the Master Theorem analysis.

4. Use Master Theorem with Merge Sort:

Begin with its recurrence relation: T(n)=2T(2/n​)+O(n). Here, a=2, b=2, and f(n)=O(n). Applying the Master Theorem, we calculate logb​(a), which in this case is log⁡2(2)=1, so n^(logb​(a))=n. We compare f(n) to n^(logb​(a)) and find that f(n)=Θ(n) matches n^(logb(​a)). This fits Case 2 of the Master Theorem, which states that if f(n)=Θ(n^(logb(​a))), then T(n)=Θ(n^(logb(​a)) * logn). Therefore, the time complexity of Merge Sort is Θ(nlogn).

## Graphs - Sparse vs Dense

1. What is the relationship between Edges and Vertices in a Sparse Graph?

A sparse graph refers to a graph structure where the number of edges EE is significantly smaller compared to the number of vertices VV. Specifically, in a sparse graph, the edge count scales linearly or sub-linearly with respect to the number of vertices, typically described by E=O(V). This characteristic implies that there are relatively few connections between vertices, resulting in a low edge density. Sparse graphs are prevalent in scenarios where connections are sparse or limited, such as in networks with isolated nodes or graphs resembling trees. They contrast sharply with dense graphs, where edges are nearly as numerous as the maximum possible connections between vertices, resulting in a high edge density approaching 1. Understanding whether a graph is sparse or dense helps in selecting appropriate algorithms and optimizations tailored to the graph's structure and connectivity patterns.

2. What is the relationship between Edges and Vertices in a Dense Graph?

A dense graph refers to a graph structure where the number of edges EE is close to the maximum possible number of edges that could exist between the vertices VV. This relationship typically scales quadratically, denoted as E=O(V2). Dense graphs exhibit a high edge density, where most vertices are interconnected through numerous edges. This characteristic contrasts with sparse graphs, where the number of edges is much smaller relative to the number of vertices. Examples of dense graphs include complete graphs, where every pair of distinct vertices is connected by exactly one edge, and graphs with high connectivity where nearly every vertex is directly or indirectly connected to others. Recognizing whether a graph is dense or sparse is crucial for selecting appropriate algorithms and optimizations suited to the graph's connectivity and structural properties.


3. Fill in the following table using only $V$:

|Algorithm                        |Graph |Worst Case $O$    |Best Case $\Omega$    |
|---------------------------------|----- |------------------|----------------------|
|DAG Shortest Path                |      |O(V+E)|Ω(V+E)|
|                                 |Sparse|O(V+V)=O(V)|Ω(V+V)=Ω(V)|
|                                 |Dense |O(V+V^2)|Ω(V+V^2)|
|Dijkstra Shortest Path - Array   |      |O(V^2)|Ω(V+V)=Ω(V)|
|                                 |Sparse|O(V^2)|Ω(V)|
|                                 |Dense |O(V^2)|Ω(V)|
|Dijkstra Shortest Path - PriQueue|      |O((V+E)logV)|Ω(V+E)|
|                                 |Sparse|O((V+V)logV)=O(VlogV)|Ω(V+V)=Ω(V)|
|                                 |Dense |O((V+V^2)logV)|Ω(V+V^2)|
|Bellman-Ford Shortest Path       |      |O(VE)|Ω(V+E)|
|                                 |Sparse|O(V⋅V)=O(V^2)|Ω(V+V)=Ω(V)|
|                                 |Dense |O(V⋅V^2)=O(V3)|Ω(V+V^2)|

4. When should I use DAG Shortest Path?

One should use the DAG Shortest Path algorithm when you have a directed acyclic graph and need to efficiently compute shortest paths from a single source vertex to all other vertices. Its efficiency and applicability make it suitable for various real-world scenarios involving dependency management and optimization.

5. When should I use Dijkstra Shortest Path with an Array?

One should use Dijkstra's Shortest Path algorithm with an array when you have a graph with non-negative edge weights and you need an efficient way to find the shortest paths from a single source vertex to all other vertices. It is particularly effective for sparse graphs and situations where the simplicity of the array-based implementation outweighs the potential benefits of more complex data structures like priority queues.

6. When should I use Dijkstra Shortest Path with a Priority Queue?

One should use Dijkstra's Shortest Path algorithm with a priority queue when you have a graph with non-negative edge weights and you need an efficient method to find the shortest paths from a single source vertex to all other vertices. It excels in scenarios involving sparse graphs, larger graphs, or where the graph is dense and efficiency is paramount.

7. When should I use Bellman-Ford Shortest Path?

One should use the Bellman-Ford Shortest Path algorithm when you need to handle graphs with negative edge weights, detect negative cycles, or when the flexibility of handling varying edge weights and graph structures is required. It is particularly useful in applications involving dynamic graphs or scenarios where negative weights are a possibility.
