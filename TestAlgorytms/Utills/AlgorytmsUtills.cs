using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgorytms.Utills
{
    public class AlgorytmsUtills
    {
        public static void DisplayElements(int[] array)
        {
            for (int i = 0; i <= array.Length - 1; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
        }
    }
}
