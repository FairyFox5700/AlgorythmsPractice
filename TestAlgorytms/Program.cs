// See https://aka.ms/new-console-template for more information

using TestAlgorytms.Search;
using TestAlgorytms.SimpleSorting;
using TestAlgorytms.Utills;

var nums = new int[10];
Random rnd = new Random(100);
for (int i = 0; i < 10; i++)
    nums[i] = ((int)(rnd.NextDouble() * 100));
Console.WriteLine("Before sorting: ");
AlgorytmsUtills.DisplayElements(nums);
Console.WriteLine("During sorting: ");

InsertionSortMain.InsertionSort(nums);
Console.WriteLine("Binary search 66:" + BinarySearchMain.BinarySerach(nums, 66));
//SelectionSortMain.SelectionSort(nums);
//BubbleSortMain.BubbleSort(nums);
Console.WriteLine("After sorting: ");
AlgorytmsUtills.DisplayElements(nums);
Console.WriteLine("Hello, World!");
