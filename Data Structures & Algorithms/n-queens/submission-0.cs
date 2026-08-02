public class Solution {
    private List<List<string>> result = new List<List<string>>();
    private HashSet<int> cols = new HashSet<int>();
    private HashSet<int> posDiag = new HashSet<int>(); // (r + c)
    private HashSet<int> negDiag = new HashSet<int>(); // (r - c)

    public List<List<string>> SolveNQueens(int n) {
        // Initialize an empty chessboard filled with '.'
        char[][] board = new char[n][];
        for (int i = 0; i < n; i++) {
            board[i] = new string('.', n).ToCharArray();
        }

        Backtrack(0, n, board);
        return result;
    }

    private void Backtrack(int r, int n, char[][] board) {
        // Base Case: All queens are placed successfully
        if (r == n) {
            List<string> copy = new List<string>();
            foreach (var row in board) {
                copy.Add(new string(row));
            }
            result.Add(copy);
            return;
        }

        // Try placing a queen in each column of the current row
        for (int c = 0; c < n; c++) {
            if (cols.Contains(c) || posDiag.Contains(r + c) || negDiag.Contains(r - c)) {
                continue; // Under attack, skip this cell
            }

            // Place the queen
            cols.Add(c);
            posDiag.Add(r + c);
            negDiag.Add(r - c);
            board[r][c] = 'Q';

            // Recurse to place the queen in the next row
            Backtrack(r + 1, n, board);

            // Backtrack (revert choices)
            cols.Remove(c);
            posDiag.Remove(r + c);
            negDiag.Remove(r - c);
            board[r][c] = '.';
        }
    }
}
