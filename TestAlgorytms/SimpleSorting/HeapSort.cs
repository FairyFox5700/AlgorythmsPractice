using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgorytms.SimpleSorting
{
    internal class HeapSort
    {

        public void Sort(int[] array)
        {
            int n = array.Length;

            // Build heap (rearrange array)
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }

            // One by one extract an element from heap
            for (int i = n - 1; i > 0; i--)
            {
                (array[0], array[i]) = (array[i], array[0]);

                Heapify(array, i, 0);
            }
        }

        public void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * 1 + 1;
            int right = 2 * 1 + 2;

            // If left child is larger than root
            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }

            // If right child is larger than largest so far
            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            // If largest is not root

            if (largest != i)
            {
                (array[i], array[largest]) = (array[largest], array[i]);
                Heapify(array, n, largest);
            }

        }
    }
}
