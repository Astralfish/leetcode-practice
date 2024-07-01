namespace LeetcodePractice.Implementation.Interview150;
public class GameOfLife
{
    private List<(int x, int y)> NeighborOffsets =
    [
        (-1, -1),   (0, -1),    (1, -1),
        (-1, 0),                (1, 0),
        (-1, 1),    (0, 1),     (1, 1),
    ];

    public void Next(int[][] board)
    {
        var nextState = new int[board.Length, board[0].Length];
        for (int x = 0; x < board.Length; x++)
        {
            var column = board[x];
            for (int y = 0; y < column.Length; y++)
            {
                nextState[x, y] = NextCellState(column[y], SumNeighbors(board, x, y));
            }
        }

        for (int x = 0; x < board.Length; x++)
        {
            var column = board[x];
            for (int y = 0; y < column.Length; y++)
            {
                board[x][y] = nextState[x, y];
            }
        }
    }

    private int NextCellState(int current, int sum) => (current, sum) switch
    {
        (1, <= 1) => 0,
        (1, >= 4) => 0,
        (1, _) => 1,
        (0, 3) => 1,
        (0, _) => 0,
    };

    private int SumNeighbors(int[][] board, int x, int y) => NeighborOffsets.Select(offset => GetNeighbor(board, x + offset.x, y + offset.y)).Sum();

    private int GetNeighbor(int[][] board, int x, int y)
    {
        if (x < 0 || y < 0 || x >= board.Length || y >= board[0].Length)
        {
            return 0;
        }
        return board[x][y];
    }
}
