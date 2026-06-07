public class Solution {
    public void Rotate(int[] nums, int k) {
        if (nums == null || nums.Length <= 1) return;

        // Handle cases where k is greater than the array length
        k %= nums.Length;
        if (k == 0) return;

        // 1. Reverse the entire array
        Reverse(nums, 0, nums.Length - 1);
        
        // 2. Reverse the first k elements
        Reverse(nums, 0, k - 1);
        
        // 3. Reverse the remaining elements
        Reverse(nums, k, nums.Length - 1);
    }

    private void Reverse(int[] nums, int start, int end) {
        while (start < end) {
            int temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
    }
}