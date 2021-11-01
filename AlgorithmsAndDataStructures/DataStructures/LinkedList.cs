using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public sealed class LinkedList<T> : IEnumerable<T>, IEnumerator<T> where T : IEquatable<T>
    {
        private int _count;
        private Node<T> _top;
        private Node<T> _tail;

        public LinkedList()
        {
            _count = 0;
            _top = null;
            _tail = null;
        }

        public int Count => _count;

        public void Add(T item)
        {
            var node = new Node<T> {Value = item};

            if (_tail != null)
                _tail.Next = node;

            _tail = node;
            _top ??= node;
            _count++;
        }

        public void Remove(T item)
        {
            if (_top != null && _top.Value.Equals(item))
            {
                if (_tail == _top) _tail = null;

                _top = _top.Next;
                _count--;
                return;
            }

            var current = _top;
            while (current?.Next != null)
            {
                if (current.Next.Value.Equals(item))
                {
                    current.Next = current.Next.Next;

                    if (_tail.Value.Equals(item))
                    {
                        _tail = current.Next;
                    }

                    _count--;
                    return;
                }

                current = current.Next;
            }

            throw new InvalidOperationException();
        }

        public T FirstOrDefault(Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentException(nameof(predicate));

            var current = _top;
            while (current != null)
            {
                if (current.Value != null && predicate.Invoke(current.Value))
                {
                    return current.Value;
                }

                current = current.Next;
            }

            return default;
        }

        #region IEnumerable

        public IEnumerator<T> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => this;

        #endregion

        #region Internal

        internal sealed class Node<T> where T : IEquatable<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
        }

        #endregion

        #region IEnumerator

        private Node<T> _current;

        object IEnumerator.Current => Current;
        public T Current => _current.Value;

        public bool MoveNext()
        {
            if (_count == 0)
                return false;

            _current = _current == null ? _top : _current.Next;

            return _current != null;
        }

        public void Reset()
        {
            _current = default;
        }

        public void Dispose()
        {
            Reset();
            // Not implemented
        }

        #endregion
    }
}