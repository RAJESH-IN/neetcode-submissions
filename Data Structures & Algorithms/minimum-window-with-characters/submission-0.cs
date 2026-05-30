public class Solution {
    public string MinWindow(string s, string t) {
       if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length) {
            return "";
        }

        // Frequency map for target characters
        int[] mapT = new int[128];
        foreach (char c in t) {
            mapT[c]++;
        }

        // Count unique characters required
        int required = 0;
        for (int i = 0; i < 128; i++) {
            if (mapT[i] > 0) required++;
        }

        int[] mapW = new int[128];
        int have = 0, left = 0;
        int minLen = int.MaxValue;
        int minLeft = 0;

        // Expand the right boundary
        for (int right = 0; right < s.Length; right++) {
            char rChar = s[right];
            mapW[rChar]++;

            if (mapT[rChar] > 0 && mapW[rChar] == mapT[rChar]) {
                have++;
            }

            // Shrink the left boundary when valid
            while (have == required) {
                if (right - left + 1 < minLen) {
                    minLen = right - left + 1;
                    minLeft = left;
                }

                char lChar = s[left];
                mapW[lChar]--;
                if (mapT[lChar] > 0 && mapW[lChar] < mapT[lChar]) {
                    have--;
                }
                left++;
            }
        }

        return minLen == int.MaxValue ? "" : s.Substring(minLeft, minLen);  
    }
}
