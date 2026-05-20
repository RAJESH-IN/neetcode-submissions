public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length == 0) return 0;
        
        int minPrice = int.MaxValue;
        int maxProfit = 0;
        
        foreach (int price in prices) 
        {
            if (price < minPrice) 
            {
                minPrice = price; // Update the lowest buy price seen so far
            } 
            else if (price - minPrice > maxProfit) 
            {
                maxProfit = price - minPrice; // Check if selling here beats current max profit
            }
        }
        
        return maxProfit;
    }
}
