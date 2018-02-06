using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Stack
{
    public class StackInArray<T> : IEnumerable<T>
    {
        //// operations
        // T push(T item)
        // T pop()
        // T peak()
        // void clear()
        // int count()
        T[] _items = new T[0];
        int _size;

        public void Push(T item)
        {
            // growth boundary for the array
            if(_size == _items.Length)
            {
                // intial size of 4, double it when increase the array size
                int newArrayLength = _size == 0 ? 4 : _size * 2;

                // create the new array,
                // copy old array contents to the new array
                // replace old array with the new array
                T[] newArray = new T[newArrayLength];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            _items[_size] = item;
            _size++;
        }

        public T Pop()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("stack is empty");
            }

            _size--;
            return _items[_size];
        }

        public T Peak()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("stack is empty");
            }

            return _items[_size - 1];
        }

        public void Clear()
        {
            _size = 0;
        }

        public int Count {
            get {
                return _size;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            // reverse the array
            for (int i = _size -1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
