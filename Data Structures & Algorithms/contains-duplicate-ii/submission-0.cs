public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        
        for(int i=0;i<nums.Length-1;i++)
        {
            for(int j=i+1;j<nums.Length;j++)
             {
                if(nums[i]==nums[j] && Math.Abs(i-j)<=k)
                    return true;

            }
        }
        return false;
    }
}