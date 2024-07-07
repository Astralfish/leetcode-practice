using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class SingleNumberTests2
{
    private readonly SingleNumber2 sut = new SingleNumber2();

    [Theory]
    [MemberData(nameof(FindSingleNumberTestData))]
    public void FindSingleNumber_ShouldReturnSingleNumber(int[] numbers, int expected)
    {
        var result = sut.FindSingleNumber(numbers);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> FindSingleNumberTestData()
    {
        yield return [new int[] { 2, 2, 3, 2 }, 3];
        yield return [new int[] { 0, 1, 0, 1, 0, 1, 99 }, 99];
        yield return [new int[] { 1 }, 1];
    }
}
