public class Solution {
    public int FindMin(int[] nums) {
        for(int i=1;i<=nums.Length-1;i++)
        {
            if(nums[i]<nums[i-1])
             return nums[i];
        }

        return nums[0];
    }
}
