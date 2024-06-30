namespace LeetcodePractice.Implementation.Interview150;
public class _3Sum
{
    public IList<IList<int>> Calculate0SumTriplets(int[] nums)
    {
        var triplets = new List<IList<int>>();
        nums = nums.OrderBy(n => n).ToArray();
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            var j = i + 1;
            var k = nums.Length - 1;
            var target = -nums[i];
            while (j < k)
            {
                if (j > i + 1 && nums[j] == nums[j-1])
                {
                    j++;
                    continue;
                }
                if (k < nums.Length - 2 && nums[k] == nums[k + 1])
                {
                    k--;
                    continue;
                }

                var sum = nums[j] + nums[k];
                if (sum < target)
                {
                    j++;
                }
                else if (sum > target)
                {
                    k--;
                }
                else
                {
                    triplets.Add([nums[i], nums[j], nums[k]]);
                    j++;
                    k--;
                }
            }
        }
        return triplets;
    }
}
