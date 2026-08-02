public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        if (grid == null || grid.Length == 0) return;

        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<(int r, int c)> queue = new Queue<(int, int)>();

        // Step 1: Find all treasure chests (0) and add them to the BFS queue
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 0) {
                    queue.Enqueue((r, c));
                }
            }
        }

        // Direction arrays for traveling Up, Down, Left, and Right
        int[][] directions = new int[][] {
            new int[] {-1, 0}, new int[] {1, 0}, 
            new int[] {0, -1}, new int[] {0, 1}
        };

        // Step 2: Layer-by-layer level order traversal
        while (queue.Count > 0) {
            var (r, c) = queue.Dequeue();

            foreach (var dir in directions) {
                int nextR = r + dir[0];
                int nextC = c + dir[1];

                // Boundary check and validation that the neighbor is an unvisited land cell (INF)
                if (nextR >= 0 && nextR < rows && nextC >= 0 && nextC < cols && grid[nextR][nextC] == 2147483647) {
                    // Distance to neighbor is current distance + 1
                    grid[nextR][nextC] = grid[r][c] + 1;
                    queue.Enqueue((nextR, nextC));
                }
            }
        }
    }
}
