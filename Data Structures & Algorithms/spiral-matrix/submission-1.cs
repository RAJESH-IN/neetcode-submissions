
public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {
        List<int> result = new List<int>();
        
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) {
            return result;
        }
        
        int top = 0;
        int bottom = matrix.Length - 1;
        int left = 0;
        int right = matrix[0].Length - 1; // Fixed for m x n matrices
        
        while (top <= bottom && left <= right) {
            // 1. Traverse Right
            for (int i = left; i <= right; i++) {
                result.Add(matrix[top][i]); // Fixed: Capital 'Add'
            }
            top++;
            
            // 2. Traverse Down
            for (int i = top; i <= bottom; i++) {
                result.Add(matrix[i][right]); // Fixed: Capital 'Add'
            }
            right--;
            
            // 3. Traverse Left
            if (top <= bottom) {
                for (int i = right; i >= left; i--) {
                    result.Add(matrix[bottom][i]); // Fixed: Capital 'Add'
                }
                bottom--;
            }
            
            // 4. Traverse Up
            if (left <= right) {
                for (int i = bottom; i >= top; i--) {
                    result.Add(matrix[i][left]); // Fixed: Capital 'Add'
                }
                left++;
            }
        }
        
        return result;
    }
}
