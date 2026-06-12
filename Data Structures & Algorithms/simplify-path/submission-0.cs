public class Solution {
    public string SimplifyPath(string path) {
        // Split the path by slashes
        string[] components = path.Split('/');
        Stack<string> stack = new Stack<string>();

        foreach (string component in components) {
            // Skip empty components (from '//') or current directory symbols ('.')
            if (string.IsNullOrEmpty(component) || component == ".") {
                continue;
            }
            
            // Go up one level if we see '..'
            if (component == "..") {
                if (stack.Count > 0) {
                    stack.Pop();
                }
            } 
            // Valid directory name
            else {
                stack.Push(component);
            }
        }

        // Reconstruct the canonical path from the remaining elements
        // Reversing array because Stack pops in reverse order
        string[] resultComponents = stack.ToArray();
        Array.Reverse(resultComponents);
        
        return "/" + string.Join("/", resultComponents);
    }
}