public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int n1 = s1.Length;
        int n2 = s2.Length;

        // Base case: if s1 is longer than s2, s2 cannot contain its permutation
        if (n1 > n2) {
            return false;
        }

        // Frequency arrays for lowercase English letters
        int[] s1Counts = new int[26];
        int[] s2Counts = new int[26];

        // Initialize frequencies for the first window of size n1
        for (int i = 0; i < n1; i++) {
            s1Counts[s1[i] - 'a']++;
            s2Counts[s2[i] - 'a']++;
        }

        // Count how many character frequencies match initially
        int matches = 0;
        for (int i = 0; i < 26; i++) {
            if (s1Counts[i] == s2Counts[i]) {
                matches++;
            }
        }

        // Slide the window across s2
        for (int i = n1; i < n2; i++) {
            if (matches == 26) {
                return true;
            }

            // Character entering the window on the right
            int rightIndex = s2[i] - 'a';
            s2Counts[rightIndex]++;
            if (s2Counts[rightIndex] == s1Counts[rightIndex]) {
                matches++;
            } else if (s2Counts[rightIndex] == s1Counts[rightIndex] + 1) {
                matches--;
            }

            // Character leaving the window on the left
            int leftIndex = s2[i - n1] - 'a';
            s2Counts[leftIndex]--;
            if (s2Counts[leftIndex] == s1Counts[leftIndex]) {
                matches++;
            } else if (s2Counts[leftIndex] == s1Counts[leftIndex] - 1) {
                matches--;
            }
        }

        return matches == 26;
    }
}
