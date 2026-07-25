public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        if (grid == null || grid.Length == 0) return 0;
        
        int maxArea = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;

        // Traverse every cell in the grid matrix
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                // If land is found, trigger a DFS to measure its full size
                if (grid[r][c] == 1) {
                    maxArea = Math.Max(maxArea, ExploreIsland(grid, r, c));
                }
            }
        }

        return maxArea;
    }

    private int ExploreIsland(int[][] grid, int r, int c) {
        // Base case: check boundary limits and if the cell is water (0)
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == 0) {
            return 0;
        }

        // Mark the current land cell as visited by turning it into water (0)
        grid[r][c] = 0;

        // Accumulate area from all 4 cardinal directions (up, down, left, right)
        int area = 1;
        area += ExploreIsland(grid, r + 1, c);
        area += ExploreIsland(grid, r - 1, c);
        area += ExploreIsland(grid, r, c + 1);
        area += ExploreIsland(grid, r, c - 1);

        return area;
    }
}
