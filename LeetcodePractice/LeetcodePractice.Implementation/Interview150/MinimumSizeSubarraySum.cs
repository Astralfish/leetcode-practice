using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePractice.Implementation.Interview150;
public class MinimumSizeSubarraySum
{
    public int CalculateSubarraySize(int[] numbers, int target)
    {
        var minimumLength = int.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            var sum = 0;
            var length = 0;
            for (int j = i; j < numbers.Length; j++)
            {
                sum += numbers[j];
                length++;

                if (sum >= target)
                {
                    minimumLength = Math.Min(minimumLength, length);
                    break;
                }
                if (length == numbers.Length - 1 && minimumLength == int.MaxValue)
                {
                    return 0;
                }
            }
        }
        return minimumLength;
    }

    public int CalculateSubarraySizeOptimized(int[] numbers, int target)
    {
        var windowStart = 0;
        var windowEnd = 0;
        var minimumLength = int.MaxValue;
        var currentSum = 0;
        var currentLength = 0;

        while (windowEnd <= numbers.Length)
        {
            if (currentSum < target)
            {
                windowEnd++;
                if (windowEnd > numbers.Length)
                {
                    break;
                }
                else
                {
                    currentSum += numbers[windowEnd - 1];
                    currentLength++;
                }
            }
            else
            {
                minimumLength = Math.Min(currentLength, minimumLength);
                windowStart++;
                currentSum -= numbers[windowStart - 1];
                currentLength--;
            }
        }

        return minimumLength == int.MaxValue ? 0 : minimumLength;
    }
}
