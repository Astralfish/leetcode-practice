using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;

public class RemoveElementTests
{
    private readonly RemoveElement sut = new RemoveElement();

    [Theory]
    [MemberData(nameof(TestData))]
    public void RemoveShouldRemoveValuessFromArray(int[] array, int val, int[] expected)
    {
        var k = sut.Remove(array, val);

        array.Take(k).Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new int[] { }, 1, new int[] { } };
        yield return new object[] { new int[] { 1, 1, 2, 3, 1, -1, 1 }, 1, new int[] { 2, 3, -1 } };
    }
}
