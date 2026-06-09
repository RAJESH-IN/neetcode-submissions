public class Solution {  
    public List<string> GenerateParenthesis(int n) {
List<string> result = new List<string>();
        Backtrack(result, "", 0, 0, n);
        return result;
    }

    private void Backtrack(List<string> result, string current, int openCount, int closeCount, int maxPairs) {
        // Base case: string reaches the maximum required length
        if (current.Length == maxPairs * 2) {
            result.Add(current);
            return;
        }

        // Add an open parenthesis if we haven't used all n pairs
        if (openCount < maxPairs) {
            Backtrack(result, current + "(", openCount + 1, closeCount, maxPairs);
        }

        // Add a close parenthesis only if it safely pairs with an open one
        if (closeCount < openCount) {
            Backtrack(result, current + ")", openCount, closeCount + 1, maxPairs);
        }
    }
}
