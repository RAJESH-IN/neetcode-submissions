public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
         int n = cost.Length;
        // Two variables to store the min cost to reach the previous two steps
        int prev2 = 0; // Represents cost to reach step i-2
        int prev1 = 0; // Represents cost to reach step i-1

        for (int i = 2; i <= n; i++) {
            // The cost to reach current step 'i' is the min of:
            // 1. Coming from i-1 and paying cost[i-1]
            // 2. Coming from i-2 and paying cost[i-2]
            int current = Math.Min(prev1 + cost[i - 1], prev2 + cost[i - 2]);
            
            // Move pointers forward
            prev2 = prev1;
            prev1 = current;
        }

        return prev1;
    }
}
