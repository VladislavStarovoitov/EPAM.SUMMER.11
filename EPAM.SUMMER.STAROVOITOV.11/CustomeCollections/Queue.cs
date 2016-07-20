using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomeCollections
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] _queue;
        private int _size = 0;
        private int _tail = -1;
        private int _head = 0;
        private const int _lengthDelta = 1000;
        private static T[] _emptyArray = new T[0];

        public Queue()
        {
            _queue = _emptyArray;
        }

        public void Enqueue(T item)
        {
            if (_size != int.MaxValue)
            {
                if (_tail + 1 == _queue.Length)
                {
                    if (_queue.Length >> 1 > _size)
                        Array.Copy(_queue, _head, _queue, 0, _size);
                    else
                    {
                        int length;
                        if (int.MaxValue - _lengthDelta < _queue.Length)
                        {
                            length = int.MaxValue;
                        }
                        else
                            length = (int.MaxValue >> 1) > _size ? _size << 1 : _size + _lengthDelta;
                        T[] newQueue = new T[length];
                        Array.Copy(_queue, _head, newQueue, 0, _size);
                        _queue = newQueue;
                    }
                    _head = 0;
                    _tail = _size - 1;
                }
                _queue[++_tail] = item;
                _size++;
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException();

            T item = _queue[_head];
            _head++;
            _size--;
            if (_head > _tail)
            {
                _head = 0;
                _tail = -1;
            }
            return item;
        }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException();

            return _queue[_head];
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
