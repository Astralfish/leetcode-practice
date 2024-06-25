using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Benchmarks.Interview150;
public class TrappingRainWaterBenchmarks
{
    private int[] levels = [];
    private const int maxLevel = 100;
    private TrappingRainWater trappingRainWater = new TrappingRainWater();

    [Params(10, 100, 1000, 10000, 100000, 1000000)]
    public int N;

    [GlobalSetup]
    public void Setup()
    {
        var generator = new Random(42);
        levels = Enumerable.Repeat(1, N)
            .Select(i => generator.Next(maxLevel))
            .ToArray();
        trappingRainWater = new TrappingRainWater();
    }

    [Benchmark]
    public int CalculateWaterVolume() => trappingRainWater.CalculateWaterVolume(levels);

    [Benchmark]
    public int CalculateWaterVolumeInPlace() => trappingRainWater.CalculateWaterVolumeInPlace(levels);
}
