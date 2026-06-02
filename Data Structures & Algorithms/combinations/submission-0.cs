public class Solution {
    public List<List<int>> Combine(int n, int k) {
         List<List<int>> result = new List<List<int>>();
        List<int> currentCombination = new List<int>();
        
        // Start backtracking from number 1
        Backtrack(1, n, k, currentCombination, result);
        
        return result;
    }
     private void Backtrack(int start, int n, int k, List<int> current, List<List<int>> result) {
        // Base Case: If the combination has reached the target size k, save a copy
        if (current.Count == k) {
            result.Add(new List<int>(current));
            return;
        }

        // Optimization (Pruning): Ensure there are enough remaining elements to make a combination of size k
        // i <= n - (k - current.Count) + 1
        for (int i = start; i <= n - (k - current.Count) + 1; i++) {
            // Take the current element
            current.Add(i);
            
            // Move to the next element recursively
            Backtrack(i + 1, n, k, current, result);
            
            // Backtrack: Remove the element to try other paths
            current.RemoveAt(current.Count - 1);
        }
     }
     }
