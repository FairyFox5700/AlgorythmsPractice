using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.LeetCode
{
    // https://leetcode.com/problems/two-sum/submissions/
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var result = target - nums[i];
                if (dictionary.ContainsKey(result))
                {
                    return new[] { dictionary[result], i };
                }
                else
                {
                    if (!dictionary.ContainsKey(nums[i]))
                    {
                        dictionary.Add(nums[i], i);
                    }
                }
            }

            return new int[] { };
        }
    }
}
