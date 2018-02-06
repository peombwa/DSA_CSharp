using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Queue
{
    public class QueueInLinkedList<T> : IEnumerable<T>
    {
        System.Collections.Generic.LinkedList<T> _items = new LinkedList<T>();
        
        // enqueue
        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }

        // dequeue
        public T Dequeue()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T value = _items.First.Value;

            _items.RemoveFirst();

            return value;
        }

        // peek
        public T Peek()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return _items.First.Value;
        }

        public void Clear()
        {
            _items.Clear();
        }

        public int Count {
            get
            {
                return _items.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
