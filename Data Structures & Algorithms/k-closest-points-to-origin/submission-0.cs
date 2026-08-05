public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        // Sort the array using a custom comparison based on squared distance: x^2 + y^2
        System.Array.Sort(points, (a, b) => {
            int distA = a[0] * a[0] + a[1] * a[1];
            int distB = b[0] * b[0] + b[1] * b[1];
            return distA.CompareTo(distB);
        });
        
        // Take the first k points from the sorted array
        int[][] result = new int[k][];
        System.Array.Copy(points, result, k);
        
        return result;
    }
}
