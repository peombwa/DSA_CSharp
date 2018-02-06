using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Queue
{
    public class PriorityQueueInLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        LinkedList<T> _items = new LinkedList<T>();

        public void Enqueue(T item)
        {
            if(_items.Count == 0)
            {
                // this is an empty list
                _items.AddLast(item);
            }
            else
            {
                // find the proper insert point (start at the front of the list)
                var current = _items.First;

                // while we are not null i.e. not at the end of the list and the current value
                // is larger than the value being inserted...
                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }

                if(current == null)
                {
                    // we made it to the end of the list
                    _items.AddLast(item);
                }
                else
                {
                    // the current item is <= the one being added
                    // so add the item before it
                    _items.AddBefore(current, item);
                }

            }
        }

        public T Dequeue()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T value = _items.First.Value;

            _items.RemoveFirst();

            return value;
        }

        public T Peek()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items.First.Value;
        }

        public int Count {
            get {
                return _items.Count;
            }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
