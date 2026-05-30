public class Solution {
    public int RemoveDuplicates(int[] nums) {
       if (nums == null || nums.Length == 0) {
            return 0;
        }

        // Pointer to place the next unique element
        int insertIndex = 1;

        // Iterate through the array starting from the second element
        for (int i = 1; i < nums.Length; i++) {
            // If current element is different from the previous one, it's unique
            if (nums[i] != nums[i - 1]) {
                nums[insertIndex] = nums[i];
                insertIndex++;
            }
        }

        // insertIndex represents the count of unique elements
        return insertIndex;
     
    }
}