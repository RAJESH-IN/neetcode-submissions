public class Solution {
    public int ClimbStairs(int n) {     
            // Base case: if there is only 1 step, there is only 1 way
        if (n <= 1) return 1;

        // We use two variables to track the number of ways to reach 
        // the previous two steps (similar to Fibonacci)
        int one = 1; // ways(n-1)
        int two = 1; // ways(n-2)

        // Iterate from 1 up to n-1
        for (int i = 0; i < n - 1; i++) {
            int temp = one;
            one = one + two;
            two = temp;
        }

        return one;
    }
}
