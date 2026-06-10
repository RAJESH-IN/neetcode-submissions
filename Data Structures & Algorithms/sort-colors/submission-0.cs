public class Solution {
    public void SortColors(int[] nums) {
        int low = 0;
        int mid = 0;
        int high = nums.Length - 1;

        while (mid <= high) {
            if (nums[mid] == 0) {
                // Swap mid with low to move 0 to the front
                Swap(nums, low, mid);
                low++;
                mid++;
            } 
            else if (nums[mid] == 1) {
                // 1 is already in the correct relative position
                mid++;
            } 
            else if (nums[mid] == 2) {
                // Swap mid with high to move 2 to the back
                // Do not increment mid yet, as the swapped element needs validation
                Swap(nums, mid, high);
                high--;
            }
        }
    }

    private void Swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
