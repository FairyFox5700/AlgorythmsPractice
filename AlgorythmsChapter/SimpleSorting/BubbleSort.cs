using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.SimpleSorting
{
    internal class BubbleSortMain
    {

        public void BubbleSort(int[] array)
        {
            var length = array.Length;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }
                }

                DisplayElements(array);
            }
        }
        public void DisplayElements(int[] array)
        {
            for (int i = 0; i <= array.Length - 1; i++)
                Console.Write(array[i] + " ");
        }
    }

}
