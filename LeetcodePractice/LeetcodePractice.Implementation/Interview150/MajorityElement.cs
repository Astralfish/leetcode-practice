namespace LeetcodePractice.Implementation.Interview150;
public class MajorityElement
{
    public int FindMajorityElement(int[] nums) => nums.GroupBy(n => n).OrderByDescending(g => g.Count()).First().Key;
}
