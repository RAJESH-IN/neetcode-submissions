public class Solution {
    public int GetSum(int a, int b) {
            while (b != 0) {
            // 1. Calculate carry: bits that are 1 in both a and b
            int carry = (a & b) << 1;
            
            // 2. XOR gives the sum of bits where at least one is not 1 (sum without carry)
            a = a ^ b;
            
            // 3. Set b to the carry so it can be added to the new 'a' in the next loop
            b = carry;
        }
        return a;
    }
}
