namespace LeetcodePractice.Implementation.Interview150;

//https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/?envType=study-plan-v2&envId=top-interview-150
public class RemoveDuplicatesFromSortedArrayII
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length <= 1)
        {
            return nums.Length;
        }

        int sameCounter = 0;
        int compareIndex = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[compareIndex])
            {
                nums[compareIndex + 1] = nums[i];
                sameCounter++;
            }
            else
            {
                if (sameCounter >= 2)
                {
                    nums[compareIndex + 2] = nums[i];
                    compareIndex = compareIndex + 2;
                }
                else
                {
                    nums[compareIndex + sameCounter + 1] = nums[i];
                    compareIndex = compareIndex + sameCounter + 1;
                }
                sameCounter = 0;
            }
        }
        if (sameCounter >= 1)
        {
            nums[compareIndex + 1] = nums[compareIndex];
            compareIndex++;
        }
        return compareIndex + 1;
    }
}
