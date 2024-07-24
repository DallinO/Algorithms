# Merge Sort - Algorithm Report

(c) BYU-Idaho - It is an honor code violation to post this file completed in a public file sharing site. S4.

Name: 

## 1. Code (60%)

Make sure that you submit both the MergeSort.cs file and this markdown file.

## 2. Methodology (20%)

NOTE: Do not copy/paste from an AI or the book.  Answer these questions in your own words without code.  You will either receive a grade of `Correct`, `More Detail Needed`, or `Incorrect` for each question.

1. Explain the base cases in the Merge Sort algorithm.

In the Merge Sort algorithm the base case occurs when first is equal to last in the sublist being sorted. This signifies that the sublist contains only one element, which is inherently sorted. At this point, the recursion stops splitting the list into smaller sublists and begins merging them back together. Another base case is when the sublist has no elements. These base cases ensure that every division of the list ultimately leads to sorting individual elements or pairs of elements enabling the algorithm to efficiently merge and sort the entire list.

2. Explain the recursive cases in the algorithm.

The recursive cases in Merge Sort recursively divide the list into smaller sublists, sort each sublist individually using the divide and conquer strategy, and then merge the sorted sublists back together to produce a fully sorted list. This recursive approach guarantees that the sorting is performed efficiently. The `_Sort` method recursively divides the list into two halves. It computes the midpoint of the current sublist defined by `first` and `last`. It then recursively calls `_Sort` on the left half and the right half.

3. Explain how the algorithm merges two sorted lists into a single sorted list.

The merge method determines the sizes of the left and right subarrays based on the midpoint, creates temporary arrays, and copies elements from the original data list into these arrays. It then merges elements from leftArray and rightArray back into the original data list in sorted order. Using designated indices the method compares elements from leftArray and rightArray, placing the smaller or equal element into data at each step. This merging process ensures that all elements are correctly sorted as the algorithm combines increasingly larger sorted sublists until the entire original list is sorted.

## 3. Performance (10%)

The performance of the sort (where $n$ is the number of items in the list):

* Worst Case: $O(n log n)$
* Best Case: $\Omega(n log n)$

## 4. AI Research (10%)

NOTE: Do not copy/paste from the AI.  Describe what you learned in at least 100 of your own words.

Using an AI, explore how Bottom-Up MergeSort works and how it compares with Top-Down MergeSort (which is the version we have been using).

Bottom-Up Merge Sort takes a distinctive approach by first dividing the array into smaller sorted sublists, gradually merging them into larger, sorted lists. This method contrasts with Top-Down Merge Sort, which recursively divides the array into halves until sorting each segment individually. Despite these structural differences, both algorithms achieve the same time complexity of O(nlogn) in both worst and average cases, making them efficient for large datasets. However, Bottom-Up Merge Sort's iterative nature may introduce a slightly higher constant factor compared to Top-Down due to its sequential merging process. Nonetheless, it remains a practical choice for sorting due to its systematic and predictable performance characteristics.