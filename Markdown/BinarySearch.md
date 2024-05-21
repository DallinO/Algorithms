# Binary Search - Algorithm Report

(c) BYU-Idaho - It is an honor code violation to post this file completed in a public file sharing site. S4.

Name: Dallin Olson

## 1. Code (60%)

Make sure that you submit both the BinarySearch.cs file and this markdown file.

## 2. Methodology (20%)

NOTE: Do not copy/paste from an AI or the book.  Answer these questions in your own words without code.  You will either receive a grade of `Correct`, `More Detail Needed`, or `Incorrect` for each question.

1. Explain the differences between the Binary Search Algorithm and the Linear Search.
In a linear search we iterate through the collection in order from start to finish (or vice versa) visiting each element and checking if it matched our target. In a binary search algorithm we instead narrow our search by spliting our collection in half, determine if the mid point is the target, if not we determine if the target lies to the right or to the left of the midpoint and repeat our search on that half.

2. Explain the base cases in the Binary Search algorithm.
The base case in the binary search algorithm is if our `first` is greater than our `last` there are no more elements left to search so we return -1 indicating that the target does not exist in the collection.

3. Explain the recursive cases in the algorithm.
If the mid is greater than the target, we will recusivly call the `_Search` function and narrow our search scope to the left side of the list. Otherwise we search the right side. We do this by setting the first or last value to be 1 less than or greater than the mis point respectivly.

## 3. Performance (10%)

The performance for the search (where $n$ is the number of items in the list):

* Worst Case: $O(log n)$
* Best Case: $\Omega(1)$

## 4. AI Research (10%)

NOTE: Do not copy/paste from the AI.  Describe what you learned in at least 100 of your own words.

Using an AI, explore the differences between recursive and non-recursive implementations of Binary Search.  Describe what you learned.

The recursize binary search uses recursion to repeat the searching process. The advatages of using recursion is that recursion tends to be more consise and elegant in terms of code structure and it is earlier for programmers who are familiar with recursion to understand. However recursion calls can lead to higher overhead due to the function call stack. In languages or enviroments with limited stack space, recursive implemetations can lead to stack over flow errors for large collections.

Non-recursive binary search algorithms use a loop inplace of recursion to iterativley divide the array and search for the target. The primary advantage of using iterative loops is avoiding the overhead of function calls potentionall making them more effecient in terms of memory usage and performance. However, non-recursive implementations tend to be longer and less concise. 


