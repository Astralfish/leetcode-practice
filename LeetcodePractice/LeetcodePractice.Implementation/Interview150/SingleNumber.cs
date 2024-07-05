namespace LeetcodePractice.Implementation.Interview150;
public class SingleNumber
{
    public int FindSingleNumber(int[] numbers)
    {
        return numbers.Aggregate((acc, curr) => acc ^ curr);
    }
}
