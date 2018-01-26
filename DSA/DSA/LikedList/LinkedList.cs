using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LikedList
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }

        #region Add
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;

            Head = node;
            Head.Next = temp;

            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }
            
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;
            Count++;
        }

        #endregion

        #region Remove
        public void RemoveFirst(T value)
        {
            RemoveFirst(new LinkedListNode<T>(value));
        }

        public void RemoveFirst(LinkedListNode<T> node)
        {
            if(Count != 0)
            {
                Head = Head.Next;               

                if (Count == 1)
                {
                    Tail = null;
                }

                Count--;
            }
        }

        public void RemoveLast(T value)
        {
            RemoveLast(new LinkedListNode<T>(value));
        }

        public void RemoveLast(LinkedListNode<T> node)
        {
            if(Count != 0)
            {
                if(Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    LinkedListNode<T> current = Head;

                    while(current.Next != Tail)
                    {
                        current = current.Next;
                    }

                    current.Next = null;
                    Tail = current;
                }

                Count--;
            }
        }
        #endregion



        #region ICollection
        public int Count { get; private set; }

        public bool IsReadOnly {
            get {
                return false;
            }
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void Clear()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        /// <summary>
        /// Returns true if a node with the specified value is found
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            
            // iterate over the list
            while(current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Copies the node values into the specified array.
        /// </summary>
        /// <param name="array">The array to copy the linked list values to</param>
        /// <param name="arrayIndex">The index of the array to start copying from</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;

            while(current != null)
            {
                array[arrayIndex++] = current.Value;

                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
#endregion
    }
}
