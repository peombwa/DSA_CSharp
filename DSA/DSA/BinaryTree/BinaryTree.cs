using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {

        public BinaryTreeNode<T> _head;
        public int _count;

        #region Add
        /// <summary>
        /// Add provided value to the binary tree
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            // Case 1: Tree is empty - allocate the head/root
            if(_head == null)
            {
                _head = new BinaryTreeNode<T>(value);
            }
            // Case 2: Tree is not empty, find the right location to insert
            else
            {
                AddTo(_head, value);
            }

            _count++;
        }

        // recursie algorithim
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            // case 1: value is smaller that current node value
            // case 2: when value is greater than the current node value
            // case 3: when value is equal to the current nod evalue

            // case 1: Value is less than current node
            if (value.CompareTo(node.Value) < 0)
            {
                // if it has no left, tke value the left node
                if(node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    // add it to the left node
                    AddTo(node.Left, value);
                }
            }
            // Case 2: Value is equal to or greater than current value
            else
            {
                // if no right, add it as the right
                if(node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                // add it to the right node
                else
                {
                    AddTo(node.Right, value);
                }
            }

        }
        #endregion

        /// <summary>
        /// Determins if the specified value exists in the binary tree
        /// </summary>
        /// <param name="value">Value to search for</param>
        /// <returns>True is the tree contains the value, false otherwise</returns>
        public bool Contains(T value)
        {
            // defer to the node search helper function.
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        /// <summary>
        /// Finds and returns the first node containg the specified value. If the value is not found, return null. 
        /// Also returns the parent of the found node (or null) which is used in Remove
        /// </summary>
        /// <param name="value">Value to search for</param>
        /// <param name="parent">Parent of the node found (or null)</param>
        /// <returns>Returns found node (or null)</returns>
        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            // Start with the head/root
            BinaryTreeNode<T> current = _head;
            parent = null;

            // while we dont have a match
            while(current != null)
            {
                int result = current.CompareTo(value);
                if(result > 0)
                {
                    // value is less than current, go left
                    parent = current;
                    current = current.Left;
                }
                else if(result < 0)
                {
                    // value is more than current, go right
                    parent = current;
                    current = current.Right;
                }
                else {
                    // we have a macth
                    break;
                }
            }

            return current;
        }

        #region Remove
        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;
            current = FindWithParent(value, out parent);

            if(current == null)
            {
                return false;
            }

            _count--;

            // Case 1: Current has no right child, the current's left replaces current
            if(current.Right == null)
            {
                if(parent == null)
                {
                    _head = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // if parent value is greater than current value
                        // make the current left child a left child of parent
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        // if parent value is less than current value
                        // make the current left child a right child of parent
                        parent.Right = current.Left;
                    }
                }
            }
            // Case 2: If current's right child has no left child, then current's right child
            // replaces current
            else if(current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if(parent == null)
                {
                    _head = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if(result > 0)
                    {
                        // if parent value is greater than current value
                        // make the current right child a left child of parent
                        parent.Left = current.Right;
                    }
                    else if(result < 0)
                    {
                        // if parent value is leff than current value
                        // make the current right child a right child of parent
                        parent.Right = current.Right;
                    }
                }
            }

            // Case 3: If parent's right child has a left child, replace current with current's 
            // right child's left most child
            else
            {
                // find the right's left-most child
                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;

                while(leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // the parent's left subtree becomes the leftmost's right subtree
                leftmostParent.Left = leftmost.Right;

                // assign leftmost's left and right to current's left and right children
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if(parent == null)
                {
                    _head = leftmost;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if(result > 0)
                    {
                        // if parent value is greater than current value
                        // make leftmost the parent's left child
                        parent.Left = leftmost;
                    }else if(result < 0)
                    {
                        // if parent value is less than current value 
                        // make leftmost the parent's right child
                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }
        #endregion

        #region Pre-Order Traversal

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }

        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if(node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }
        #endregion

        #region Post-Order Traversal
        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }

        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }
        #endregion

        #region In-Order Traversal
        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _head);
        }

        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.Left);
                action(node.Value);
                InOrderTraversal(action, node.Right);            }
        }
        #endregion

        public IEnumerator<T> InOrderTraversal()
        {
            // This is a non-recursive algorithim using a stack to demontrsate removing
            // recursion to make using the yeild syntac easier
            if(_head != null)
            {
                // store the nodes we've skipped in this stack (avoids recursion)
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = _head;

                // when removing recursion we need to keep track of whether or not
                // we should be hoing to the left node or the right node next.
                bool goLeftNext = true;

                // start by pushing Head onto the stack
                stack.Push(current);

                while(stack.Count > 0)
                {
                    // if we're heading left
                    if (goLeftNext)
                    {
                        // push everything but the left-most node to the stack
                        // we'll yield the left-most after this block
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    // in-order is left -> yield -> right
                    yield return current.Value;

                    // if we can go right, then do so
                    if(current.Right != null)
                    {
                        current = current.Right;

                        // once we've gone right once, we need to start
                        // going left again
                        goLeftNext = true;
                    }
                    else
                    {
                        // if we can't go right, then we need to pop off the parent node
                        // so we can process it and then go to it's right node
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public int Count {
            get {
                return _count;
            }
        }
    }
}
