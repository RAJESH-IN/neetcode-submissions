public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) {
            return false;
        }

        int rows = matrix.Length;
        int cols = matrix[0].Length;
        
        int low = 0;
        int high = (rows * cols) - 1;

        while (low <= high) {
            int mid = low + (high - low) / 2;
            
            // Map 1D virtual index back to 2D matrix coordinates
            int r = mid / cols;
            int c = mid % cols;
            
            int currentVal = matrix[r][c];

            if (currentVal == target) {
                return true; // Target found
            } else if (currentVal < target) {
                low = mid + 1; // Search the right half
            } else {
                high = mid - 1; // Search the left half
            }
        }

        return false;
    }
}
