public class Solution {
    public List<List<int>> FourSum(int[] nums, int target) {
         var result = new List<List<int>>();
        
        // Sort the array to easily handle duplicates and use two pointers
        Array.Sort(nums);
        int n = nums.Length;

        for (int i = 0; i < n - 3; i++) {
            // Skip duplicate values for the first element
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            for (int j = i + 1; j < n - 2; j++) {
                // Skip duplicate values for the second element
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                int left = j + 1;
                int right = n - 1;

                while (left < right) {
                    // Use long to prevent integer overflow during addition
                    long sum = (long)nums[i] + nums[j] + nums[left] + nums[right];

                    if (sum == target) {
                        result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });

                        // Skip duplicate values for the third element
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        // Skip duplicate values for the fourth element
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                    } 
                    else if (sum < target) {
                        left++;
                    } 
                    else {
                        right--;
                    }
                }
            }
        }

        return result;
    }
}