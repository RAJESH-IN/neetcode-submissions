public class Solution {
    public int Trap(int[] height) {
        if (height == null || height.Length == 0) return 0;

        int left = 0;
        int right = height.Length - 1;
        
        int leftMax = 0;
        int rightMax = 0;
        int totalWater = 0;

        while (left < right) {
            if (height[left] < height[right]) {
                // Process the left pointer
                if (height[left] >= leftMax) {
                    leftMax = height[left]; // Update highest bar on left
                } else {
                    totalWater += leftMax - height[left]; // Add trapped water
                }
                left++;
            } else {
                // Process the right pointer
                if (height[right] >= rightMax) {
                    rightMax = height[right]; // Update highest bar on right
                } else {
                    totalWater += rightMax - height[right]; // Add trapped water
                }
                right--;
            }
        }

        return totalWater;
    }
}
