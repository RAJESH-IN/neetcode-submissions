public class Solution {
    public int FindMin(int[] nums) {
        /* Beginners approach using for loop-- O(n)
        for(int i=1;i<=nums.Length-1;i++)
        {
            if(nums[i]<nums[i-1])
             return nums[i];
        }

        return nums[0];*/
// optimized approach using Binary search-- O(log n)
        int left = 0, right = nums.Length - 1;
        
        while (left < right) {
            int mid = left + (right - left) / 2;
            
            if (nums[mid] > nums[right])
                left = mid + 1;  // min is in right half
            else
                right = mid;     // min is in left half (including mid)
        }
        
        return nums[left];
    }
}
