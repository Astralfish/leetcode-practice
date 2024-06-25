using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

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

    public int CalculateWaterVolumeInPlace(int[] levels)
    {
        var leftMax = CalculateLeftMax(levels);
        var rightMax = CalculateRightMax(levels);
        var volume = 0;
        for (int i = 0; i < levels.Length; i++)
        {
            var verticalVolume = Math.Min(leftMax[i], rightMax[i]) - levels[i];
            if (verticalVolume > 0)
            {
                volume += verticalVolume;
            }
        }
        return volume;
    }

    private int[] CalculateLeftMax(int[] levels)
    {
        var leftMax = new int[levels.Length];

        int currentMax = levels[0];
        for (int i = 0; i < levels.Length; i++)
        {
            currentMax = Math.Max(levels[i], currentMax);
            leftMax[i] = currentMax;
        }
        return leftMax;
    }

    private int[] CalculateRightMax(int[] levels)
    {
        var rightMax = new int[levels.Length];

        int currentMax = levels[^1];
        for (int i = levels.Length - 1; i >= 0; i--)
        {
            currentMax = Math.Max(levels[i], currentMax);
            rightMax[i] = currentMax;
        }
        return rightMax;
    }
}
