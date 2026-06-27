
public class Solution {
    public List<List<int>> PacificAtlantic(int[][] heights) {
        List<List<int>> result = new List<List<int>>();
        if (heights == null || heights.Length == 0 || heights[0].Length == 0) {
            return result;
        }

        int rows = heights.Length;
        int cols = heights[0].Length;

        bool[,] pacificReachable = new bool[rows, cols];
        bool[,] atlanticReachable = new bool[rows, cols];

        // Step 1: Start DFS from the top and bottom borders
        for (int c = 0; c < cols; c++) {
            Dfs(heights, 0, c, pacificReachable, heights[0][c]);
            Dfs(heights, rows - 1, c, atlanticReachable, heights[rows - 1][c]);
        }

        // Step 2: Start DFS from the left and right borders
        for (int r = 0; r < rows; r++) {
            Dfs(heights, r, 0, pacificReachable, heights[r][0]);
            Dfs(heights, r, cols - 1, atlanticReachable, heights[r][cols - 1]);
        }

        // Step 3: Identify cells that can reach both oceans
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (pacificReachable[r, c] && atlanticReachable[r, c]) {
                    result.Add(new List<int> { r, c });
                }
            }
        }

        return result;
    }

    private void Dfs(int[][] heights, int r, int c, bool[,] reachable, int prevHeight) {
        int rows = heights.Length;
        int cols = heights[0].Length;

        // Base cases: Out of bounds, already visited, or height decreases
        if (r < 0 || r >= rows || c < 0 || c >= cols || reachable[r, c] || heights[r][c] < prevHeight) {
            return;
        }

        reachable[r, c] = true;

        // Traverse in all 4 cardinal directions
        Dfs(heights, r + 1, c, reachable, heights[r][c]);
        Dfs(heights, r - 1, c, reachable, heights[r][c]);
        Dfs(heights, r, c + 1, reachable, heights[r][c]);
        Dfs(heights, r, c - 1, reachable, heights[r][c]);
    }
}
