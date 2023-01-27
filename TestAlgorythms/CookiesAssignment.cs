using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgorythms
{
    internal class CookiesAssignment
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            var count = 0;
            Array.Sort(g);
            Array.Sort(s);
            var gPointer = 0;
            var sPointer = 0;
            while (sPointer <= s.Length - 1 && gPointer <= g.Length - 1)
            {
                if (g[gPointer] <= s[sPointer])
                {
                    // we are good to add cookie to this person.
                    count++;
                    sPointer++;
                    gPointer++;
                }
                else
                {
                    //find bigger cookie
                    sPointer++;
                }
            }
            return count;
        }
    }
}
