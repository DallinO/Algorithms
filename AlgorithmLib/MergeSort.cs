/* CSE 381 - Merge Sort
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S4.
*
*  Instructions: Implement the Merge and _Sort functions per the instructions
*  in the comments.  Run all tests in MergeSortTest.cs to verify your code.
*  Submit this file and the completed MergeSort.md file into Canvas.
*/

namespace AlgorithmLib;

public static class MergeSort
{
    /* Use Merge Sort to sort a list of values in place
        *
        *  Inputs:
        *     data - list of values
        *  Outputs:
        *     none
        */
    public static void Sort<T>(List<T> data) where T : IComparable<T>
    {
        // Start the recursive process with the whole list
        _Sort(data, 0, data.Count - 1);
    }

    /* Recursively use merge sort to sort a sublist
        * defined by first and last.
        * 
        *  Inputs:
        *     data - list of values
        *     first - the start of the sublist
        *     last - the end of the sublist
        *  Outputs:
        *     None
        */
    private static void _Sort<T>(List<T> data, int first, int last) where T : IComparable<T>
    {
        if (first < last)
        {
            int mid = (first + last) / 2;
            _Sort(data, first, mid); // Sort the left half
            _Sort(data, mid + 1, last); // Sort the right half
            Merge(data, first, mid, last); // Merge the sorted halves
        }
    }

    /* Merge two sorted lists which are adjacent to each other back into
        * the same list.
        *
        *  Inputs:
        *     data - list of values
        *     first - the start of the first sorted sublist
        *     mid - the end of the first sorted sublist (second sublist starts after)
        *     last - the end of the second sorted sublist
        *  Outputs:
        *     None
        */
    private static void Merge<T>(List<T> data, int first, int mid, int last) where T : IComparable<T>
    {
        int leftSize = mid - first + 1;
        int rightSize = last - mid;

        T[] leftArray = new T[leftSize];
        T[] rightArray = new T[rightSize];

        // Copy data to temporary arrays
        for (int i = 0; i < leftSize; i++)
        {
            leftArray[i] = data[first + i];
        }
        for (int j = 0; j < rightSize; j++)
        {
            rightArray[j] = data[mid + 1 + j];
        }

        int leftIndex = 0;
        int rightIndex = 0;
        int mergeIndex = first;

        // Merge the two arrays back into data
        while (leftIndex < leftSize && rightIndex < rightSize)
        {
            if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) <= 0)
            {
                data[mergeIndex] = leftArray[leftIndex];
                leftIndex++;
            }
            else
            {
                data[mergeIndex] = rightArray[rightIndex];
                rightIndex++;
            }
            mergeIndex++;
        }

        // Copy remaining elements of leftArray, if any
        while (leftIndex < leftSize)
        {
            data[mergeIndex] = leftArray[leftIndex];
            leftIndex++;
            mergeIndex++;
        }

        // Copy remaining elements of rightArray, if any
        while (rightIndex < rightSize)
        {
            data[mergeIndex] = rightArray[rightIndex];
            rightIndex++;
            mergeIndex++;
        }
    }
}
