# DAG Shortest Path - Algorithm Report

(c) BYU-Idaho - It is an honor code violation to post this file completed in a public file sharing site. S4.

Name: 

## 1. Code (60%)

Make sure that you submit both the DAGShortestPath.cs file and this markdown file.

## 2. Methodology (20%)

NOTE: Do not copy/paste from an AI or the book.  Answer these questions in your own words without code.  You will either receive a grade of `Correct`, `More Detail Needed`, or `Incorrect` for each question.

1. Explain how the verticies in a DAG are topologically sorted.
First we set up our data structures. A list is created to store the sorted indexes. A stack is used to keep track of the order in which the vertices are visited. An array is used to keep track of the vertexes that have already been visited. A helper function is created to perform the depth first search. Within the helper function we mark the vertex as visited, then for each edge in the vertexes edges, we recursively call the helper function if the destination of the edge has not been visited. Our base case is after having visited each edge for a vertex, we push the vertex onto the stack. Back in the main body we use a for loop to execute the helper function on all of the vertices that have not been visited. Lastly we empty the stack into the list and return the list.

2. Explain why we need to topologically sort the vertices to find the shortest path in a DAG.
We need to topologically sort the vertices because it ensures that we process each vertex only after all of its predecessors have been processed. This allows for the efficient relaxation of edges, making sure that when we reach a vertex, we have already computed the shortest paths to all vertices that came before it.

3. Explain how the algorithm finds the shortest distance to a vertex as it loops through each of the verticies in the toplogically sorted vertex list.
The algorithm iterates over each vertex in the sorted list, checks if the vertex is reachable, and then relaxes all its outgoing edges to find shorter paths to its neighbors. By ensuring that vertices are sorted in topological order, it guarantees that all necessary shortest path updates are made in an efficient and correct manner.

## 3. Performance (10%)

The performance for the shortest path (where $V$ is the number of verticies in the graph and $E$ is the number of edges):

* Worst Case: $O(V + E)$
* Best Case: $\Omega(V + E)$

## 4. AI Research (10%)

NOTE: Do not copy/paste from the AI.  Describe what you learned in at least 100 of your own words.

Using an AI, explore the use of the DAG data structure used in the Git version control softare.
Each commit in Git is represented as a node in the DAG. A commit contains the metadata and a snapshot of the project's file system at the time of the commit. Directed edges in the DAG connect each commit to its parent. If a commit has one parent, it indicates a linear progression of changes. If a commit has multiple parents, it represents a merge operation where different branches of history converge. The graph is acyclic, meaning there are no loops. You cannot trace back from a commit to itself by following the parent-child relationships, which reflects the chronological order of commits.
