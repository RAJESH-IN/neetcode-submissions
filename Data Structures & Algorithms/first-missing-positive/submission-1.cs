public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;

        // Step 1: In-place cyclic sort
        for (int i = 0; i < n; i++) {
            // Correct position for value x is x - 1
            while (nums[i] > 0 && nums[i] <= n && nums[i] != nums[nums[i] - 1]) {
                // Swap nums[i] with the element at its correct position
                int temp = nums[nums[i] - 1];
                nums[nums[i] - 1] = nums[i];
                nums[i] = temp;
            }
        }

        // Step 2: Find the first out-of-place positive number
        for (int i = 0; i < n; i++) {
            if (nums[i] != i + 1) {
                return i + 1;
            }
        }

        // Step 3: If 1 to n are all present, the missing number is n + 1
        return n + 1;
    }
}