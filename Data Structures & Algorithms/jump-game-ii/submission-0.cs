public class Solution {
    public int Jump(int[] nums) {
        // Edge case: if array has 1 or fewer elements, 0 jumps are needed
        if (nums.Length <= 1) return 0;

        int jumps = 0;
        int currentJumpEnd = 0;
        int farthest = 0;

        // Iterate up to the second to last element
        for (int i = 0; i < nums.Length - 1; i++) {
            // Update the farthest index we can reach from the current position
            farthest = Math.Max(farthest, i + nums[i]);

            // If we have reached the end of the current jump's range
            if (i == currentJumpEnd) {
                jumps++;
                currentJumpEnd = farthest;

                // If the current jump can already reach or exceed the last index
                if (currentJumpEnd >= nums.Length - 1) {
                    break;
                }
            }
        }

        return jumps;
    }
}
