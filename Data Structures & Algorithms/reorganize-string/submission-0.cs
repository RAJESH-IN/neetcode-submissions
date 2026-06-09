public class Solution {
    public string ReorganizeString(string s) {
        // Step 1: Count character frequencies
        int[] counts = new int[26];
        foreach (char c in s) {
            counts[c - 'a']++;
        }

        // Step 2: Find the most frequent character
        int maxCount = 0;
        char maxChar = ' ';
        for (int i = 0; i < 26; i++) {
            if (counts[i] > maxCount) {
                maxCount = counts[i];
                maxChar = (char)(i + 'a');
            }
        }

        // Step 3: Check if it's impossible to reorganize
        if (maxCount > (s.Length + 1) / 2) {
            return "";
        }

        // Step 4: Interleave characters into a result array
        char[] res = new char[s.Length];
        int index = 0;

        // Place the most frequent character at even indices first
        while (counts[maxChar - 'a'] > 0) {
            res[index] = maxChar;
            index += 2;
            counts[maxChar - 'a']--;
        }

        // Place the remaining characters
        for (int i = 0; i < 26; i++) {
            while (counts[i] > 0) {
                if (index >= res.Length) {
                    index = 1; // Switch to odd indices once evens are filled
                }
                res[index] = (char)(i + 'a');
                index += 2;
                counts[i]--;
            }
        }

        return new string(res);
    }
}
