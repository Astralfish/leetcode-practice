using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class MinimumSizeSubarraySumTests
{
    private readonly MinimumSizeSubarraySum sut = new MinimumSizeSubarraySum();

    [Theory]
    [MemberData(nameof(MinimumSizeSubarraySizeTestData))]
    public void CalculateSubarraySize_ShouldReturnCorrectSubarraySize(int[] numbers, int target, int expected)
    {
        var result = sut.CalculateSubarraySize(numbers, target);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(MinimumSizeSubarraySizeTestData))]
    public void CalculateSubarraySizeOptimized_ShouldReturnCorrectSubarraySize(int[] numbers, int target, int expected)
    {
        var result = sut.CalculateSubarraySizeOptimized(numbers, target);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> MinimumSizeSubarraySizeTestData()
    {
        yield return [new int[] { 2, 3, 1, 2, 4, 3 }, 7, 2];
        yield return [new int[] { 1, 4, 4 }, 4, 1];
        yield return [new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 11, 0];
    }
}
