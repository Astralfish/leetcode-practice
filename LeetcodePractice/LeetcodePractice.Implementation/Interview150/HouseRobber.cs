namespace LeetcodePractice.Implementation.Interview150;

//https://leetcode.com/problems/house-robber/description/?envType=study-plan-v2&envId=top-interview-150
public class HouseRobber
{
    public int BestValue(int[] houseValues)
    {
        Span<int> bestValueTracker = stackalloc int[3];
        for (int i = 0; i < houseValues.Length; i++)
        {
            bestValueTracker[2] = Math.Max(bestValueTracker[1], bestValueTracker[0] + houseValues[i]);
            bestValueTracker[0] = bestValueTracker[1];
            bestValueTracker[1] = bestValueTracker[2];
        }

        return bestValueTracker[2];
    }
}
