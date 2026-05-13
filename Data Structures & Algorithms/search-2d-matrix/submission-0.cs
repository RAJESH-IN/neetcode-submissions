public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
         if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) {
            return false;
        }

        int rows = matrix.Length;
        int cols = matrix[0].Length;

        // Start from the top-right corner
        int row = 0;
        int col = cols - 1;

        while (row < rows && col >= 0) {
            if (matrix[row][col] == target) {
                return true; // Target found
            } else if (matrix[row][col] > target) {
                col--; // Current value too large, move left to smaller values
            } else {
                row++; // Current value too small, move down to larger values
            }
        }

        return false; // Target not found after exhausting search space
    
    }
}
