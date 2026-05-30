public class Solution {
    public int MaxProfit(int[] prices) {
          if (prices == null || prices.Length < 2) {
            return 0;
        }

        int maxProfit = 0;

        // Add profits whenever the price goes up from the previous day
        for (int i = 1; i < prices.Length; i++) {
            if (prices[i] > prices[i - 1]) {
                maxProfit += prices[i] - prices[i - 1];
            }
        }

        return maxProfit;
    }
}