namespace LeetcodePractice.Implementation.Interview150;
public class MaxPointOnALine
{
    public int GetMax(int[][] points)
    {
        if (points.Length <= 2)
        {
            return points.Length;
        }

        var max = 2;
        for (int i = 0; i < points.Length; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                var currentCount = 2;
                for (int k = 0; k < points.Length; k++)
                {
                    if (k != i && k != j && AreColinear(points[i], points[j], points[k]))
                    {
                        currentCount++;
                    }
                }

                max = Math.Max(max, currentCount);
            }
        }

        return max;
    }

    private static bool AreColinear(int[] a, int[] b, int[] c) => (c[1] - a[1]) * (b[0] - a[0]) == (b[1] - a[1]) * (c[0] - a[0]);
}
