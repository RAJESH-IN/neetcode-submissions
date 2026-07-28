public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // Initialize prices array with infinity
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;
        
        // Relax edges at most k + 1 times (k stops means k + 1 edges max)
        for (int i = 0; i <= k; i++) {
            // Use a copy to prevent updating and using the same route within the same iteration
            int[] tempPrices = (int[])prices.Clone();
            
            foreach (var flight in flights) {
                int u = flight[0];
                int v = flight[1];
                int price = flight[2];
                
                // If the source node hasn't been reached yet, skip it
                if (prices[u] == int.MaxValue) {
                    continue;
                }
                
                // If a cheaper price to reach node v is found, update tempPrices
                if (prices[u] + price < tempPrices[v]) {
                    tempPrices[v] = prices[u] + price;
                }
            }
            // Update primary prices array for the next stop level
            prices = tempPrices;
        }
        
        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }
}
