public class Solution {
    public void Solve(char[][] board) {
        if (board == null || board.Length == 0) return;
        
        int rows = board.Length;
        int cols = board[0].Length;
        
        // Step 1: Scan first and last columns for border 'O's
        for (int r = 0; r < rows; r++) {
            if (board[r][0] == 'O') BoundaryDFS(board, r, 0);
            if (board[r][cols - 1] == 'O') BoundaryDFS(board, r, cols - 1);
        }
        
        // Step 1: Scan first and last rows for border 'O's
        for (int c = 0; c < cols; c++) {
            if (board[0][c] == 'O') BoundaryDFS(board, 0, c);
            if (board[rows - 1][c] == 'O') BoundaryDFS(board, rows - 1, c);
        }
        
        // Step 3: Flip 'O' to 'X' and placeholder '*' back to 'O'
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (board[r][c] == 'O') {
                    board[r][c] = 'X'; // Captured
                } else if (board[r][c] == '*') {
                    board[r][c] = 'O'; // Safe, connected to border
                }
            }
        }
    }
    
    private void BoundaryDFS(char[][] board, int r, int c) {
        int rows = board.Length;
        int cols = board[0].Length;
        
        // Base case: check bounds and if cell is not 'O'
        if (r < 0 || r >= rows || c < 0 || c >= cols || board[r][c] != 'O') {
            return;
        }
        
        // Mark the cell with a temporary character
        board[r][c] = '*';
        
        // Traverse horizontally and vertically
        BoundaryDFS(board, r - 1, c); // Up
        BoundaryDFS(board, r + 1, c); // Down
        BoundaryDFS(board, r, c - 1); // Left
        BoundaryDFS(board, r, c + 1); // Right
    }
}
