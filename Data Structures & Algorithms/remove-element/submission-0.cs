public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int[] result=new int[nums.Length];
        int left=0;
        for(int i=0;i<nums.Length;i++){
            if(nums[i]!=val)
            {
                nums[left]=nums[i];
                left++;
            }
        }
        return left; 

    }
}