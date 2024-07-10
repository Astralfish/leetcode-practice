using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class HouseRobberTests
{
    private readonly HouseRobber sut = new();

    [Theory]
    [MemberData(nameof(HouseRobberTestData))]
    public void BestValue_ShouldReturnHighestPossibleValue(int[] houseValues, int expected)
    {
        var result = sut.BestValue(houseValues);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> HouseRobberTestData()
    {
        yield return [new int[] { 1, 2, 3, 1 }, 4];
        yield return [new int[] { 2, 7, 9, 3, 1 }, 12];
        yield return [new int[] { 1 }, 1];
    }
}
