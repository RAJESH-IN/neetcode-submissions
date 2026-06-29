public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        // HashSet to store values within the sliding window of size k
        HashSet<int> window = new HashSet<int>();
        
        for (int i = 0; i < nums.Length; i++) {
            // Step 1: If window exceeds size k, remove the oldest element
            if (i > k) {
                window.Remove(nums[i - k - 1]);
            }
            
            // Step 2: If the value is already in the window, we found a nearby duplicate
            if (window.Contains(nums[i])) {
                return true;
            }
            
            // Step 3: Add current value to the tracking window
            window.Add(nums[i]);
        }
        
        return false;
    }
}
