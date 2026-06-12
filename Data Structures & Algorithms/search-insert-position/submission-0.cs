public class Solution {
    public int SearchInsert(int[] nums, int target) {
         int left = 0;
        int right = nums.Length - 1;

        while (left <= right) {
            // Avoid potential integer overflow
            int mid = left + (right - left) / 2;

            if (nums[mid] == target) {
                return mid; // Target found
            }
            else if (nums[mid] < target) {
                left = mid + 1; // Target is in the right half
            }
            else {
                right = mid - 1; // Target is in the left half
            }
        }

        // When left > right, left is exactly the insertion point
        return left; 
    }
}