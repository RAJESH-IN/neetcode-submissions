public class Solution {
    public int Search(int[] nums, int target) {
        
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Avoids overflow

            if (nums[mid] == target)
                return mid; // Found, return index

            if (nums[mid] < target)
                left = mid + 1; // Search right half
            else
                right = mid - 1; // Search left half
        }

        return -1; // Not found
    }
}
