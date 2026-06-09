public class Solution {
    public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0) return 0;
        
        int islandCount = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                // Found an unvisited piece of land
                if (grid[r][c] == '1') {
                    islandCount++;
                    // Sink the island using DFS
                    DFS(grid, r, c);
                }
            }
        }
        
        return islandCount;
    }
    
    private void DFS(char[][] grid, int r, int c) {
        // Base cases: boundary checks and water/visited check
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == '0') {
            return;
        }
        
        // Mark the current cell as visited by changing it to '0'
        grid[r][c] = '0';
        
        // Explore all 4 adjacent directions
        DFS(grid, r + 1, c); // Down
        DFS(grid, r - 1, c); // Up
        DFS(grid, r, c + 1); // Right
        DFS(grid, r, c - 1); // Left
    }
}
