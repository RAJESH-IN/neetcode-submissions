public class Solution {
    public int[] SortArray(int[] nums) {
        int n = nums.Length;

        // Step 1: Build a max heap
        for (int i = n / 2 - 1; i >= 0; i--) {
            Heapify(nums, n, i);
        }

        // Step 2: Extract elements from the heap one by one
        for (int i = n - 1; i > 0; i--) {
            // Move current root to the end
            int temp = nums[0];
            nums[0] = nums[i];
            nums[i] = temp;

            // Call max heapify on the reduced heap
            Heapify(nums, i, 0);
        }

        return nums;
    }

    private void Heapify(int[] nums, int n, int i) {
        int largest = i; // Initialize largest as root
        int left = 2 * i + 1; // Left child
        int right = 2 * i + 2; // Right child

        // If left child is larger than root
        if (left < n && nums[left] > nums[largest]) {
            largest = left;
        }

        // If right child is larger than the largest so far
        if (right < n && nums[right] > nums[largest]) {
            largest = right;
        }

        // If largest is not root, swap and continue heapifying
        if (largest != i) {
            int swap = nums[i];
            nums[i] = nums[largest];
            nums[largest] = swap;

            // Recursively heapify the affected sub-tree
            Heapify(nums, n, largest);
        }
    }
}
