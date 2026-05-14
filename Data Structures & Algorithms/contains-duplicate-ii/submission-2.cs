public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
         HashSet<int> window = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // Maintain window size <= k
            if (i > k)
                window.Remove(nums[i - k - 1]);

            // Duplicate found inside window
            if (window.Contains(nums[i]))
                return true;

            window.Add(nums[i]);
        }

        return false;
    }
}