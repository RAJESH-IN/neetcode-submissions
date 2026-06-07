public class Solution {
    public int CalPoints(string[] operations) {
         List<int> scores = new List<int>();

        foreach (string op in operations) {
            if (op == "+") {
                // Record sum of the previous two scores
                scores.Add(scores[scores.Count - 1] + scores[scores.Count - 2]);
            } 
            else if (op == "D") {
                // Record double of the previous score
                scores.Add(2 * scores[scores.Count - 1]);
            } 
            else if (op == "C") {
                // Invalidate and remove the previous score
                scores.RemoveAt(scores.Count - 1);
            } 
            else {
                // Record a new integer score
                scores.Add(int.Parse(op));
            }
        }

        // Return the sum of all scores remaining in the record
        return scores.Sum();

    }
}