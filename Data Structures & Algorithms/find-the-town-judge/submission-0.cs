public class Solution {
    public int FindJudge(int n, int[][] trust) {
        // Array to store trust scores (1-indexed)
        int[] trustScores = new int[n + 1];
        
        // Calculate net trust scores
        foreach (var t in trust) {
            int personA = t[0];
            int personB = t[1];
            
            trustScores[personA]--; // A trusts someone
            trustScores[personB]++; // B is trusted by someone
        }
        
        // Find the person with a score of n - 1
        for (int i = 1; i <= n; i++) {
            if (trustScores[i] == n - 1) {
                return i;
            }
        }
        
        return -1;
    }
}
