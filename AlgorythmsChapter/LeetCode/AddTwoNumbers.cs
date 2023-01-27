using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.LeetCode
{
    public class GreedylongestJump
    {
        public bool CanJump(int[] nums)
        {
            var length = nums.Count();
            var right = length - 1;
            for (var i = length - 2; i <= 0; i--)
            {
                if ((i + nums[i]) > right)
                {
                    right--;
                }
            }

            return right == 0;
        }

    }
    public class LongestPalindromeSolution
    {
        public string LongestPalindrome(string s)
        {
            var characters = s.ToCharArray();
            // odd case
            // even case
            if (characters.Length % 2 == 0)
            {
                var mid = (0 + characters.Length) / 2;
                var left = mid;
                var right = mid + 1;
                var count = 0;
                if (left >= 0 && right >= 0 && left < characters.Length && right < characters.Length
                    && left < right && characters[left] == characters[right])
                {
                    count = left - right + 1;
                    left--;
                    right++;
                }
            }

        }
    }

    public class Solution3
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var pointer = new ListNode();
            var carry = 0;
            while (l1 != null && l1 != null)
            {
                var sum = carry;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                var left = sum % 10;
                var overflow = left / 10;
                if (overflow > 0)
                {
                    carry = overflow;
                    left += overflow;
                }
                else
                {
                    carry = 0;
                }

                pointer.next = new ListNode(left);
                pointer = pointer.next;


            }

            if (carry > 0)
            {
                pointer.next = new ListNode(carry);
            }

            return pointer;
        }
    }
}


