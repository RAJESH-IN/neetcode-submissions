public class NumMatrix {
    private int[][] sums;

    public NumMatrix(int[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return;
        
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        
        // Create an extra row and column to handle boundary cases cleanly without if-statements
        sums = new int[rows + 1][];
        for (int i = 0; i <= rows; i++) {
            sums[i] = new int[cols + 1];
        }

        // Fill the 2D prefix sum table
        for (int r = 1; r <= rows; r++) {
            for (int c = 1; c <= cols; c++) {
                sums[r][c] = matrix[r - 1][c - 1] 
                             + sums[r - 1][c] 
                             + sums[r][c - 1] 
                             - sums[r - 1][c - 1];
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        // Apply inclusion-exclusion principle using precalculated sub-grids
        return sums[row2 + 1][col2 + 1] 
               - sums[row1][col2 + 1] 
               - sums[row2 + 1][col1] 
               + sums[row1][col1];
    }
}


/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */