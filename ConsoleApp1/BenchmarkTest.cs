using BenchmarkDotNet.Attributes;

namespace ConsoleApp1;

[MemoryDiagnoser()]
public class BenchmarkTest
{
    int[] sequence = { 1, 2, 3 };
    int[] array= new int[10000000]; 
    Random rnd = new Random();
    [GlobalSetup]
    public void Setup()
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rnd.Next(1, 10);
        }
        for (int i = 0; i < sequence.Length; i++)
        {
            array[rnd.Next(0, array.Length)] = sequence[i];
        }
    }

    [Benchmark]
    public void TestWithParallel()
    {
        int count = 0;
        Parallel.For(0, array.Length - sequence.Length + 1, i =>
        {
            bool found = true;
            for (int j = 0; j < sequence.Length; j++)
            {
                if (array[i + j] != sequence[j])
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                Interlocked.Increment(ref count);
            }
        });
    }

    [Benchmark]
    public void TestWithoutParallel()
    {
        int count = 0;
        for (int i = 0; i < array.Length - sequence.Length + 1; i++)
        {
            bool found = true;
            for (int j = 0; j < sequence.Length; j++)
            {
                if (array[i + j] != sequence[j])
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                count++;
            }
        }
    }
}