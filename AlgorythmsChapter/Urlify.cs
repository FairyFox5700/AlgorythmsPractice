using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter
{
    /*URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
     has sufficient space at the end to hold the additional characters, and that you are given the "true"
     length of the string. (Note: If implementing in Java, please use a character array so that you can
     perform this operation in place.) */
    public class Urlify
    {
        /*
         * A simple solution is to create an auxiliary string and copy characters one by one.
         * Whenever space is encountered, place %20 in place of it.
         * A better solution to do in-place assuming that we have extra space in the input string.
         * We first count the number of spaces in the input string. Using this count, we can find
         * the length of the modified (or result) string. After computing the new length we fill the string in-place from the end.
         */

        /*Find out the length of the given string
        Convert the given string into an array of type character
        Find out the count of spaces within the input string
        Multiply the number of spaces with 2 to find out the extra space required to replace ' ' with '%20'  for example if there is one ' ' space then we need two extra places the given string to add '%20'
        Add extra spaces required to shift characters and replace ' ' with '%20'
        Iterate through the given string but note that starts from the end and working backward because we have added an extra buffer at the end, which allows us to change characters without worrying about what we're overwriting.

        If ' ' space found then replace ' ' with '%20'
        If not found then shift the current character by 2 places and continue iteration

        Finally, print the modified string.*/
        public string? UrlifyString(string? testString)
        {
            testString.Trim();
            var charArray = testString.ToCharArray();
            var whiteSpaceCount = 0;

            foreach (var character in charArray)
            {
                if (character == ' ')
                {
                    whiteSpaceCount++;
                }
            }

            var newArrayLength = testString.Length + whiteSpaceCount * 2;
            if (newArrayLength < testString.Length)
            {
                return testString;
            }

            var newArray = new char[newArrayLength];

            for (int i = newArrayLength - 1; i >= 0; i--)
            {
                if (charArray[i] == ' ')
                {
                    newArray[i] = '0';
                    newArray[i + 1] = '2';
                    newArray[i + 2] = '%';
                    i += 3;
                }
                else
                {
                    newArray[i] = charArray[i];
                }
            }

            return newArray.ToString();
        }
    }
}
