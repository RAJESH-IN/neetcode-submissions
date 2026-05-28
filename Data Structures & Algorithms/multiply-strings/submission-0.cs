public class Solution {
    public string Multiply(string num1, string num2) {
       if (num1 == "0" || num2 == "0") return "0";
        
        int m = num1.Length;
        int n = num2.Length;
        int[] result = new int[m + n];
        
        // Multiply from right to left
        for (int i = m - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                int mul = (num1[i] - '0') * (num2[j] - '0');
                int p1 = i + j;
                int p2 = i + j + 1;
                
                int sum = mul + result[p2];
                
                result[p1] += sum / 10;
                result[p2] = sum % 10;
            }
        }
        
        // Build the final string representation
        StringBuilder sb = new StringBuilder();
        foreach (int p in result) {
            if (!(sb.Length == 0 && p == 0)) {
                sb.Append(p);
            }
        }
        
        return sb.ToString();  
    }
}
