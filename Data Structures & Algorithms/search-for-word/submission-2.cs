
public class Solution {
    public bool Exist(char[][] board, string word) {
        int rows = board.Length;
        int cols = board[0].Length; // Fixed: Use index 0 for column count

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                // Fixed: Check against the first character word[0]
                if (board[r][c] == word[0] && DFS(board, word, r, c, 0)) {
                    return true;
                }
            }
        }
        return false;
    }

    private bool DFS(char[][] board, string word, int r, int c, int index) {
        // Base case: successfully matched the entire word
        if (index == word.Length) {
            return true;
        }

        // Fixed: Column boundary check uses board[0].Length
        if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length || board[r][c] != word[index]) {
            return false;
        }

        // Save original value
        char temp = board[r][c];
        board[r][c] = '#'; // Fixed: Changed board[r][r] to board[r][c]

        // Explore all 4 directions
        bool found = DFS(board, word, r + 1, c, index + 1) || // Down
                     DFS(board, word, r - 1, c, index + 1) || // Up
                     DFS(board, word, r, c + 1, index + 1) || // Right
                     DFS(board, word, r, c - 1, index + 1);   // Left

        // Backtrack: restore the cell back to its original character
        board[r][c] = temp;

        return found;
    }
}
