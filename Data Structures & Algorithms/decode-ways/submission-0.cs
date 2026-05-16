public class Solution {
    public int NumDecodings(string s) {
         if (string.IsNullOrEmpty(s) || s[0] == '0') return 0;

        int n = s.Length;
        int prev2 = 1; // DP[i-2]
        int prev1 = 1; // DP[i-1]

        for (int i = 1; i < n; i++) {
            int current = 0;

            // Single digit check (1-9)
            if (s[i] != '0') {
                current += prev1;
            }

            // Two digit check (10-26)
            int twoDigit = int.Parse(s.Substring(i - 1, 2));
            if (twoDigit >= 10 && twoDigit <= 26) {
                current += prev2;
            }

            if (current == 0) return 0; // Optimization: cannot decode further

            prev2 = prev1;
            prev1 = current;
        }

        return prev1;
    }
}
