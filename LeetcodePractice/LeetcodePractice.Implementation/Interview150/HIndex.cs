namespace LeetcodePractice.Implementation.Interview150;
public class HIndex
{
    public int CalculateHIndex(int[] citationCounts)
    {
        int hIndex = 0;
        foreach (int citationCount in citationCounts.OrderByDescending(c => c))
        {
            if (citationCount > hIndex)
            {
                hIndex++;
            }
            else
            {
                break;
            }
        }
        return hIndex;
    }
}
