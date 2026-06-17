public class Solution {

    // Encodes a list of strings to a single string.
    public string Encode(IList<string> strs) {
        if (strs == null || strs.Count == 0) return "";
        
        StringBuilder sb = new StringBuilder();
        foreach (string s in strs) {
            sb.Append(s.Length).Append('#').Append(s);
        }
        return sb.ToString();
    }

    // Decodes a single string back to a list of strings.
    public List<string> Decode(string s) {
        List<string> result = new List<string>();
        if (string.IsNullOrEmpty(s)) return result;
        
        int i = 0;
        while (i < s.Length) {
            // Find the delimiter '#'
            int j = i;
            while (s[j] != '#') {
                j++;
            }
            
            // Parse the length of the upcoming string
            int length = int.Parse(s.Substring(i, j - i));
            
            // Extract the original string using the length
            string str = s.Substring(j + 1, length);
            result.Add(str);
            
            // Move the pointer to the start of the next block
            i = j + 1 + length;
        }
        
        return result;
    }
}
