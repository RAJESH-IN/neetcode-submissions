public class Solution {
    public string LongestDiverseString(int a, int b, int c) {
        StringBuilder sb = new StringBuilder();
        
        // Custom struct/class to hold character count information
        var chars = new List<(char ch, int count)> {
            ('a', a),
            ('b', b),
            ('c', c)
        };

        while (true) {
            // Sort by count descending so the most frequent character is always at index 0
            chars.Sort((x, y) => y.count.CompareTo(x.count));

            bool added = false;

            for (int i = 0; i < 3; i++) {
                if (chars[i].count == 0) break; // If current max is 0, no more characters can be added

                int n = sb.Length;
                // Check if adding this character would create 3-in-a-row (e.g., "aaa")
                if (n >= 2 && sb[n - 1] == chars[i].ch && sb[n - 2] == chars[i].ch) {
                    continue; // Skip and try the next most frequent character
                }

                // Safe to append
                sb.Append(chars[i].ch);
                chars[i] = (chars[i].ch, chars[i].count - 1);
                added = true;
                break; // Break out of inner loop to re-sort and re-evaluate frequencies
            }

            // If we went through all available characters and couldn't add any, we are stuck
            if (!added) break;
        }

        return sb.ToString();
    }
}
