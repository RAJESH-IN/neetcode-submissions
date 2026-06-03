public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        
        foreach (char c in s) {
            // Push open brackets onto the stack
            if (c == '(' || c == '{' || c == '[') {
                stack.Push(c);
            } 
            // Handle closing brackets
            else {
                if (stack.Count == 0) return false;
                
                char openBracket = stack.Pop();
                if ((c == ')' && openBracket != '(') ||
                    (c == '}' && openBracket != '{') ||
                    (c == ']' && openBracket != '[')) {
                    return false;
                }
            }
        }
        
        // If stack is empty, all brackets matched
        return stack.Count == 0;
    }
}
