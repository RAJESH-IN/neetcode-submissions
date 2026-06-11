public class Solution {
    public int CharacterReplacement(string s, int k) {
        int[] counts = new int[26];
        int maxCount = 0;
        int maxLength = 0;
        int l = 0;
        
        for (int r = 0; r < s.Length; r++) {
            // Add the current character to the frequency map
            counts[s[r] - 'A']++;
            
            // Update the maximum frequency of a single character in the current window
            maxCount = Math.Max(maxCount, counts[s[r] - 'A']);
            
            // Current window size is (r - l + 1)
            // If characters to replace exceed k, shrink the window from the left
            while ((r - l + 1) - maxCount > k) {
                counts[s[l] - 'A']--;
                l++;
            }
            
            // Update the maximum valid window length found so far
            maxLength = Math.Max(maxLength, r - l + 1);
        }
        
        return maxLength;
    }
}
