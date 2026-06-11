public class Solution {
    public List<int> FindClosestElements(int[] arr, int k, int x) {
        int l = 0;
        int r = arr.Length - k;
        
        // Binary search to find the starting index of the k closest elements
        while (l < r) {
            int mid = l + (r - l) / 2;
            
            // Compare the distance of x from arr[mid] vs arr[mid + k]
            if (x - arr[mid] > arr[mid + k] - x) {
                l = mid + 1; // Move window right
            } else {
                r = mid;     // Move window left
            }
        }
        
        // Build the result list from the found starting index 'l'
        List<int> result = new List<int>();
        for (int i = l; i < l + k; i++) {
            result.Add(arr[i]);
        }
        
        return result;
    }
}
