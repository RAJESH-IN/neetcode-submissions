public class Solution {
    public int FindDuplicate(int[] nums) {
        // Step 1: Detect the cycle using slow and fast pointers
        int tortoise = nums[0];
        int hare = nums[0];

        do {
            tortoise = nums[tortoise];       // Moves 1 step
            hare = nums[nums[hare]];         // Moves 2 steps
        } while (tortoise != hare);

        // Step 2: Find the entrance to the cycle (the duplicate number)
        int pointer1 = nums[0];
        int pointer2 = tortoise;

        while (pointer1 != pointer2) {
            pointer1 = nums[pointer1];       // Moves 1 step
            pointer2 = nums[pointer2];       // Moves 1 step
        }

        return pointer1;
    }
}
