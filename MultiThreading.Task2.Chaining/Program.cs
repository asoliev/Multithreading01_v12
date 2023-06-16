/*
 * 2.	Write a program, which creates a chain of four Tasks.
 * First Task – creates an array of 10 random integer.
 * Second Task – multiplies this array with another random integer.
 * Third Task – sorts this array by ascending.
 * Fourth Task – calculates the average value. All this tasks should print the values to console.
 */
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining
{
    public class Program
    {
        private const int ARRAY_SIZE = 10;
        public static async Task Main()
        {
            Console.WriteLine(".Net Mentoring Program. MultiThreading V1 ");
            Console.WriteLine("2.	Write a program, which creates a chain of four Tasks.");
            Console.WriteLine("First Task – creates an array of 10 random integer.");
            Console.WriteLine("Second Task – multiplies this array with another random integer.");
            Console.WriteLine("Third Task – sorts this array by ascending.");
            Console.WriteLine("Fourth Task – calculates the average value. All this tasks should print the values to console");
            Console.WriteLine();

            await Task.Run(() => GenerateRandomArray(ARRAY_SIZE))
                .ContinueWith(x => MultiplyArray(x.Result))
                .ContinueWith(x => SortArray(x.Result))
                .ContinueWith(x => GetAvarage(x.Result));
            
            Console.ReadLine();
        }

        private static int[] GenerateRandomArray(int size)
        {
            var rnd = new Random();
            var array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(10, 100);
            }
            Console.WriteLine($"Initial array is [{string.Join(", ", array)}].");
            return array;
        }

        private static int[] MultiplyArray(int[] arr)
        {
            //Pay attention on requirements
            //Have to multiply by a random number not by a random array
            var rnd = new Random();
            var val = rnd.Next(10, 100);
            int[] multiple = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                multiple[i] = arr[i] * val;
            }
            Console.WriteLine($"Initial array multiply by {val} is [{string.Join(", ", multiple)}].");
            return multiple;
        }

        private static int[] SortArray(int[] arr)
        {
            int[] sorted = arr.OrderBy(i => i).ToArray();

            Console.WriteLine($"Sorted array is [{string.Join(", ", sorted)}].");
            return sorted;
        }

        private static double GetAvarage(int[] arr)
        {
            var average = arr.Average(i => i);

            Console.WriteLine($"Average of the sorted array is {average}.");
            return average;
        }
    }
}