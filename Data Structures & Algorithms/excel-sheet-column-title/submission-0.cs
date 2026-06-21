public class Solution {
    public string ConvertToTitle(int columnNumber) {
        StringBuilder result = new StringBuilder();
        
        while (columnNumber > 0) {
            // Shift to 0-indexed base-26
            columnNumber--; 
            
            // Get the current character offset from 'A'
            int remainder = columnNumber % 26;
            result.Append((char)('A' + remainder));
            
            // Move to the next significant position
            columnNumber /= 26;
        }
        
        // Reverse the characters since we built the string from right to left
        char[] charArray = result.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
