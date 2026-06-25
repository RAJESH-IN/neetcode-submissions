public class Solution {
    public bool IsSubsequence(string s, string t) {
        int i = 0; // Pointer for string s
        int j = 0; // Pointer for string t
        
        while (i < s.Length && j < t.Length) {
            if (s[i] == t[j]) {
                i++; // Found a match, move s pointer
            }
            j++; // Always move t pointer
        }
        
        return i == s.Length; // True if all characters in s were matched
    }
}
