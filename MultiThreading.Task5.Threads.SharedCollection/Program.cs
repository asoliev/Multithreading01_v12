/*
 * 5. Write a program which creates two threads and a shared collection:
 * the first one should add 10 elements into the collection and the second should print all elements
 * in the collection after each adding.
 * Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.Task5.Threads.SharedCollection
{
    class Program
    {
        private static List<int> sharedCollection = new();
        private const int ELEMENTS_COUNT = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("5. Write a program which creates two threads and a shared collection:");
            Console.WriteLine("the first one should add 10 elements into the collection" +
                " and the second should print all elements in the collection after each adding.");
            Console.WriteLine("Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.");
            Console.WriteLine("\n");

            // feel free to add your code
            Task.Run(() => AddElements(ELEMENTS_COUNT));
            Task.Run(() => PrintElements());

            Console.ReadLine();
        }
        private static void AddElements(int count)
        {
            for (int i = 0; i < count; i++)
            {
                sharedCollection.Add(i);
                Console.WriteLine($"Added {i}");

                Thread.Sleep(500);//imitate the delays to show the process queue in console.
            }
        }
        private static void PrintElements()
        {
            var printedElements = 0;
            while (true)
            {
                if (sharedCollection.Count == 0)
                    continue;

                if (printedElements < sharedCollection.Count)
                {
                    Console.WriteLine($"Printed {sharedCollection[printedElements]}");
                    ++printedElements;
                }
                if (printedElements == ELEMENTS_COUNT)
                {
                    Console.WriteLine("\n\nAll elements printed. Press 'Enter' to exit.");
                    break;
                }
                Thread.Sleep(500);//imitate the delays to show the process queue in console.
            }
        }
    }
}