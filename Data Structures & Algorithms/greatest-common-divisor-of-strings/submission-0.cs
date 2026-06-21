public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        // Check if the strings have a valid common divisor string arrangement
        if (str1 + str2 != str2 + str1) {
            return "";
        }
        
        // Find the math GCD of lengths
        int gcdLength = Gcd(str1.Length, str2.Length);
        
        // The common prefix of that length is the answer
        return str1.Substring(0, gcdLength);
    }
    
    // Helper method using Euclidean algorithm to find GCD of numbers
    private int Gcd(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
