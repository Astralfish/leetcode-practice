using System.Numerics;

namespace LeetcodePractice.Implementation.Interview150;
public class BitwiseAndOfNumberRange
{
    public int BitwiseAnd(int from, int to)
    {
        if (from == to)
        {
            return from;
        }

        var xor = from ^ to;
        var sameLeadingBitsCount = BitOperations.LeadingZeroCount((uint)xor);
        var mask = ~(0xffffffff >>> sameLeadingBitsCount);
        return (int)(from & mask);
    }

}
