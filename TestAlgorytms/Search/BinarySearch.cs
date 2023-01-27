using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgorytms.Search
{
    public class BinarySearchMain
    {
        public static bool BinarySerach(int[] array, int searched)
        {
            Array.Sort(array);

            var low = 0;
            var high = array.Length;

            while (low <= high)
            {
                var mid = (low + high) / 2;
                if (array[mid] == searched)
                {
                    return true;
                }

                if (array[mid] > searched)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return false;

        }
    }
}
