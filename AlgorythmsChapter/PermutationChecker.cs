using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter
{
    internal class PermutationChecker
    {
        /* Check Permutation: Given two strings, write a method to decide if one is a permutation of the
         other. */

        /*
         * Method 1 (Use Sorting)
         * 1) Sort both strings
         * 2) Compare the sorted strings
         */
        /*Time Complexity: Time complexity of this method depends upon the sorting technique used.
         In the above implementation, quickSort is used which may be O(n^2) in worst case.
        If we use a O(nLogn) sorting algorithm like merge sort, then the complexity becomes O(nLogn)*/

        public bool CheckPermutaion(string stringFirst, string stringSecond)
        {
            var chararr1 = stringFirst.ToCharArray();
            var chararr2 = stringSecond.ToCharArray();

            if (chararr1.Length != chararr2.Length) return false;

            Array.Sort(chararr1);
            Array.Sort(chararr2);

            for (int i = 0; i < chararr1.Length; i++)
            {
                if (chararr1[i] != chararr2[i])
                {
                    return false;
                }
            }

            return true;
        }

        /*Method 2 (Count characters)
         This method assumes that the set of possible characters in both strings is small.
         In the following implementation, it is assumed that the characters are stored using 8 bit and there can be 256 possible characters.
         1) Create count arrays of size 256 for both strings. Initialize all values in count arrays as 0.
         2) Iterate through every character of both strings and increment the count of character in the corresponding count arrays.
         3) Compare count arrays. If both count arrays are same, then return true.*/
        public bool CheckPermutaionV2(string stringFirst, string stringSecond)
        {
            var countOfArray1 = new int[256];
            var countOfArray2 = new int[256];

            if (stringFirst != stringSecond)
            {
                return false;
            }

            for (int i = 0; i < stringFirst.Length; i++)
            {
                countOfArray1[stringFirst[i]]++;
                countOfArray1[stringSecond[i]]++;
            }

            for (int i = 0; i < countOfArray1.Length; i++)
            {
                if (countOfArray1[i] != countOfArray2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
