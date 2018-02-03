using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<DoublyLinkedListNode<T>>, ICollection<T>
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }

        #region Add
        public void AddFirst(T item)
        {
            AddFirst(new DoublyLinkedListNode<T>(item));
        }

        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            DoublyLinkedListNode<T> temp = Head;

            Head = node;
            Head.Next = temp;

            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = Head;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            AddLast(new DoublyLinkedListNode<T>(item));
        }

        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;

        }

        #endregion

        #region Remove

        public void RemoveFirst()
        {
            // 1 <-> 2<-> 3<->4
            // 1 
            if (Count != 0)
            {
                Head = Head.Next;

                if (Count != 1)
                {
                    Head.Previous = null;
                }
                else
                {
                    Tail = null;
                }
                Count--;
            }

        }

        public void RemoveLast()
        {
            // 1 <-> 2<-> 3<->4
            // 1 
            if (Count != 0)
            {
                if (Count != 1)
                {
                    Tail = Tail.Previous;
                    Tail.Next = null;

                }
                else
                {
                    Head = null;
                    Tail = null;
                }
                Count--;
            }
        }

        #endregion

        public int Count { get; set; }

        public bool IsReadOnly { get { return false;  } }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            DoublyLinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            DoublyLinkedListNode<T> current = Head;

            while (current != null)
            {
                array[arrayIndex++] = current.Value;

                current = current.Next;
            }

        }

        public bool Remove(T item)
        {
            // CASES
            // 1: Empty list - do nothing
            // 2: Single node: (previous is null)
            // 3: Many nodes
            //      a: node to remove is first node
            //      b: node to remove is middle or last
            //    1 <-> 2 <-> 3

            DoublyLinkedListNode<T> current = Head;
            DoublyLinkedListNode<T> previous = null;

            while(current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        // 3b
                        if (current.Next != null)
                        {
                            current.Next.Previous = previous;
                        }
                        else
                        {
                            Tail = previous;
                        }

                        Count--;
                    }
                    else
                    {
                        // case 2 or 3a
                        RemoveFirst();
                    }
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<DoublyLinkedListNode<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
