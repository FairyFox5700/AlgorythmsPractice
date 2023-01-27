using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgorytms.SimpleSorting
{
    public class ShellSort
    {
        public void Sort(int[] array)
        {
            for (int interval = array.Length / 2; interval < array.Length / 2; interval = interval / 2)
            {
                var temp = array[interval];

                for (int i = 0; i < array.Length; i++)
                {
                    if (temp < array[i])
                    {
                        (temp, array[i]) = (array[i], temp);
                    }
                }
            }
        }
    }
}
