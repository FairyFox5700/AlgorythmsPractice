// See https://aka.ms/new-console-template for more information

using TestAlgorythms;

int MaxContiniousSumDynamicWithoutMemory(int[] array, int n)
{
    int sumEndingHere = 0;
    int sumSoFar = 0;
    for (int i = 0; i < n; i++)
    {
        sumEndingHere = array[i] + sumEndingHere;
        if (sumEndingHere >= 0)
        {
            if (sumEndingHere > sumSoFar)
            {
                sumSoFar = sumEndingHere;
            }
        }
        else
        {
            sumEndingHere = 0;
        }
    }

    return sumSoFar;
}

Console.WriteLine(MaxContiniousSumDynamicWithoutMemory(new int[] { -2, 11, -4, 13, -5, 2 }, 6));
Console.WriteLine("Count of pairs is "
                  + GFG.getPairsCount(new int[] { 1, 5, 7, -1 }, sum: 6));
Console.WriteLine("Hello, World!");
