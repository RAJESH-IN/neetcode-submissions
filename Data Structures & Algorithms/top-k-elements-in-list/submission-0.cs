public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // Step 1: Count frequencies of each element
        Dictionary<int, int> countMap = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (!countMap.ContainsKey(num)) {
                countMap[num] = 0;
            }
            countMap[num]++;
        }

        // Step 2: Create buckets where index = frequency
        // The maximum possible frequency is nums.Length
        List<int>[] buckets = new List<int>[nums.Length + 1];
        foreach (var kvp in countMap) {
            int num = kvp.Key;
            int frequency = kvp.Value;
            
            if (buckets[frequency] == null) {
                buckets[frequency] = new List<int>();
            }
            buckets[frequency].Add(num);
        }

        // Step 3: Gather the top k frequent elements from the back of the bucket array
        int[] result = new int[k];
        int resultIndex = 0;

        for (int i = buckets.Length - 1; i >= 0 && resultIndex < k; i--) {
            if (buckets[i] != null) {
                foreach (int num in buckets[i]) {
                    result[resultIndex++] = num;
                    if (resultIndex == k) {
                        return result;
                    }
                }
            }
        }

        return result;
    }
}
