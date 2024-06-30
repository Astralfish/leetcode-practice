using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class _3SumTests
{
    private readonly _3Sum sut = new _3Sum();

    [Theory]
    [MemberData(nameof(Calculate0SumTripletsTestData))]
    public void Calculate0SumTriplets(int[] nums, IList<IList<int>> expected)
    {
        var result = sut.Calculate0SumTriplets(nums);
        result.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> Calculate0SumTripletsTestData()
    {
        yield return [new int[] { -1, 0, 1, 2, -1, -4 }, new List<IList<int>>
        {
            new List<int> { -1,-1,2 },
            new List<int> { -1, 0, 1 },
        }];
    }
}
