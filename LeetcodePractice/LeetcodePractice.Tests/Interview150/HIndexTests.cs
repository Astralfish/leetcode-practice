using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class HIndexTests
{
    private readonly HIndex sut = new HIndex();

    [Theory]
    [MemberData(nameof(CalculateHIndexTestData))]
    public void CalculateHIndex_ShouldReturnCorrectHIndex(int[] citationCounts, int expected)
    {
        var result = sut.CalculateHIndex(citationCounts);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> CalculateHIndexTestData()
    {
        yield return [new int[] { 3, 0, 6, 1, 5 }, 3];
        yield return [new int[] { 1, 3, 1 }, 1];
    }
}
