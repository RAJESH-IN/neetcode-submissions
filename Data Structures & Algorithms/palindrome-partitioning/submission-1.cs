public class Solution {
    public List<List<string>> Partition(string s) {
        List<List<string>> result = new List<List<string>>();
        Backtrack(s, 0, new List<string>(), result);
        return result;
    }

    private void Backtrack(string s, int start, List<string> current, List<List<string>> result) {
        // Base case: successfully partitioned the entire string
        if (start == s.Length) {
            result.Add(new List<string>(current));
            return;
        }

        for (int end = start; end < s.Length; end++) {
            // Check if the current substring substring(start, end) is a palindrome
            if (IsPalindrome(s, start, end)) {
                // Make choice
                int length = end - start + 1;
                current.Add(s.Substring(start, length));

                // Move to next partition step
                Backtrack(s, end + 1, current, result);

                // Undo choice (backtrack)
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    private bool IsPalindrome(string s, int left, int right) {
        while (left < right) {
            if (s[left] != s[right]) {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}
