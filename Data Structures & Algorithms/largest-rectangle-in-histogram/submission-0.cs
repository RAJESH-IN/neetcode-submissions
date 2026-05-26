public class Solution {
    public int LargestRectangleArea(int[] heights) {
         int maxArea = 0;
        // Stack stores pairs of (index, height)
        Stack<(int Index, int Height)> stack = new Stack<(int, int)>();

        for (int i = 0; i < heights.Length; i++) {
            int start = i;
            
            // While the current height is shorter than the top of the stack
            while (stack.Count > 0 && stack.Peek().Height > heights[i]) {
                var popped = stack.Pop();
                int area = popped.Height * (i - popped.Index);
                maxArea = Math.Max(maxArea, area);
                
                // The current shorter bar can extend backwards to the popped bar's starting index
                start = popped.Index;
            }
            
            stack.Push((start, heights[i]));
        }

        // Clear out any remaining bars left on the stack
        // These bars can extend all the way to the end of the histogram
        while (stack.Count > 0) {
            var popped = stack.Pop();
            int area = popped.Height * (heights.Length - popped.Index);
            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
     
    }
}
