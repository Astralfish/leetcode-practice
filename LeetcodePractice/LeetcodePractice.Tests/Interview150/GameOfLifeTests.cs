using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class GameOfLifeTests
{
    private readonly GameOfLife sut = new GameOfLife();

    [Theory]
    [MemberData(nameof(NextTestData))]
    public void Next_ShouldAdvanceBoardToNextState(int[][] board, int[][] expected)
    {
        sut.Next(board);
        board.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> NextTestData()
    {
        yield return [new int[][] { [0, 1, 0], [0, 0, 1], [1, 1, 1], [0, 0, 0] }, new int[][] { [0, 0, 0], [1, 0, 1], [0, 1, 1], [0, 1, 0] }];
        yield return [new int[][] { [1, 1], [1, 0] }, new int[][] { [1, 1], [1, 1] }];
    }
}
