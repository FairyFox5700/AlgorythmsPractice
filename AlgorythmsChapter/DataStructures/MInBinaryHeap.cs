using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.DataStructures
{
    internal class MInBinaryHeap
    {

        public int[] HeapArray { get; set; }

        public int Capacity { get; set; }

        public int CurrentHeapSize { get; set; }

        public MInBinaryHeap(int capacity)
        {
            Capacity = capacity;
            HeapArray = new int[capacity];
        }

        public void Swap<T>(T left, T right)
        {
            (right, left) = (left, right);
        }

        // Get the Parent index for the given index

        public int Parent(int key)
        {
            return (key - 1) / 2;
        }

        // Get the Left Child index for the given index
        public int Left(int key)
        {
            return 2 * key + 1;
        }

        // Get the Right Child index for the given index
        public int Right(int key)
        {
            return key * 2 + 2;
        }

        public bool InsertKey(int key)
        {
            if (CurrentHeapSize == Capacity)
            {
                return false;
            }

            var currentIndex = CurrentHeapSize;

            HeapArray[currentIndex] = key;
            CurrentHeapSize++;

            while (currentIndex != 0 &&
                   HeapArray[currentIndex] < HeapArray[Parent(currentIndex)])
            {
                Swap(HeapArray[currentIndex], HeapArray[Parent(currentIndex)]);
                currentIndex = Parent((currentIndex));
            }

            return true;
        }

        // Decreases value of given key to new_val.
        // It is assumed that new_val is smaller
        // than heapArray[key].
        public void DecreaseKey(int key, int newVal)
        {
            HeapArray[key] = newVal;

            while (key != 0 && HeapArray[key] < HeapArray[Parent(key)])
            {
                Swap(HeapArray[key], HeapArray[Parent(key)]);
                key = Parent(key);
            }
        }

        // Returns the minimum key (key at
        // root) from min heap
        public int GetMin()
        {
            return HeapArray[0];
        }

        // Method to remove minimum element
        // (or root) from min heap
        public int ExtractMin()
        {

            if (CurrentHeapSize <= 0)
            {
                return 0;
            }

            if (CurrentHeapSize == 1)
            {
                CurrentHeapSize--;
                return HeapArray[0];
            }

            var root = HeapArray[0];
            HeapArray[0] = HeapArray[CurrentHeapSize - 1];
            CurrentHeapSize--;
            return root;
        }

        // This function deletes key at the
        // given index. It first reduced value
        // to minus infinite, then calls extractMin()
        public void DeleteKey(int key)
        {
            DecreaseKey(key, int.MinValue);
            ExtractMin();
        }

        // A recursive method to heapify a subtree
        // with the root at given index
        // This method assumes that the subtrees
        // are already heapified
        public void MinHeapify(int key)
        {
            int l = Left(key);
            int r = Right(key);

            int smallest = key;
            if (l < CurrentHeapSize && HeapArray[l] < HeapArray[smallest])
            {
                smallest = l;
            }

            if (r < CurrentHeapSize && HeapArray[r] < HeapArray[smallest])
            {
                smallest = r;
            }

            if (smallest != key)
            {
                Swap(HeapArray[key], HeapArray[smallest]);
                MinHeapify(smallest);
            }
        }

        // Increases value of given key to new_val.
        // It is assumed that new_val is greater
        // than heapArray[key].
        // Heapify from the given key
        public void IncreaseKey(int key, int new_val)
        {
            HeapArray[key] = new_val;
            MinHeapify(key);
        }

        // Changes value on a key
        public void ChangeValueOnAKey(int key, int new_val)
        {
            if (HeapArray[key] == new_val)
            {
                return;
            }

            if (HeapArray[key] < new_val)
            {
                IncreaseKey(key, new_val);
            }
            else
            {
                DecreaseKey(key, new_val);
            }
        }
    }
}