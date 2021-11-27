using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public sealed class Heap<T> : IEnumerable<T>, IEnumerator<T> where T : IComparable<T>
    {
        private T[] _array;
        private int _currentIndex;

        public Heap()
        {
            _array = new T[4];
            _currentIndex = 0;
        }

        public Heap(T[] items)
        {
            _currentIndex = items.Length;
            _array = items;

            for (var i = _array.Length / 2 - 1; i >= 0; i--)
                SiftDown(i, _array.Length);
        }

        public int Count => _currentIndex;

        public void Insert(T item)
        {
            if (_currentIndex >= _array.Length)
            {
                ResizeArray();
            }

            _array[_currentIndex] = item;
            SiftUp(_currentIndex);
            _currentIndex++;
        }

        public T GetMin()
        {
            var min = _array[0];

            Swap(0, _currentIndex - 1);
            _currentIndex--;

            SiftDown(0);

            return min;
        }

        #region Internal implementation

        private void ResizeArray()
        {
            var newArray = new T[_array.Length * 2];

            for (var i = 0; i < _array.Length; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }

        private void SiftUp(int childIndex)
        {
            if (childIndex < 1)
                return;

            var parentIndex = GetParentIndexOf(childIndex);
            if (_array[parentIndex].CompareTo(_array[childIndex]) == 1)
            {
                Swap(parentIndex, childIndex);
                SiftUp(parentIndex);
            }
        }

        private void SiftDown(int parentIndex)
        {
            var (leftIndex, rightIndex) = GetChildrenIndexes(parentIndex);
            var minIndex = parentIndex;

            foreach (var currentIndex in new[] { leftIndex, rightIndex })
            {
                if (currentIndex < _currentIndex && _array[minIndex].CompareTo(_array[currentIndex]) == 1)
                {
                    minIndex = currentIndex;
                }
            }

            if (minIndex == parentIndex)
                return;

            Swap(parentIndex, minIndex);
            SiftDown(minIndex);
        }

        private void SiftDown(int parentIndex, int lastIndex)
        {
            var minIndex = parentIndex;

            foreach (var childIndex in new[] { parentIndex * 2 + 1, parentIndex * 2 + 2 })
            {
                if (childIndex < lastIndex &&
                    _array[minIndex].CompareTo(_array[childIndex]) == 1)
                {
                    minIndex = childIndex;
                }
            }

            if (minIndex == parentIndex)
                return;

            Swap(parentIndex, minIndex);
            SiftDown(minIndex, lastIndex);
        }

        private void Swap(int leftIndex, int rightIndex)
        {
            var temp = _array[leftIndex];
            _array[leftIndex] = _array[rightIndex];
            _array[rightIndex] = temp;
        }


        private int GetParentIndexOf(int childIndex) =>
            childIndex % 2 == 0
                ? (childIndex - 2) / 2 // right children
                : (childIndex - 1) / 2; // left children

        private (int left, int right) GetChildrenIndexes(int parentIndex) =>
            (parentIndex * 2 + 1, parentIndex * 2 + 2);

        #endregion

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator() => this;
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => this;

        private int _index = -1;
        T IEnumerator<T>.Current => _array[_index];
        object IEnumerator.Current => _array[_index];
        bool IEnumerator.MoveNext() => ++_index < _currentIndex;
        void IEnumerator.Reset() => _index = -1;
        void IDisposable.Dispose() => (this as IEnumerator).Reset();

        #endregion
    }
}