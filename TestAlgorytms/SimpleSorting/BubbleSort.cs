using TestAlgorytms.Utills;

namespace TestAlgorytms.SimpleSorting
{
    public class BubbleSortMain
    {
        public static void BubbleSort(int[] array)
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

                AlgorytmsUtills.DisplayElements(array);
            }
        }
    }

}
