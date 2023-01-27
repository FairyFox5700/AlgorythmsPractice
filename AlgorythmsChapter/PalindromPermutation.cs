using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter
{
    /*Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
     A palindrome is a word or phrase that is the same forwards and backwards. A permutation is a rearrangement of letters.
    The palindrome does not need to be limited to just dictionary words. */
    internal class PalindromPermutation
    {
        //Input: Tact Coa
        //Output: True(permutations: "taco cat", "atco eta", etc.)

        /*Algorithm:isPalindrome(str)
        1) Find length of str. Let length be n.
        2) Initialize low and high indexes as 0 and n-1 respectively.
        3) Do following while low index ‘l’ is smaller than high index ‘h’.
        …..a) If str[l] is not same as str[h], then return false.
        …..b) Increment l and decrement h, i.e., do l++ and h–.
       4) If we reach here, it means we didn’t find a mis
       Following is C implementation to check if a given string is palindrome or not. */
        public bool PalindromPermutationWithSorting(string inputString1)
        {
            inputString1 = inputString1.Replace(' ', ' ');
            var beginingIndex = 0;
            var stringEndLength = inputString1.Length;
            while (beginingIndex != stringEndLength)
            {
                if (inputString1[beginingIndex] != inputString1[stringEndLength])
                {
                    return false;
                }
                return true;
            }
            return true;
        }
    }
}
