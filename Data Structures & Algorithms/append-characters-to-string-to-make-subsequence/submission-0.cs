public class Solution {
    public int AppendCharacters(string s, string t) {
        int i = 0; // Pointer for string s
        int j = 0; // Pointer for string t
        
        while (i < s.Length && j < t.Length) {
            if (s[i] == t[j]) {
                j++; // Found match, advance t pointer
            }
            i++; // Always advance s pointer
        }
        
        return t.Length - j; // Remaining unmatched characters in t
    }
}
