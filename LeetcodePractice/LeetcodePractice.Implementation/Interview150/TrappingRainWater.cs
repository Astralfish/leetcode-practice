namespace LeetcodePractice.Implementation.Interview150;

//https://leetcode.com/problems/trapping-rain-water/description/?envType=study-plan-v2&envId=top-interview-150
public class TrappingRainWater
{
    public int CalculateWaterVolume(int[] levels)
    {
        var leftMaxLevels = CalculateMax(levels);
        var rightMaxLevels = CalculateMax(levels.Reverse()).Reverse();

        return leftMaxLevels.Zip(rightMaxLevels, (l, r) => (l.Current, LeftMax: l.Max, RightMax: r.Max))
            .Select(h => Math.Min(h.LeftMax, h.RightMax) - h.Current)
            .Where(wl => wl > 0)
            .Sum();
    }

    private IEnumerable<(int Current, int Max)> CalculateMax(IEnumerable<int> levels)
    {
        int currentMax = 0;
        foreach (var level in levels)
        {
            currentMax = Math.Max(level, currentMax);
            yield return (level, currentMax);
        }
    }
}
