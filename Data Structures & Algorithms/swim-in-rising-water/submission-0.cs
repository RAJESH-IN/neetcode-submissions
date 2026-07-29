public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        
        // PriorityQueue stores (row, col) as the element, and the grid elevation as the priority (min-heap)
        PriorityQueue<(int r, int c), int> pq = new PriorityQueue<(int r, int c), int>();
        bool[,] visited = new bool[n, n];
        
        // Start from the top-left cell
        pq.Enqueue((0, 0), grid[0][0]);
        visited[0, 0] = true;
        
        // Direction vectors for moving up, down, left, right
        int[] dRow = { -1, 1, 0, 0 };
        int[] dCol = { 0, 0, -1, 1 };
        int maxTime = 0;
        
        while (pq.Count > 0) {
            pq.TryDequeue(out var cell, out int time);
            
            // The water level needed is bounded by the highest elevation on our path
            maxTime = Math.Max(maxTime, time);
            
            // If the destination is reached, return the calculated maximum water level
            if (cell.r == n - 1 && cell.c == n - 1) {
                return maxTime;
            }
            
            // Explore all 4 adjacent neighbors
            for (int i = 0; i < 4; i++) {
                int nr = cell.r + dRow[i];
                int nc = cell.c + dCol[i];
                
                // Validate boundaries and check if already visited
                if (nr >= 0 && nr < n && nc >= 0 && nc < n && !visited[nr, nc]) {
                    visited[nr, nc] = true;
                    pq.Enqueue((nr, nc), grid[nr][nc]);
                }
            }
        }
        
        return maxTime;
    }
}
