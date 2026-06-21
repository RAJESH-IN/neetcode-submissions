public class Solution {
    public double MyPow(double x, int n) {
        // Cast to long to safely prevent integer overflow with int.MinValue
        long N = n;
        
        // Handle negative exponent case
        if (N < 0) {
            x = 1 / x;
            N = -N;
        }
        
        double result = 1.0;
        double currentProduct = x;
        
        // Iterative binary exponentiation
        while (N > 0) {
            // If the current bit is 1, multiply the result by currentProduct
            if ((N & 1) == 1) {
                result *= currentProduct;
            }
            // Square the base for the next binary position
            currentProduct *= currentProduct;
            // Shift right to check the next bit
            N >>= 1;
        }
        
        return result;
    }
}
