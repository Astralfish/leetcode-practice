using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class BitwiseAndOfNumberRangeTests
{
    private readonly BitwiseAndOfNumberRange sut = new BitwiseAndOfNumberRange();

    [Theory]
    [MemberData(nameof(BitwiseAndTestData))]
    public void BitwiseAnd_ShouldReturnAndOfAllNumbersBetweenFromAndTo(int from, int to, int expected)
    {
        var result = sut.BitwiseAnd(from, to);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> BitwiseAndTestData()
    {
        yield return [5, 7, 4];
        yield return [0, 0, 0];
        yield return [1, 2147483647, 0];
        yield return [1, 1, 1];
    }
}
