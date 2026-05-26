public class Solution {
    public int Search(int[] nums, int target) {
         int left = 0;
        int right = nums.Length - 1;

        while (left <= right) {
            // Calculates mid-point avoiding integer overflow
            int mid = left + (right - left) / 2;

            if (nums[mid] == target) {
                return mid; // Target found
            }
            else if (nums[mid] < target) {
                left = mid + 1; // Search the right half
            }
            else {
                right = mid - 1; // Search the left half
            }
        }

        return -1; // Target does not exist
    }
}
