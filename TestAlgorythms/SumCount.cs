using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgorythms
{
    public static class GFG
    {

        // Returns number of pairs in arr[0..n-1]
        // with sum equal to 'sum'
        public static int getPairsCount(int[] arr, int sum)
        {
            Dictionary<int, int> hm
                = new Dictionary<int, int>();

            // Store counts of all elements
            // in map hm
            for (int i = 0; i < arr.Length; i++)
            {

                // initializing value to 0,
                // if key not found
                if (!hm.ContainsKey(arr[i]))
                {
                    hm[arr[i]] = 0;
                }

                hm[arr[i]] = hm[arr[i]] + 1;
            }

            int twice_count = 0;

            // iterate through each element and
            // increment the count (Notice that
            // every pair is counted twice)
            for (int i = 0; i < arr.Length; i++)
            {
                if (hm[sum - arr[i]] != 0)
                {
                    twice_count += hm[sum - arr[i]];
                }

                // if (arr[i], arr[i]) pair satisfies
                // the condition, then we need to ensure
                // that the count is decreased by one
                // such that the (arr[i], arr[i])
                // pair is not considered
                if (sum - arr[i] == arr[i])
                {
                    twice_count--;
                }
            }

            // return the half of twice_count
            return twice_count / 2;
        }
    }

}
