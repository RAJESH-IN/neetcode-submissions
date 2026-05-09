public class Solution {
    public int[] GetConcatenation(int[] nums) {
        int [] ans= new int [nums.Length+nums.Length];
        int left=0;
        int i=0;
        while (left < ans.Length)
        {
            ans[left]=nums[i];

            if(i<nums.Length-1)
            {
                i++;
            }
            else
            {
                i=0;
            }
            left++;
        }
        return ans;
    }
}