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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".Net Mentoring Program. MultiThreading V1 ");
            Console.WriteLine("2.	Write a program, which creates a chain of four Tasks.");
            Console.WriteLine("First Task – creates an array of 10 random integer.");
            Console.WriteLine("Second Task – multiplies this array with another random integer.");
            Console.WriteLine("Third Task – sorts this array by ascending.");
            Console.WriteLine("Fourth Task – calculates the average value. All this tasks should print the values to console");
            Console.WriteLine();

            var task1 = Task.Run(() => GenerateRandomArray());

            var multiples = task1.ContinueWith(x => MultiplyArray(task1.Result));

            var orderedArray = multiples.ContinueWith(x => multiples.Result.OrderBy(t => t));

            var avg = orderedArray.ContinueWith(x => orderedArray.Result.Average(t => t));

            Console.WriteLine(avg.Result);

            Console.ReadLine();
        }
        private static int[] GenerateRandomArray()
        {
            var rnd = new Random();
            var array = new int[10];
            for (int i = 0; i < 10; i++)
            {
                array[i] = rnd.Next(10, 100);
            }
            Console.WriteLine(string.Join(", ", array));
            return array;
        }
        private static int[] MultiplyArray(int[] array1)
        {
            int[] array2 = GenerateRandomArray();
            int[] multiple = new int[array1.Length];
            for (int i = 0; i < 10; i++)
            {
                multiple[i] = array1[i] * array2[i];
            }
            Console.WriteLine(string.Join(", ", multiple));
            return multiple;
        }
    }
}