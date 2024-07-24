# Quick Sort - Algorithm Report

(c) BYU-Idaho - It is an honor code violation to post this file completed in a public file sharing site. S4.

Name: 

## 1. Code (60%)

Make sure that you submit both the QuickSort.cs file and this markdown file.

## 2. Methodology (20%)

NOTE: Do not copy/paste from an AI or the book.  Answer these questions in your own words without code.  You will either receive a grade of `Correct`, `More Detail Needed`, or `Incorrect` for each question.

1. Explain the process for determining where the selected pivot needs to be placed in the list.

The pivot is initially chosen as the last element of the current sublist being processed. The goal is to rearrange elements such that all values less than or equal to the pivot are positioned to its left, and all values greater than the pivot are positioned to its right. The partition method iterates through the sublist from the first element to the second-to-last element comparing the current element with the pivot. If the element is less than or equal to the pivot, it swaps it with the element just after the current position marker. After completing the iteration the pivot element is moved to its correct position by swapping it with the element immediately after i. Finally, the method returns the index of the pivot's correct position in the sorted array. This process continues recursively until all partitions are sorted.

2. Explain how recursion is done in the Quick Sort algorithm.

The process begins with the Sort method, which serves as the entry point taking the entire list data and initializes the sorting process by calling _Sort. Inside _Sort, the algorithm checks if the first index is less than the last index. If true, it means there are elements in the sublist that need sorting. The next step is to partition the sublist around a pivot element using the Partition method. After partitioning, the method returns the index of the pivot's correct position. Once the pivot's position is determined, _Sort recursively calls itself twice:

`_Sort(data, first, pivotIndex - 1)`: This call sorts the left partition of elements that are smaller than the pivot.
`_Sort(data, pivotIndex + 1, last)`: This call sorts the right partition of elements that are greater than the pivot.

These recursive calls continue subdividing the list until each sublist has only one element or is empty. At this point, the recursion unwinds as each recursive call completes. The base case for the recursion occurs when the sublist has zero or one element, where no further partitioning is needed.

3. Explain how a random pivot can be selected and the benefit of selecting randomly.

Selecting a random pivot in Quick Sort can lead to more consistent and predictable performance across a wide range of inputs. It reduces the likelihood of worst-case scenarios and helps achieve closer to average-case time complexity making the algorithm more robust and efficient in practice.

## 3. Performance (10%)

The performance of the sort (where $n$ is the number of items in the list):

* Worst Case: $O(n ^ 2)$
* Best Case: $\Omega(n log n)$

## 4. AI Research (10%)

NOTE: Do not copy/paste from the AI.  Describe what you learned in at least 100 of your own words.

Using an AI, explore what a stable sort is and how MergeSort can be stable and QuickSort is not.

Merge Sort is stable because it explicitly preserves the order of equal elements during the merging process. When merging two sorted subarrays, if elements with the same value are encountered from both subarrays, Merge Sort ensures that the element from the left subarray is placed before the element from the right subarray in the merged result. Quick Sort is typically not stable. The reason lies in its partitioning process, where equal elements are not necessarily maintained in their original order after partitioning around a pivot. Specifically, during the partitioning step, elements equal to the pivot can end up on either side of the pivot based on their relative positions.
