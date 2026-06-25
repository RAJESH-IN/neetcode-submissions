public class Solution {
    public int[] ReplaceElements(int[] arr) {
        int maxSoFar = -1;
        
        for (int i = arr.Length - 1; i >= 0; i--) {
            int currentVal = arr[i];
            arr[i] = maxSoFar;
            
            if (currentVal > maxSoFar) {
                maxSoFar = currentVal;
            }
        }
        
        return arr;
    }
}
