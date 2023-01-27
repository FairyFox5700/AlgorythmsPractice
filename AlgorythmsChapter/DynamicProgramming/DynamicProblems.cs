namespace AlgorythmsChapter.DynamicProgramming
{
    public class DynamicProblems
    {

        //Problem-1 Convert the following recurrence to code.

        public int CalculateFormula(int n)
        {
            int sum = 0;
            if (n == 0 || n == 1)
            {
                return 2;
            }

            for (int i = 1; i <= n - 1; i++)
            {
                sum += 2 * CalculateFormula(i) * CalculateFormula(n - 1);
            }

            return sum;
        }

        private int[] array = new int[5];

        //Can we improve the solution to Problem-1 using memoization of DP?
        // T[0] = T[1] = 2
        // T[2] = 2*T[1]*T[0]
        // T[3] = 2*T[2]T[1]+ 2*T[1]*T[0]
        public int CalculateFormulaDynamicly(int n)
        {
            array[0] = 2;
            array[1] = 2;

            for (int i = 2; i <= n; i++)
            {
                array[i] += 2 * array[i] * array[i - 1];
            }

            return array[n];
        }

        //Problem-4 Maximum Value Contiguous Subsequence: Given an array of n numbers, give
        //an algorithm for finding a contiguous subsequence A(i)... A(j) for which the sum of
        //elements is maximum
        //Example: {-2, 11, -4, 13, -5, 2} → 20 and {1, -3, 4, -2, -1, 6} → 7
        public int MaximumContiniousValueSubsequence(int[] array, int n)
        {
            int maxSum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int currentSum = 0;
                    for (int k = i; k <= j; k++)
                    {
                        currentSum += array[k];
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            return maxSum;
        }

        //Brute-Force

        public int MaxContiniousSum(int[] array, int n)
        {
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                var currentSum = 0;
                for (int j = i; j < n; j++)
                {
                    currentSum += array[j];
                    if (currentSum > max)
                    {
                        max = currentSum;
                    }
                }
            }

            return max;
        }

        //Time Complexity: O(n). Space Complexity: O(n), for table
        //To find maximum sum we have to do one of the following and select maximum among them.
        //• Either extend the old sum by adding A[i]
        // • or start new window starting with one element A[i]

        public int MaxContiniousSumDynamic(int[] array, int n)
        {
            var table = new int[n];
            int maxSum;
            maxSum = array[0] > 0 ? array[0] : 0;

            for (int i = 1; i < n; i++)
            {
                if (array[i] + table[i - 1] > 0)
                {
                    table[i] = array[i] + table[i - 1];
                }
                else
                {
                    table[i] = 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (table[i] > maxSum)
                {
                    maxSum = table[i];
                }
            }

            return maxSum;
        }


        //We can solve this problem without DP too (without memory). The algorithm is a
        //    little tricky.One simple way is to look for all positive contiguous segments of the array
        //    (sumEndingHere) and keep track of the maximum sum contiguous segment among all positive
        //segments (sumSoFar). Each time we get a positive sum compare it (sumEndingHere) with
        //    sumSoFar and update sumSoFar if it is greater than sumSoFar.Let us consider the following
        //    code for the above observation
        //Time Complexity: O(n), because we are doing only one scan. Space Complexity: O(1), for table.

        int MaxContiniousSumDynamicWithoutMemory(int[] array, int n)
        {
            int sumEndingHere = 0;
            int sumSoFar = 0;
            for (int i = 0; i < n; i++)
            {
                sumEndingHere = array[i] + sumEndingHere;
                if (sumEndingHere >= 0)
                {
                    if (sumEndingHere > sumSoFar)
                    {
                        sumSoFar = sumEndingHere;
                    }
                }
                else
                {
                    sumEndingHere = 0;
                }
            }

            return sumSoFar;
        }
    }
}
