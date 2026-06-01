public class Solution {
    public int Candy(int[] ratings) {
      int n = ratings.Length;
        int[] candies = new int[n];
        
        // Requirement 1: Each child must have at least one candy
        Array.Fill(candies, 1);

        // Pass 1: Left-to-Right
        // If a child has a higher rating than their left neighbor, 
        // they must get more candies than that neighbor.
        for (int i = 1; i < n; i++) {
            if (ratings[i] > ratings[i - 1]) {
                candies[i] = candies[i - 1] + 1;
            }
        }

        // Pass 2: Right-to-Left
        // If a child has a higher rating than their right neighbor,
        // they must get more candies than that neighbor, while keeping the maximum allocation.
        for (int i = n - 2; i >= 0; i--) {
            if (ratings[i] > ratings[i + 1]) {
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
        }

        // Sum up the minimum candies required
        return candies.Sum();  
    }
}