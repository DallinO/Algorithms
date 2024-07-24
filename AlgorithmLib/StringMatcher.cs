/* CSE 381 - String Matcher (KMP)
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S4.
*
*  Instructions: Implement the Match and BuildTable functions per the instructions
*  in the comments.  Run all tests in StringMatcherTest.cs to verify your code.
*  Submit this file and the completed StringMatcher.md file into Canvas.
*/

using System.Collections.Generic;

namespace AlgorithmLib;

public static class StringMatcher
{
    /* Find all matches of the pattern in the string of text given a list
     * of all valid input characters.  This function needs to build Finite
     * State Machine table by calling BuildTable.
     *
     *  Inputs:
     *     text - string to search for pattern
     *     pattern - string to search
     *     inputs - valid characters using in the text and pattern
     *  Outputs:
     *     list of indices where the pattern matched (last char of pattern match)
     */
    public static List<int> Match(string text,  string pattern, List<char> inputs)
    {
        List<Dictionary<char, int>> fsm = BuildTable(pattern, inputs);
        List<int> matches = new List<int>();

        int state = 0;
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (fsm[state].ContainsKey(c))
            {
                state = fsm[state][c];
                if (state == pattern.Length)
                {
                    // Pattern matched ending at position i
                    matches.Add(i); 
                    // reset state
                    state = fsm[state - 1][pattern[state - 1]]; 
                }
            }
            else
            {
                // Reset state if character not found in the transitions
                state = 0; 
            }
        }

        return matches;
    }

    /* Build the Finite State Machine table for the pattern and list of valid
     * inputs provided.
     *
     *  Inputs:
     *     pattern - string to match
     *     inputs - valid list of characters that could be seen
     *  Outputs:
     *     Finite State Machine defined by a list of dictionaries.  Each index
     *     in the list represents a state in the FSM (index 0 is first).  The
     *     dictionary shows the next state to goto for each of the valid
     *     inputs that can occur.
     */
    public static List<Dictionary<char, int>> BuildTable(string pattern, List<char> inputs)
    {
        int m = pattern.Length;
        List<Dictionary<char, int>> fsm = new List<Dictionary<char, int>>();

        // Initialize the FSM with m+1 states
        for (int i = 0; i <= m; i++)
        {
            fsm.Add(new Dictionary<char, int>());
            foreach (char c in inputs)
            {
                // Default state transition
                fsm[i][c] = 0;
            }
        }

        // Build the table
        // Length of the longest prefix suffix (LPS) - initially 0
        int lps = 0; 
        for (int i = 0; i <= m; i++)
        {
            // Update transitions for current state based on previous state and current character
            foreach (char c in inputs)
            {
                fsm[i][c] = fsm[lps][c];
            }

            // If not end of pattern, update the next state for pattern[i]
            if (i < m)
            {
                fsm[i][pattern[i]] = i + 1;

                // Update lps to be used in the next iteration
                if (i > 0)
                {
                    lps = fsm[lps][pattern[i]];
                }
            }
        }

        return fsm;
    }
}