using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class RemoveDuplicatesFromSoretedArrayIITests
{
    private readonly RemoveDuplicatesFromSortedArrayII sut;

    public RemoveDuplicatesFromSoretedArrayIITests()
    {
        this.sut = new RemoveDuplicatesFromSortedArrayII();
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void RemoveDuplicatesShouldRemoveElementsThatOccurMoreThanTwice(int[] inputArray, int[] expected)
    {
        var k = sut.RemoveDuplicates(inputArray);
        k.Should().Be(expected.Length);
        inputArray.Take(k).Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new int[] { 1, 1, 1, 1, 2, 2, 3 }, new int[] { 1, 1, 2, 2, 3 } };
        yield return new object[] { new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 }, new int[] { 1, 1, 2, 2, 3, 3 } };
    }
}
