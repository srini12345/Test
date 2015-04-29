using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearchTreeProject
{
    /// <summary>
    /// Initialize the Class for Tree node
    /// </summary>
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        /// <summary>
        /// Creates a Tree with Left node and Right nodes as Input as assigh the value 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
    /// <summary>
    /// Binary Search Tree Class
    /// </summary>
    public class BinarySearchTree
    {
        /// <summary>
        /// Check if Tree is a BST. Check for node's Left and Right nodes and compare them with current node. 
        /// BST should be in an sorted Order where value of left node is less than value of current node and value of Right node 
        /// greater than value of current node.
        /// </summary>
        /// <param name="root">Node of the tree</param>
        /// <returns>True if its a BST</returns>
        public static bool IsValidBST(Node root)
        {
            /*
            /*
             * Removed the existing logic in order to check at any level of the tree and added based on Recursive logic
            */

           return validateBST(root, int.MinValue, int.MaxValue);
        }

        private static bool validateBST(Node ONode, int min, int max)
        {
            try
            {

                if (ONode == null)
                {
                    return true;
                }
                else if (min.CompareTo(ONode.Value) > 0 || max.CompareTo(ONode.Value) < 0)
                {
                    return false;
                }
                // left subtree must be <= root.val && right subtree must be >= root.val
                return validateBST(ONode.Left, min, ONode.Value) && validateBST(ONode.Right, ONode.Value, max);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                return false;
            }
        }
        public static void Main(string[] args)
        {
            /*
             *          30
             *          /   \
             *          20  30
             *          /   
             *          19
             *          /
             *          5
             */
            Node n1 = new Node(5, null, null);
            Node n2 = new Node(19, n1, null);
            Node n3 = new Node(20, n2, null);
            Node n4 = new Node(30, null, null);
            Node n5 = new Node(30, n2, n4);

            Console.WriteLine(IsValidBST(n5));
            Console.ReadKey();
        }
    }
}
