using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;

public class CandyTests
{
    private readonly Candy sut = new Candy();

    [Theory]
    [MemberData(nameof(MinimumRequiredCandyTestData))]
    public void MinimumRequiredCandy_ShouldReturnCorrectNumber(List<int> children, int expected)
    {
        var result = sut.MinimumRequiredCandy(children);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> MinimumRequiredCandyTestData()
    {
        yield return [new List<int> { 1, 0, 2 }, 5];
        yield return [new List<int> { 1, 2, 2 }, 4];
        yield return [new List<int> { 7, 7, 1, 5, 3, 4, 3, 2, 1, 2, 1 }, 20];
        yield return [new List<int> { 1, 2, 3, 4, 3, 2, 1, 0, -1, 0, 1, 4, 2, 1, 4 }, 41];
    }
}
