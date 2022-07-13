using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class MinHeap
    {
        private readonly int[] _elements;
        private int _size;

        public MinHeap(int size)
        {
            _elements = new int[size];
        }

        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        private double GetLeftChild(int elementIndex) => Graph.enterNodes[_elements[GetLeftChildIndex(elementIndex)]].Weight;
        private double GetRightChild(int elementIndex) => Graph.enterNodes[_elements[GetRightChildIndex(elementIndex)]].Weight;
        private double GetParent(int elementIndex) => Graph.enterNodes[_elements[GetParentIndex(elementIndex)]].Weight;

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public int Peek()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException();

            return _elements[0];
        }

        public int Pop()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException();

            var result = _elements[0];
            _elements[0] = _elements[_size - 1];
            _size--;

            ReCalculateDown();

            return result;
        }

        public void Add(int element)
        {
            if (_size == _elements.Length)
                throw new IndexOutOfRangeException();

            _elements[_size] = element;
            _size++;

            ReCalculateUp();
        }

        public void ReCalculateDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (Graph.enterNodes[_elements[smallerIndex]].Weight >= Graph.enterNodes[_elements[index]].Weight)
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        public void ReCalculateUp()
        {
            var index = _size - 1;
            while (!IsRoot(index) && Graph.enterNodes[ _elements[index]].Weight < GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
    }
}
