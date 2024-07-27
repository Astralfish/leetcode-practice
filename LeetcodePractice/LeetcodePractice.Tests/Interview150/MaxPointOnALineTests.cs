using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class MaxPointOnALineTests
{
    private readonly MaxPointOnALine sut = new MaxPointOnALine();

    [Theory]
    [MemberData(nameof(GetMaxTestData))]
    public void GetMax_ShouldReturnMaximumNumberOFColinearPoints(int[][] points, int expected)
    {
        var result = sut.GetMax(points);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> GetMaxTestData()
    {
        yield return [new int[][] { [1, 1], [2, 2], [3, 3] }, 3];
        yield return [new int[][] { [2, 3], [3, 3], [-5, 3] }, 3];
        yield return [new int[][] { [4, 5], [4, -1], [4, 0] }, 3];
        yield return [new int[][] { [-6, -1], [3, 1], [12, 3] }, 3];
        yield return [new int[][] { [1, 1], [3, 2], [5, 3], [4, 1], [2, 3], [1, 4] }, 4];
        yield return [new int[][] { [1, 1], [3, 2],  }, 2];
        yield return [new int[][] { [1, 1] }, 1];
        yield return [new int[][] { }, 0];
    }
}
