public class Solution {
    public bool IsValidSudoku(char[][] board) {
        // Track seen numbers for rows, columns, and 3x3 sub-boxes
        bool[,] rows = new bool[9, 9];
        bool[,] cols = new bool[9, 9];
        bool[,] boxes = new bool[9, 9];
     
        for (int r = 0; r < 9; r++) {
            for (int c = 0; c < 9; c++) {
                char current = board[r][c];

                // Skip empty cells
                if (current == '.') {
                    continue;
                }

                // Convert char digit ('1'-'9') to a 0-indexed integer (0-8)
                int num = current - '1';
                int boxIndex = (r / 3) * 3 + (c / 3);

                // Check for duplicates in current row, column, or box
                if (rows[r, num] || cols[c, num] || boxes[boxIndex, num]) {
                    return false;
                }

                // Mark the number as seen
                rows[r, num] = true;
                cols[c, num] = true;
                boxes[boxIndex, num] = true;
            }
        }

        return true;
    }
}
