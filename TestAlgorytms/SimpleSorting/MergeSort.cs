namespace TestAlgorytms.SimpleSorting
{
    public class MergeSort
    {
        public void Sort(int[] array, int left, int right)
        {
            if (left > right)
            {
                return;
            }

            int mid = (left + right) / 2;

            Sort(array, left, mid);
            Sort(array, mid + 1, right);

            Merge(array, left, mid, right);
        }

        public void Merge(int[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            int i, k = 0;
            for (i = 0; i < n1; i++)
            {
                leftArray[i] = array[left + i];
            }

            for (k = 0; k < n2; k++)
            {
                rightArray[k] = array[k + mid + 1];
            }

            int j = left;
            while (i < n1 && k < n2)
            {
                if (leftArray[i] <= rightArray[k])
                {
                    array[j] = leftArray[i];
                    i++;
                }
                else
                {
                    array[j] = rightArray[k];
                    k++;
                }

                j++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                array[j] = leftArray[i];
                i++;
                j++;
            }

            // Copy remaining elements
            // of R[] if any
            while (k < n2)
            {
                array[j] = rightArray[k];
                k++;
                j++;
            }
        }
    }
}
