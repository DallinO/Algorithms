# String Matcher (KMP) - Algorithm Report

(c) BYU-Idaho - It is an honor code violation to post this file completed in a public file sharing site. S4.

Name: 

## 1. Code (60%)

Make sure that you submit both the StringMatcher.cs file and this markdown file.

## 2. Methodology (20%)

NOTE: Do not copy/paste from an AI or the book.  Answer these questions in your own words without code.  You will either receive a grade of `Correct`, `More Detail Needed`, or `Incorrect` for each question.

1. Explain the process for determining the next state in the Finite State Machine if the next value received matches the next value in the pattern.

When determining the next state in a Finite State Machine for pattern matching, you start with the current state, representing the length of the pattern successfully matched so far. When receiving the next input character, you first check if there's a direct transition defined in the FSM table. If such a transition exists, the next state is set to this value. If no direct transition exists, you can retrieve the longest prefix suffix of the pattern up to the current state for character c from the FSM table. the next state is then set to this LPS value which indicates the longest prefix of the pattern that also acts as a suffix up to the current position in the text. This approach helps efficient pattern matching by guiding the FSM to the appropriate state.

2. Explain the process for determining the next state in the Finite State Machine if the next value received does not match the next value in the pattern.

After encountering a mismatch you start with the current state. Upon receiving a character from the input that does not match the expected character in the pattern, you consult the FSM table to retrieve the LPS value for the current state and character. This LPS value indicates the longest prefix of the pattern that is also a suffix up to the current position in the text. The next state is then set to this LPS value, guiding the FSM to transition to the state where the pattern matches the longest possible prefix that could potentially restart the matching process after the mismatch.

3. Explain how the generated FSM table is used to search for matches of a pattern in a line of text.

Starting from an initial state the algorithm iterates through each character in the text updating its current state based on transitions defined in the FSM table. For each character encountered, the algorithm checks the corresponding entry in the FSM table to determine the next state. If the current state matches the length of the pattern, a complete match is identified, and the starting position of this match in the text is recorded. In cases where there is no transition for a character in the current state, indicating a mismatch, the algorithm uses information from the FSM table to transition to a state that represents the longest prefix suffix for the current state and character.

## 3. Performance (10%)

The performance of the matching assuming the finite state machine table is already built (where $n$ is the length of the text being checked)

* Worst Case: $O(n)$
* Best Case: $\Omega(n)$

## 4. AI Research (10%)

NOTE: Do not copy/paste from the AI.  Describe what you learned in at least 100 of your own words.

Using an AI, explore how KMP is used in bio-informatics.

The KMP algorithm can efficiently search for specific patterns within DNA sequences and protiens. This is crucial for identifying genes, regulatory elements, or mutations associated with diseases. These motifs may represent binding sites for regulatory proteins or conserved regions indicating functional importance. In genome assembly, where short DNA sequences need to be assembled into longer contiguous sequences, KMP can help detect overlaps between reads. KMP can efficiently compare protein sequences against databases of known sequences, helping to classify proteins based on their structural or functional similarities. KMP is used to align sequences and find matches or alignments between DNA or protein sequences. This aids in comparative genomics studies, where understanding similarities and differences between genomes or proteins is essential.


