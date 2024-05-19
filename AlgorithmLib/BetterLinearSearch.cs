﻿/* CSE 381 - BetterLinearSerach
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S4.
*
*  Instructions: Implement the Search function per the instructions
*  in the comments.  Run all tests in BetterLinearSearchTest.cs to verify your code.
*  Submit this file into Canvas.
*/

namespace AlgorithmLib;

public static class BetterLinearSearch
{

    /******************************************************
     * Search for an item in a list.  Ignore duplicates by 
     * exiting as soon as the first match is found.
     *
     *  Inputs:
     *     data - list to search
     *     target - value to search for
     *  Outputs:
     *     Index where target was found
     *
     *  Note: Return -1 if target not found
     *****************************************************/
    public static int Search<T>(List<T> data, T target) where T : IComparable<T>
    {
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].CompareTo(target) == 0)
            {
                return i; // Found the target, return its index
            }
        }

        return -1; // Target not found
    }
}