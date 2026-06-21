public class Solution {
    public int[][] Transpose(int[][] matrix) {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        
        // Initialize the new matrix with swapped dimensions (cols x rows)
        int[][] result = new int[cols][];
        for (int c = 0; c < cols; c++) {
            result[c] = new int[rows];
        }
        
        // Transpose values
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                result[c][r] = matrix[r][c];
            }
        }
        
        return result;
    }
}
