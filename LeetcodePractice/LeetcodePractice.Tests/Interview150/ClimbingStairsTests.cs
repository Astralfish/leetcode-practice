using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class ClimbingStairsTests
{
    private readonly ClimbingStairs sut = new();

    [Theory]
    [MemberData(nameof(HowManyWaysTestData))]
    public void HowManyWays_ShouldReturnNumberOfWaysToClimbNStairs(int n, int expected)
    {
        var result = sut.HowManyWays(n);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> HowManyWaysTestData()
    {
        yield return [2, 2];
        yield return [3, 3];
        yield return [4, 5];
    }
}
