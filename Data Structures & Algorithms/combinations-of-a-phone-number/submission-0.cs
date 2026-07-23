public class Solution {
    private readonly string[] phoneMap = {
        "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"
    };

    public List<string> LetterCombinations(string digits) {
        List<string> result = new List<string>();
        
        if (string.IsNullOrEmpty(digits)) {
            return result;
        }
        
        Backtrack(digits, 0, new StringBuilder(), result);
        return result;
    }

    private void Backtrack(string digits, int index, StringBuilder current, List<string> result) {
        if (index == digits.Length) {
            result.Add(current.ToString());
            return;
        }

        string letters = phoneMap[digits[index] - '0'];
        foreach (char letter in letters) {
            current.Append(letter);
            Backtrack(digits, index + 1, current, result);
            current.Remove(current.Length - 1, 1); // Backtrack
        }
    }
}
