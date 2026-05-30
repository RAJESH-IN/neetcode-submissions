/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */

class Solution {
    public int FindInMountainArray(int target, MountainArray mountainArr) {
        int length = mountainArr.Length();
        
        // Step 1: Find the peak index
        int peak = FindPeakIndex(mountainArr, length);
        
        // Step 2: Binary search on the increasing slope (left half)
        int leftIndex = BinarySearch(mountainArr, target, 0, peak, true);
        if (leftIndex != -1) {
            return leftIndex;
        }
        
        // Step 3: Binary search on the decreasing slope (right half)
        return BinarySearch(mountainArr, target, peak + 1, length - 1, false);
    }
    
    private int FindPeakIndex(MountainArray mountainArr, int length) {
        int low = 0;
        int high = length - 1;
        
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (mountainArr.Get(mid) < mountainArr.Get(mid + 1)) {
                low = mid + 1; // Peak must be to the right
            } else {
                high = mid;    // Peak could be mid or to the left
            }
        }
        return low;
    }
    
    private int BinarySearch(MountainArray mountainArr, int target, int low, int high, bool isAscending) {
        while (low <= high) {
            int mid = low + (high - low) / 2;
            int midVal = mountainArr.Get(mid);
            
            if (midVal == target) {
                return mid;
            }
            
            if (isAscending) {
                if (midVal < target) low = mid + 1;
                else high = mid - 1;
            } else {
                if (midVal > target) low = mid + 1; // Flipped comparison logic for descending slope
                else high = mid - 1;
            }
        }
        return -1;
    }
}