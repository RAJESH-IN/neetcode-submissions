public class Solution {
    public int MaxArea(int[] heights) {
        int left =0;
        int right =heights.Length-1;
        int maxArea=0;
        while (left<right)
        {
            int area=(right-left)*Math.Min(heights[left],heights[right]);
            maxArea=Math.Max(area,maxArea);

            if(heights[left]<heights[right])
            left++;
            else
            right--;
        }

        return maxArea;
    }
}
