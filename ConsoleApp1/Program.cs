// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using ConsoleApp1;

var summary = BenchmarkRunner.Run<BenchmarkTest>();

            // int[] sequence = { 1, 2, 3 };
            // //write array of 1000 elements with 1,2,3,4,5 in random places
            // int[] array = new int[1000000];
            // Random rnd = new Random();
            // for (int i = 0; i < array.Length; i++)
            // {
            //     array[i] = rnd.Next(1, 10);
            // }
            // for (int i = 0; i < sequence.Length; i++)
            // {
            //     array[rnd.Next(0, array.Length)] = sequence[i];
            // }
            // //end of write array of 1000 elements with 1,2,3,4,5 in random places
            // int count = 0;
            //
            // Parallel.For(0, array.Length - sequence.Length + 1, i =>
            // {
            //     bool found = true;
            //     for (int j = 0; j < sequence.Length; j++)
            //     {
            //         if (array[i + j] != sequence[j])
            //         {
            //             found = false;
            //             break;
            //         }
            //     }
            //     if (found)
            //     {
            //         Console.WriteLine("Sequence found by thread {0} at index {1}", Task.CurrentId, i);
            //         System.Threading.Interlocked.Increment(ref count);
            //     }
            // });
            //
            // Console.WriteLine("Total number of occurrences: {0}", count);
