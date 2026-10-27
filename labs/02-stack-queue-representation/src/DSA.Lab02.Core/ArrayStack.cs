using System;

namespace DSA.Lab02
{
    public sealed class ArrayStack<T>
    {
        private readonly T[] _items;
        private int _count;

        public ArrayStack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }

        public int Count => _count;
        public int Capacity => _items.Length;

        public void Push(T item)
        {
            // TODO: place the item at the logical top and update the state.

            if(_count >= Capacity)
            {
                throw new InvalidOperationException("Outside Of Capacity.");
            }

            _items[_count] = item;
            _count++;  
        }

        public T Peek()
        {
            // TODO: return the logical top without removing it.
            if (_count <= 0)
            {
                throw new Exception("The stack is empty.");
            }
            return _items[_count - 1]; 
        }

        public T Pop()
        {

            if (_count <= 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            // TODO: remove and return the logical top.
            _count--;
            return _items[_count];

        
        }
    }
}
