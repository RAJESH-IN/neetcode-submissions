public class Solution {
    public string DecodeString(string s) {
        Stack<int> countStack = new Stack<int>();
        Stack<StringBuilder> stringStack = new Stack<StringBuilder>();
        StringBuilder currentString = new StringBuilder();
        int k = 0;

        foreach (char ch in s) {
            if (char.IsDigit(ch)) {
                // Formulate the multi-digit repeat count
                k = k * 10 + (ch - '0');
            } 
            else if (ch == '[') {
                // Save context before entering brackets
                countStack.Push(k);
                stringStack.Push(currentString);
                
                // Reset states for the new bracket layer
                currentString = new StringBuilder();
                k = 0;
            } 
            else if (ch == ']') {
                // Finished a block, resolve repetition
                StringBuilder decodedString = stringStack.Pop();
                int repeatTimes = countStack.Pop();
                
                for (int i = 0; i < repeatTimes; i++) {
                    decodedString.Append(currentString);
                }
                currentString = decodedString;
            } 
            else {
                // Regular alphabet character
                currentString.Append(ch);
            }
        }

        return currentString.ToString();
    }
}