public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
         int n = temperatures.Length;
        int[] result = new int[n];
        // Stack stores the indices of the days
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < n; i++) {
            // While stack is not empty and current temperature is warmer than top of stack
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()]) {
                int prevIndex = stack.Pop();
                result[prevIndex] = i - prevIndex; // Distance between days
            }
            stack.Push(i); // Push current day's index
        }

        return result;
    }
    
}
