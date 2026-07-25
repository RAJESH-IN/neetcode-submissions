public class Solution {
    public int OrangesRotting(int[][] grid) {
        if (grid == null || grid.Length == 0) return 0;
        
        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int freshCount = 0;
        
        // Step 1: Initialize the queue with all initially rotten oranges
        // and count the total number of fresh oranges.
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 2) {
                    queue.Enqueue((r, c));
                } else if (grid[r][c] == 1) {
                    freshCount++;
                }
            }
        }
        
        // If there are no fresh oranges to begin with, 0 minutes are needed.
        if (freshCount == 0) return 0;
        
        int minutes = 0;
        // Direction vectors for moving up, down, left, and right
        int[][] directions = new int[][] {
            new int[] {-1, 0}, new int[] {1, 0}, 
            new int[] {0, -1}, new int[] {0, 1}
        };
        
        // Step 2: Process the grid layer by layer (minute by minute)
        while (queue.Count > 0 && freshCount > 0) {
            int size = queue.Count;
            minutes++; // Increment time for the upcoming layer expansion
            
            for (int i = 0; i < size; i++) {
                var (r, c) = queue.Dequeue();
                
                foreach (var dir in directions) {
                    int nr = r + dir[0];
                    int nc = c + dir[1];
                    
                    // Check boundaries and if the neighboring orange is fresh
                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == 1) {
                        grid[nr][nc] = 2; // Contaminate the fresh orange
                        freshCount--;     // Decrement fresh count
                        queue.Enqueue((nr, nc)); // Add new rotten position to queue
                    }
                }
            }
        }
        
        // Step 3: If fresh oranges still remain, it's impossible to rot all of them
        return freshCount == 0 ? minutes : -1;
    }
}
