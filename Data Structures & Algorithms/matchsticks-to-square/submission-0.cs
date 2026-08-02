public class Solution {
    public bool Makesquare(int[] matchsticks) {
        int total = matchsticks.Sum();
        if (total % 4 != 0) return false;
        
        int target = total / 4;
        
        // Sort ascending, then process from largest to smallest to prune early
        Array.Sort(matchsticks);
        
        return Backtrack(matchsticks, matchsticks.Length - 1, new int[4], target);
    }

    private bool Backtrack(int[] sticks, int index, int[] sides, int target) {
        // All sticks used successfully
        if (index < 0) return true; 

        for (int i = 0; i < 4; i++) {
            // Check if stick fits in the current side
            if (sides[i] + sticks[index] <= target) {
                sides[i] += sticks[index];
                
                if (Backtrack(sticks, index - 1, sides, target)) return true;
                
                sides[i] -= sticks[index]; // Revert change
            }
            
            // Skip duplicate branches
            if (sides[i] == 0) break; 
        }
        return false;
    }
}
