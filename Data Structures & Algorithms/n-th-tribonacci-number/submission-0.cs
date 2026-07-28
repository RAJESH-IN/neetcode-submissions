public class Solution {
    public int Tribonacci(int n) {
        // Handle base cases directly
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;
        
        // Initialize the first three Tribonacci numbers
        int t0 = 0, t1 = 1, t2 = 1;
        
        // Iteratively compute up to n
        for (int i = 3; i <= n; i++) {
            int next = t0 + t1 + t2;
            t0 = t1;
            t1 = t2;
            t2 = next;
        }
        
        return t2;
    }
}
