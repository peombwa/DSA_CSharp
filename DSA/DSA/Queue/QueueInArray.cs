using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Queue
{
    public class QueueInArray<T> : IEnumerable<T>
    {
        T[] _items = new T[0];

        // number if items in the queue
        int _size = 0;

        // index to the first(oldest) item in the queue
        int _head = 0;

        // index the last(newesy) item in the queue
        int _tail = -1;

        /// <summary>
        /// Adds an item to the back of the queue
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if(_items.Length == _size)
            {
                int newLength = (_size == 0) ? 4 : _size * 2;

                T[] newArray = new T[newLength];

                if(_size > 0)
                {
                    // copy contents...
                    // if the array has no wrapping, just copy the valid range
                    // else copy from head to end of the array and then from 0 to the tail
                    // if tail is less than head, we've wrapped

                    int targetIndex = 0;

                    if(_tail < _head)
                    {
                        // copy items from the head to the end of the array
                        // copy the _items[head]..._items[end] -> newArray[0]..newArray[N]
                        for (int index = _head; index < _items.Length; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }

                        // copy from 0 to the tail
                        // copy _items[0]..._items[tail] --> newArray[N+1] 
                        for (int index = 0; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        // we didn't wrap arround
                        // copy from head to tail
                        // copy _items[head]..._items[tail] --> newArray[0] ... newArray[N]
                        for (int index = _head; index <- _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }

                    _head = 0; // it's a new array
                    _tail = targetIndex - 1; // compensate for the extra bump
                }
                else
                {
                    // first time
                    _head = 0;
                    _tail = -1;
                }

                // copy newArray to the old array
                _items = newArray;
            }

            // if tail is at the end of the array, we need to wrap around
            if(_tail == _items.Length - 1)
            {
                //  we wrap around
                _tail = 0;
            }
            else
            {
                _tail++;
            }


            _items[_tail] = item;
            _size++;
        }

        public T Dequeue()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T value = _items[_head];
            if(_head == _items.Length - 1)
            {
                // head is in the last index of the array, wrap it
                _head = 0;
            }
            else
            {
                _head++;
            }

            _size--;

            return value;
        }

        public T Peak()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items[_head];
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = -1;
        }
        public IEnumerator<T> GetEnumerator()
        {
            if(_size > 0)
            {
                if(_tail < _head)
                {
                    // we have wrapped, show head...end, then 0 ...tail
                    // show from _items[head]...._items[end]
                    for (int index = _head; index < _items.Length; index++)
                    {
                        yield return _items[index];
                    }

                    // show from _items[0]...._items[tail]
                    for (int index = 0; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
                else
                {
                    // we havent wrapped, show 0....tail
                    for (int index= _tail = 0; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
