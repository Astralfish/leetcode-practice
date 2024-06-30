using BenchmarkDotNet.Attributes;
using LeetcodePractice.Implementation.Interview150;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePractice.Benchmarks.Interview150;
public class MinimumSizeSubarraySumBenchmarks
{
    private int[] numbers = [];
    private int target;
    private const int maxNumber = 100;
    private MinimumSizeSubarraySum minimumSizeSubarraySum = new MinimumSizeSubarraySum();

    [Params(100, 1000, 10000, 100000, 1000000)]
    public int N { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        numbers = new int[N];
        var generator = new Random(42);
        for (var i = 0; i < N; i++)
        {
            numbers[i] = generator.Next(maxNumber);
        }
        target = N * maxNumber / 20;
    }

    [Benchmark]
    public int CalculateSubarraySize() => minimumSizeSubarraySum.CalculateSubarraySize(numbers, target);

    [Benchmark]
    public int CalculateSubarraySizeOptimized() => minimumSizeSubarraySum.CalculateSubarraySizeOptimized(numbers, target);
}
