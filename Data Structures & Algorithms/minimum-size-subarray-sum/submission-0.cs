public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int left = 0;
        int currentSum = 0;
        int minLen = int.MaxValue;

        for (int right = 0; right < nums.Length; right++)
        {
            currentSum += nums[right];           // expand window

            while (currentSum >= target)         // valid — try to shrink
            {
                minLen = Math.Min(minLen, right - left + 1);
                currentSum -= nums[left];
                left++;
            }
        }

        return minLen == int.MaxValue ? 0 : minLen;
    }
}