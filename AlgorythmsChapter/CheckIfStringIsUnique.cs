using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter
{
    internal class CheckIfStringIsUnique
    {
        /*Is Unique: Implement an algorithm to determine if a string has all unique characters.What if you
            cannot use additional data structures?*/
        /*
         * First way
         * Brute Force technique:
         * Run 2 loops with variable i and j.
         * Compare str[i] and str[j].
         * If they become equal at any point, return false.
         */
        public static bool IsUniqueCharacters(string testString)
        {
            for (int i = 0; i < testString.Length; i++)
            {
                for (int j = i + 1; j < testString.Length; j++)
                {
                    if (testString[i] == testString[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /*
         * Second way
         * Sorting: Using sorting based on ASCII values of characters
         * Time Complexity: O(n log n)
         */

        public static bool IsUniqueCharactersWithSorting(string testString)
        {
            var charArray = testString.ToCharArray();
            Array.Sort(charArray);

            for (int i = 0; i < testString.Length; i++)
            {
                if (testString[i] == testString[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        /*
         * Third way
         * Use of Extra Data Structure:
         * This approach assumes ASCII char set(8 bits).
         * The idea is to maintain a boolean array for the characters.
         * The 256 indices represent 256 characters. All the array elements are initially set to false.
         * As we iterate over the string, set true at the index equal to the int value of the character.
         * If at any time, we encounter that the array value is already true, it means the character with that int value is repeated.
         * Time Complexity: O(n)
         */
        public static bool IsUniqueCharactersWithExtraDataStructureAsVector(string testString)
        {
            var vector = new bool[testString.Length];
            var charArray = testString.ToCharArray();
            foreach (var charValue in charArray)
            {
                var index = (int)charValue;
                if (vector[index])
                {
                    return false;
                }

                vector[index] = true;
            }

            return true;
        }

        /*
         *  Forth way
         * Using sets() function:
         * Convert the string to set.
         * If the length of set is equal to the length of the string then return True else False.
         */

        public static bool IsUniqueCharactersWithExtraDataStructureAsHash(string testString)
        {
            var hashList = new HashSet<char>(testString.ToCharArray());
            return hashList.Count >= testString.Length;
        }

        /*
         * Fifth way
         * Without Extra Data Structure: The approach is valid for strings having alphabet as a-z.
         * This approach is a little tricky. Instead of maintaining a boolean array, we maintain an integer value called checker(32 bits).
         * As we iterate over the string, we find the int value of the character with respect to ‘a’ with the statement int bitAtIndex = str.charAt(i)-‘a’;
         * Then the bit at that int value is set to 1 with the statement 1 << bitAtIndex .
         * Now, if this bit is already set in the checker, the bit AND operation would make the checker > 0. Return false in this case.
         * Else Update checker to make the bit 1 at that index with the statement checker = checker | (1 <<bitAtIndex);
         * Time Complexity: O(n)
         */

        public static bool uniqueCharacters(string str)
        {
            // Assuming string can have
            // characters a-z this has
            // 32 bits set to 0
            int checker = 0;

            for (int i = 0; i < str.Length; i++)
            {
                int bitAtIndex = str[i] - 'a';

                // if that bit is already set
                // in checker, return false
                var dd = 1 << bitAtIndex;
                if ((checker & (1 << bitAtIndex)) > 0)
                {
                    return false;
                }

                // otherwise update and continue by
                // setting that bit in the checker
                checker = checker | (1 << bitAtIndex);
            }

            // no duplicates encountered,
            // return true
            return true;
        }
    }
}
