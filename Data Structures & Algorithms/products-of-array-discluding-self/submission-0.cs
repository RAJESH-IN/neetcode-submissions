public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] result = new int[n];
        
        // Step 1: Calculate prefix products
        // result[i] will store the product of all elements to the left of i
        result[0] = 1;
        for (int i = 1; i < n; i++) {
            result[i] = result[i - 1] * nums[i - 1];
        }
        
        // Step 2: Calculate suffix products on the fly
        // Multiply the prefix product with the running product of elements to the right
        int suffixProduct = 1;
        for (int i = n - 1; i >= 0; i--) {
            result[i] *= suffixProduct;
            suffixProduct *= nums[i];
        }
        
        return result;
    }
}
