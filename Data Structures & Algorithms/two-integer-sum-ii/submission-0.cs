public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int left = 0;
        int right = numbers.Length - 1;
        
        while (left < right) {
            int currentSum = numbers[left] + numbers[right];
            
            if (currentSum == target) {
                // The problem requires 1-indexed results
                return new int[] { left + 1, right + 1 };
            } 
            else if (currentSum < target) {
                // The sum is too small, move the left pointer to increase the sum
                left++;
            } 
            else {
                // The sum is too large, move the right pointer to decrease the sum
                right--;
            }
        }
        
        return new int[0]; 
    }
}
