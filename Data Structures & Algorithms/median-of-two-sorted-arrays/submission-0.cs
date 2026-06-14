public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        // Ensure nums1 is the smaller array to guarantee O(log(min(m, n)))
        if (nums1.Length > nums2.Length) {
            return FindMedianSortedArrays(nums2, nums1);
        }
        
        int m = nums1.Length;
        int n = nums2.Length;
        int low = 0;
        int high = m;
        
        while (low <= high) {
            int partitionA = low + (high - low) / 2;
            int partitionB = (m + n + 1) / 2 - partitionA;
            
            // Handle edge cases where partitions have no elements on a side
            int maxLeftA = (partitionA == 0) ? int.MinValue : nums1[partitionA - 1];
            int minRightA = (partitionA == m) ? int.MaxValue : nums1[partitionA];
            
            int maxLeftB = (partitionB == 0) ? int.MinValue : nums2[partitionB - 1];
            int minRightB = (partitionB == n) ? int.MaxValue : nums2[partitionB];
            
            // Check if the current partitions match the sorting criterion
            if (maxLeftA <= minRightB && maxLeftB <= minRightA) {
                // If total number of elements is odd
                if ((m + n) % 2 != 0) {
                    return Math.Max(maxLeftA, maxLeftB);
                }
                // If total number of elements is even
                return (Math.Max(maxLeftA, maxLeftB) + Math.Min(minRightA, minRightB)) / 2.0;
            }
            else if (maxLeftA > minRightB) {
                high = partitionA - 1; // Move left in nums1
            }
            else {
                low = partitionA + 1;  // Move right in nums1
            }
        }
        
        return 0.0;
    }
}
