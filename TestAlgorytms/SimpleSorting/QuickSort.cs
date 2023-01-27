namespace TestAlgorytms.SimpleSorting
{
    public class QuickSort
    {

        public void Sort(int[] array, int low, int high)
        {
            int pivot = Partition(array, low, high);

            Sort(array, low, pivot - 1);
            Sort(array, pivot + 1, high);
        }
        public int Partition(int[] array, int low, int high)
        {
            var pivot = array[high];

            // Index of smaller element and indicates the right position of pivot found so far
            int i = low - 1;

            for (int j = low; j < high - 1; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }

            (array[i + 1], array[high]) = (array[high], array[i + 1]);
            return i + 1;
        }
    }
}
