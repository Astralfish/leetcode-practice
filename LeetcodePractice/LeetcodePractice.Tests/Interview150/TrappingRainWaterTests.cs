using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;

public class TrappingRainWaterTests
{
    public readonly TrappingRainWater sut = new TrappingRainWater();

    [Theory]
    [MemberData(nameof(TrappingRainWaterTestData))]
    public void CalculateWaterVolume_ShouldReturnCorrectVolume(int[] levels, int expected)
    {
        var result = sut.CalculateWaterVolume(levels);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TrappingRainWaterTestData))]
    public void CalculateWaterVolumeInPlace_ShouldReturnCorrectVolume(int[] levels, int expected)
    {
        var result = sut.CalculateWaterVolumeInPlace(levels);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> TrappingRainWaterTestData()
    {
        yield return [new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6];
        yield return [new int[] { 4, 2, 0, 3, 2, 5 }, 9];
    }
}
