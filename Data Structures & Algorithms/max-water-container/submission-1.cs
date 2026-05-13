public class Solution {
    public int MaxArea(int[] heights) {
        
        int left=0;
        int right=heights.Length-1;
        int MaxArea=0;
        while (left<right)
        {
            int len=right-left;
            int bredth=Math.Min(heights[left],heights[right]);
            int area=len*bredth;
            MaxArea=Math.Max(MaxArea,area);
            if(heights[left] < heights[right])
                left++;
            else
                right--;    
        }
        return MaxArea;
    }
}
