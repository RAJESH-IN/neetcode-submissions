
public class Solution {
    public int CoinChange(int[] coins, int amount) {
        // Create a DP array of size amount + 1
        int[] dp = new int[amount + 1];
        
        // Fill the array with a placeholder value (amount + 1) representing infinity
        Array.Fill(dp, amount + 1);
        
        // Base case: 0 coins are needed to make an amount of 0
        dp[0] = 0;
        
        // Iterate through all amounts from 1 to the target amount
        for (int i = 1; i <= amount; i++) {
            // Check each coin denomination
            foreach (int coin in coins) {
                if (i - coin >= 0) {
                    // Update the minimum coins needed for amount i
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }
        
        // If dp[amount] is still greater than amount, it's impossible to form
        return dp[amount] > amount ? -1 : dp[amount];
    }
}
