using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class MajorityElementTests
{
    private readonly MajorityElement sut = new MajorityElement();

    [Theory]
    [MemberData(nameof(TestData))]
    public void FindMajorityElementShouldFindMajorityElement(int[] array, int expected)
    {
        var result = sut.FindMajorityElement(array);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new int[] { 10 }, 10 };
        yield return new object[] { new int[] { 1, 2, 1 }, 1 };
        yield return new object[] { new int[] { 2, 2, 1, 1, 1, 2, 2 }, 2 };
    }
}
