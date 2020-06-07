using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.Array.Medium
{
    [TestClass]
    public class MinHeapTest
    {
        [TestMethod]
        public void FindKthSmallestElementTest()
        {
            int[] input = new int[] { 3, 2, 1, 5, 6, 4 };
            int r = FindKthLargestElement(input, 2);
            SortedList<int, int> st = new SortedList<int, int>();
            
        }
        private int FindKthLargestElement(int[] input, int k)
        {
            MaxIntHeap hp = new MaxIntHeap(input.Length);
            foreach (var item in input)
            {
                hp.add(item);
            }
            for (int i = 1; i < k; i++)
            {
                hp.poll();
            }
            return hp.poll();
        }
    }
    public class MinIntHeap
    {
        private int capacity = 10;
        private int size = 0;
        int[] items;
        public MinIntHeap(int _capacity)
        {
            capacity = _capacity;
            items = new int[capacity];
        }
        private int getLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int getRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        private int getParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool hasLeftChild(int index) => getLeftChildIndex(index) < size;
        private bool hasRightChild(int index) => getRightChildIndex(index) < size;
        private bool hasParent(int index) => getParentIndex(index) >= 0;

        private int leftChild(int index) => items[getLeftChildIndex(index)];
        private int rightChild(int index) => items[getRightChildIndex(index)];
        private int parent(int index)=>items[getParentIndex(index)]; 
        private void swap(int indexOne, int indexTwo)
        {
            int temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }
        public int peek()
        {
            if (size == 0) return -1;
            return items[0];
        }
        public int poll()
        {
            if (size == 0) return -1;
            int item = items[0];
            items[0] = items[size - 1];
            size--;
            heapifyDown();
            return item;
        }
        public void add(int item)
        {
            items[size] = item;
            size++;
            heapifyUp();
        }

        private void heapifyUp()
        {
            int index = size - 1;
            while (hasParent(index) && parent(index) > items[index])
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }

        private void heapifyDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index) < leftChild(index))
                {
                    smallerChildIndex = getRightChildIndex(index);
                }
                if (items[index] < items[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;
            }
        }
    }
    public class MaxIntHeap
    {
        private int capacity = 10;
        private int size = 0;
        int[] items;
        public MaxIntHeap(int _capacity)
        {
            capacity = _capacity;
            items = new int[capacity];
        }
        private int getLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int getRightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        private bool hasLeftChild(int index) { return getLeftChildIndex(index) < size; }
        private bool hasRightChild(int index) { return getRightChildIndex(index) < size; }
        private bool hasParent(int index) { return getParentIndex(index) >= 0; }

        private int leftChild(int index) { return items[getLeftChildIndex(index)]; }
        private int rightChild(int index) { return items[getRightChildIndex(index)]; }
        private int parent(int index) { return items[getParentIndex(index)]; }
        private void swap(int indexOne, int indexTwo)
        {
            int temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }
        public int peek()
        {
            if (size == 0) return -1;
            return items[0];
        }
        public int poll()
        {
            if (size == 0) return -1;
            int item = items[0];
            items[0] = items[size - 1];
            size--;
            heapifyDown();
            return item;
        }
        public void add(int item)
        {
            items[size] = item;
            size++;
            heapifyUp();
        }

        private void heapifyUp()
        {
            int index = size - 1;
            while (hasParent(index) && parent(index) < items[index])
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }

        private void heapifyDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int largerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index) > leftChild(index))
                {
                    largerChildIndex = getRightChildIndex(index);
                }
                if (items[index] > items[largerChildIndex])
                {
                    break;
                }
                else
                {
                    swap(index, largerChildIndex);
                }
                index = largerChildIndex;
            }
        }
    }
}
