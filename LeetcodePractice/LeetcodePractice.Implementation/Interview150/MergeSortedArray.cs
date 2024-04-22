namespace LeetcodePractice.Implementation.Interview150;

//https://leetcode.com/problems/merge-sorted-array/?envType=study-plan-v2&envId=top-interview-150
public class MergeSortedArray
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        nums1.Take(m).Concat(nums2).OrderBy(n => n).ToArray().CopyTo(nums1, 0);
    }
}
