public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var seen = new Dictionary<char, int>(); // char -> last seen index
        int maxLen = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++) {
            char c = s[right];

            // If duplicate found inside current window, shrink from left
            if (seen.ContainsKey(c) && seen[c] >= left) {
                left = seen[c] + 1;
            }

            seen[c] = right;
            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}