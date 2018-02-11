﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinaryTree
{
    public class BinaryTreeNode<TNode>: IComparable<TNode>
        where TNode: IComparable<TNode>
    {

        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }
        public TNode Value { get; private set; }
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }

        /// <summary>
        /// Compared the current node to the provided value
        /// </summary>
        /// <param name="other">The node value to comparer to</param>
        /// <returns>1 if the instance value is greater than the provided value, -1 if less or 0 if equal</returns>
        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
    }
}
