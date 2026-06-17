
public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        IList<int> result = new List<int>();
        if (nums == null || nums.Length == 0) return result;

        // Step 1: Find potential candidates (at most two elements can appear > n/3 times)
        int candidate1 = 0, candidate2 = 0;
        int count1 = 0, count2 = 0;

        foreach (int num in nums) {
            if (num == candidate1) {
                count1++;
            } else if (num == candidate2) {
                count2++;
            } else if (count1 == 0) {
                candidate1 = num;
                count1 = 1;
            } else if (count2 == 0) {
                candidate2 = num;
                count2 = 1;
            } else {
                count1--;
                count2--;
            }
        }

        // Step 2: Validate the candidates by counting their actual frequencies
        count1 = 0;
        count2 = 0;
        foreach (int num in nums) {
            if (num == candidate1) count1++;
            else if (num == candidate2) count2++;
        }

        int threshold = nums.Length / 3;
        if (count1 > threshold) result.Add(candidate1);
        if (count2 > threshold) result.Add(candidate2);

        return result;
    }
}
