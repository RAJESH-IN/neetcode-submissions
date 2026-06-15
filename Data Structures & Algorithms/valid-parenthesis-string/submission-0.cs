public class Solution {
    public bool CheckValidString(string s) {
        int minOpen = 0;
        int maxOpen = 0;

        foreach (char c in s) {
            if (c == '(') {
                minOpen++;
                maxOpen++;
            } else if (c == ')') {
                minOpen--;
                maxOpen--;
            } else if (c == '*') {
                // If '*' is ')', minOpen decreases
                minOpen--; 
                // If '*' is '(', maxOpen increases
                maxOpen++; 
            }

            // If maxOpen drops below 0, there are too many ')' characters
            if (maxOpen < 0) {
                return false;
            }

            // minOpen cannot be less than 0 (we can't have negative open brackets)
            if (minOpen < 0) {
                minOpen = 0;
            }
        }

        // The string is valid if we can achieve exactly 0 open brackets
        return minOpen == 0;
    }
}
