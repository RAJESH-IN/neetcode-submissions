
public class Solution {
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        List<List<int>> result = new List<List<int>>();
        // 1. Sort to handle duplicates easily
        Array.Sort(candidates); 
        
        Backtrack(candidates, target, 0, new List<int>(), result);
        return result;
    }

    private void Backtrack(int[] candidates, int target, int start, List<int> current, List<List<int>> result) {
        // Base case: target met
        if (target == 0) {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = start; i < candidates.Length; i++) {
            // 2. Skip identical elements to avoid duplicate combinations
            if (i > start && candidates[i] == candidates[i - 1]) {
                continue;
            }

            // 3. Early exit optimization if number exceeds remaining target
            if (candidates[i] > target) {
                break;
            }

            // Make choice
            current.Add(candidates[i]);
            
            // Move to next element (i + 1 ensures each element is used once)
            Backtrack(candidates, target - candidates[i], i + 1, current, result);
            
            // Undo choice (backtrack)
            current.RemoveAt(current.Count - 1);
        }
    }
}
