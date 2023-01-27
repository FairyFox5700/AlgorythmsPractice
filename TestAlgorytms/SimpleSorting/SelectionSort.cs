using TestAlgorytms.Utills;

namespace TestAlgorytms.SimpleSorting
{
    public class SelectionSortMain
    {
        public static void SelectionSort(int[] array)
        {
            Console.WriteLine(array.Length);
            for (int j = 0; j < array.Length - 1; j++)
            {
                var minIndex = j;

                for (int i = j + 1; i < array.Length; i++)
                {
                    if (array[i] < array[minIndex])
                    {
                        minIndex = i;
                    }
                }

                (array[j], array[minIndex]) = (array[minIndex], array[j]);
                AlgorytmsUtills.DisplayElements(array);
            }
        }
    }
}
