public class Solution {
    public int MinExtraChar(string s, string[] dictionary) {
        int n = s.Length;
        // Store dictionary in a HashSet for O(1) lookups
        HashSet<string> wordSet = new HashSet<string>(dictionary);
        
        // dp[i] represents the min extra chars for substring s[i...]
        int[] dp = new int[n + 1];
        
        // Base case: no extra characters for an empty suffix
        dp[n] = 0;

        // Iterate backwards through the string
        for (int i = n - 1; i >= 0; i--) {
            // Default option: treat s[i] as an extra character
            dp[i] = dp[i + 1] + 1;

            // Try to match any substring starting at i with dictionary words
            for (int len = 1; i + len <= n; len++) {
                string sub = s.Substring(i, len);
                if (wordSet.Contains(sub)) {
                    dp[i] = Math.Min(dp[i], dp[i + len]);
                }
            }
        }

        return dp[0];
    }
}
