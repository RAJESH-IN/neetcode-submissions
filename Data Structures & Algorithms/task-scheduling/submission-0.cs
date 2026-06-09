
public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        // Step 1: Count frequencies of each task
        int[] frequencies = new int[26];
        foreach (char task in tasks) {
            frequencies[task - 'A']++;
        }

        // Step 2: Find the maximum frequency
        int maxFreq = 0;
        foreach (int freq in frequencies) {
            maxFreq = Math.Max(maxFreq, freq);
        }

        // Step 3: Count how many tasks share this maximum frequency
        int maxFreqCount = 0;
        foreach (int freq in frequencies) {
            if (freq == maxFreq) {
                maxFreqCount++;
            }
        }

        // Step 4: Calculate minimum intervals using the formula
        int formulaResult = (maxFreq - 1) * (n + 1) + maxFreqCount;

        // Step 5: The answer cannot be less than the total number of tasks
        return Math.Max(tasks.Length, formulaResult);
    }
}
