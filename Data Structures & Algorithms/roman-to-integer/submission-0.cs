public class Solution {
    public int RomanToInt(string s) {
    int total = 0;
        int n = s.Length;
        
        for (int i = 0; i < n; i++) {
            int currentVal = GetValue(s[i]);
            
            // If next value is larger, subtract current value
            if (i + 1 < n && currentVal < GetValue(s[i + 1])) {
                total -= currentVal;
            } else {
                total += currentVal;
            }
        }
        
        return total;
    }
    
    private int GetValue(char c) {
        return c switch {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => 0
        };
    }
}