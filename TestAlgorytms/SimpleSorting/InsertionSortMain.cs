using TestAlgorytms.Utills;

namespace TestAlgorytms.SimpleSorting
{
    internal class InsertionSortMain
    {
        public static void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var j = i;
                while (j > 0 && array[j - 1] > array[j])
                {
                    (array[j - 1], array[j]) = (array[j], array[j - 1]);
                    j--;
                }

                AlgorytmsUtills.DisplayElements(array);
            }
        }
    }
}
