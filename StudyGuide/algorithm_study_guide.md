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
|Binary Search                    |                   |                        |                        |
|Merge Sort                       |                   |                        |                        |
|Quick Sort                       |                   |                        |                        |
|DAG Shortest Path (^)            |                   |                        |                        |
|Dijkstra Shortest Path - Array   |                   |                        |                        |     
|Dijkstra Shortest Path - PriQueue|                   |                        |                        |     
|Bellman-Ford Shortest Path       |                   |                        |                        |
|String Matcher (KMP) (^^)        |                   |                        |                        |
|Modular Exponentiation           |                   |                        |                        |
|Huffman Tree (^^^)               |                   |                        |                        |
|Convex Hull (Graham Scan)        |                   |                        |                        |

Notes:
* ^ - Including the Topo Sort
* ^^ - Excluding FSM generation
* ^^^ - Encoding and Decoding

If Best Case or Average Case is different from Worst Case, then explain why for each algorithm:

## Master Theorem

1. What is the master theorem formula?

2. What are the 3 cases?

* Case 1:

* Case 2:

* Case 3:

3. Use Master Theorem with Binary Search:


4. Use Master Theorem with Merge Sort:


## Graphs - Sparse vs Dense

1. What is the relationship between Edges and Vertices in a Sparse Graph?

2. What is the relationship between Edges and Vertices in a Dense Graph?

3. Fill in the following table using only $V$:

|Algorithm                        |Graph |Worst Case $O$    |Best Case $\Omega$    |
|---------------------------------|----- |------------------|----------------------|
|DAG Shortest Path                |      |                  |                      |
|                                 |Sparse|                  |                      |
|                                 |Dense |                  |                      |
|Dijkstra Shortest Path - Array   |      |                  |                      |
|                                 |Sparse|                  |                      |
|                                 |Dense |                  |                      |
|Dijkstra Shortest Path - PriQueue|      |                  |                      |
|                                 |Sparse|                  |                      |
|                                 |Dense |                  |                      |
|Bellman-Ford Shortest Path       |      |                  |                      |
|                                 |Sparse|                  |                      |
|                                 |Dense |                  |                      |

4. When should I use DAG Shortest Path?

5. When should I use Dijkstra Shortest Path with an Array?

6. When should I use Dijkstra Shortest Path with a Priority Queue?

7. When should I use Bellman-Ford Shortest Path?






