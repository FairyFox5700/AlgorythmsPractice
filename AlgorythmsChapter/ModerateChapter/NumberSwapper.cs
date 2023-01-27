using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.ModerateChapter
{
    internal class NumberSwapper
    {
        // Number Swapper: Write a function to swap a number in place(that is, without temporary variables).

        public void SwapNumbers(int a, int b)
        {
            a = a - b; //diff
            b = b - a;
            a = a + b;
        }

        //16.2 Word Frequencies: Design a method to find the frequency of occurrences of any given word in a
        //book.What if we were running this algorithm multiple times?

        // solution with O(n). Not rerunnable
        public int WordFrequencies(string text, string word)
        {
            var wordArray = text.Split(' ');
            var count = 0;
            foreach (var wordData in wordArray)
            {
                if (wordData.Equals(word, StringComparison.InvariantCultureIgnoreCase))
                {
                    count++;
                }
            }

            return count;
        }

        public int WordFrequencies2(string text, string word)
        {
            var wordArray = text.Split(' ');
            var dictionary = new Dictionary<string, int>(); // hash map with word and count of occurrences
            foreach (var wordData in wordArray)
            {
                if (dictionary.ContainsKey(wordData))
                {
                    dictionary.Add(wordData, dictionary[wordData] + 1);
                }
                else
                {
                    dictionary.Add(word, 0);
                }
            }

            // get data
            var dataCount = dictionary[word];
            return dataCount;
        }

        //16.3 Intersection: Given two straight line segments (represented as a start point and an end point),
        // compute the point of intersection, if any.

        public void LineIntersection(Point point1Begin, Point point1End, Point point2Begin, Point point2End)
        {

        }
    }
}