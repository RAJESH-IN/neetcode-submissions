public class CountSquares {

     private int[,] counts;
    private List<(int x, int y)> uniquePoints;

    public CountSquares() {
        counts = new int[1001, 1001];
        uniquePoints = new List<(int x, int y)>();
    }
    
    public void Add(int[] point) {
        int x = point[0];
        int y = point[1];
        
        if (counts[x, y] == 0) {
            uniquePoints.Add((x, y));
        }
        counts[x, y]++;
    }
    
    public int Count(int[] point) {
        int px = point[0];
        int py = point[1];
        int totalSquares = 0;
        
        foreach (var p in uniquePoints) {
            int x = p.x;
            int y = p.y;
            
            // Check if (x, y) forms a valid diagonal with (px, py)
            if (Math.Abs(px - x) == Math.Abs(py - y) && px != x) {
                // Find the remaining two corners: (px, y) and (x, py)
                int ways = counts[x, y] * counts[px, y] * counts[x, py];
                totalSquares += ways;
            }
        }
        
        return totalSquares;
        
    }
    

}
