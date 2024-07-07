namespace LeetcodePractice.Implementation.Interview150;
public class SingleNumber2
{
    public int FindSingleNumber(int[] numbers) => numbers.Aggregate((r1: 0, r2: 0), BitwiseModulo3).r1;

    public (int r1, int r2) BitwiseModulo3((int r1, int r2) left, int right)
    {
        return ((left.r1 & ~right) | (~left.r1 & ~left.r2 & right), (left.r1 & right) | (left.r2 & ~right));
    }
}
