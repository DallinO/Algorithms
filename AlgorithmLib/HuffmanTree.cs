/* CSE 381 - Huffman Tree
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S4.
*
*  Instructions: Implement the Profile, BuildTree, _CreateEncodingMap,
*  Encode, and Decode function per the instructions in the comments.  
*  Run all tests in HuffmanTreeTest.cs to verify your code.
*  Submit this file and the completed HuffmanTree.md file into Canvas.
*/

using System.Text;

namespace AlgorithmLib;

public static class HuffmanTree
{
    /* Represent the nodes in the Huffman Tree */
    public class Node
    {
        // Letter represented by the node.  Can be blank.
        public char Letter { get; set; }

        // Frequency of letters in the sub-tree beginning with this node
        public int Count { get; set; }

        // Left and Right sub-trees (can be Null)
        public Node? Left;
        public Node? Right;
    }

    /* Create a profile showing the frequency of all letters
     * from a string of text.
     *
     *  Inputs:
     *     text - Source for the profile
     *  Outputs:
     *     Dictionary where key is a character and value is the frequency count
     *     from the text.
     */
    public static Dictionary<char, int> Profile(string text)
    {
        var profile = new Dictionary<char, int>();
        foreach (var c in text)
        {
            if (profile.ContainsKey(c))
            {
                profile[c]++;
            }
            else
            {
                profile[c] = 1;
            }
        }
        return profile;
    }


    /* Create a huffman tree for all letters in the profile.  Use
     * a Priority Queue (code already provided) in your implementation.
     *
     *  Inputs:
     *     profile - Previously generated profile dictionary
     *  Outputs:
     *     The root node of a huffman tree
     */
    public static Node BuildTree(Dictionary<char, int> profile)
    {
        var priorityQueue = new PriorityQueue<Node>();

        // Create initial nodes for each character and add to the priority queue
        foreach (var entry in profile)
        {
            priorityQueue.Insert(new Node { Letter = entry.Key, Count = entry.Value }, entry.Value);
        }

        // Build the Huffman tree
        while (priorityQueue.Size() > 1)
        {
            // Extract the two nodes with the lowest frequency
            var left = priorityQueue.Dequeue();
            var right = priorityQueue.Dequeue();

            // Create a new internal node with these two nodes as children
            var newNode = new Node
            {
                Left = left,
                Right = right,
                Count = left.Count + right.Count
            };

            // Add the new node to the priority queue
            priorityQueue.Insert(newNode, newNode.Count);
        }

        // The remaining node is the root of the Huffman tree
        return priorityQueue.Dequeue();
    }


    /* Create an encoding map from the huffman tree
     *
     *  Inputs:
     *     root - Root node of the Huffman Tree
     *  Outputs:
     *     A dictionary where key is the letter and value is the
     *     huffman code.
     */
    public static Dictionary<char, string> CreateEncodingMap(Node root)
    {
        var map = new Dictionary<char, string>();
        _CreateEncodingMap(root, "", map);
        return map;
    }

    /* Recursively visit each node in the Huffman Tree
     * looking for leaf nodes which contain letters.  Keep
     * track of the huffman code by adding 0 when going left
     * and 1 when going right
     *
     *  Inputs:
     *     node - Current node we are on
     *     code - Current code created
     *     map - Encoding Map being populated
     *  Outputs:
     *     none
     */
    private static void _CreateEncodingMap(Node node, string code, Dictionary<char, string> map)
    {
        if (node == null)
        {
            return;
        }

        // If this node is a leaf, it contains a letter
        if (node.Left == null && node.Right == null)
        {
            map[node.Letter] = code;
        }

        _CreateEncodingMap(node.Left, code + "0", map);
        _CreateEncodingMap(node.Right, code + "1", map);
    }

    /* Encode a string with the encoding map.
     *
     *  Inputs:
     *     text - String to encode
     *     map - Encoding Map previously created
     *  Outputs:
     *     A string of huffman codes (1's and 0's) representing the
     *     encoding of the text.
     */
    public static string Encode(string text, Dictionary<char, string> map)
    {
        var encodedText = new StringBuilder();
        foreach (var c in text)
        {
            encodedText.Append(map[c]);
        }
        return encodedText.ToString();
    }


    /* Decode a string with the huffman tree
     *
     *  Inputs:
     *     text - String to decode
     *     root - Root node of the previously created huffman tree
     *  Outputs:
     *     decoded text
     */
    public static string Decode(string text, Node root)
    {
        var decodedText = new StringBuilder();
        var currentNode = root;

        foreach (var bit in text)
        {
            currentNode = bit == '0' ? currentNode.Left : currentNode.Right;

            // If we reach a leaf node, we have found a letter
            if (currentNode.Left == null && currentNode.Right == null)
            {
                decodedText.Append(currentNode.Letter);
                currentNode = root; // Start again from the root for the next character
            }
        }

        return decodedText.ToString();
    }

}