public class Solution {
    private Dictionary<int, int> parent = new Dictionary<int, int>();
    private Dictionary<int, int> size = new Dictionary<int, int>();

    public int LongestConsecutive(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;

        // Initialize DSU structures for unique elements
        foreach (int num in nums) {
            if (!parent.ContainsKey(num)) {
                parent[num] = num;
                size[num] = 1;
            }
        }

        int maxStreak = 1;

        // Union adjacent numbers
        foreach (int num in parent.Keys) {
            if (parent.ContainsKey(num + 1)) {
                maxStreak = Math.Max(maxStreak, Union(num, num + 1));
            }
        }

        return maxStreak;
    }

    private int Find(int i) {
        if (parent[i] == i) return i;
        return parent[i] = Find(parent[i]); // Path compression
    }

    private int Union(int i, int j) {
        int rootI = Find(i);
        int rootJ = Find(j);

        if (rootI != rootJ) {
            // Union by size
            if (size[rootI] < size[rootJ]) {
                parent[rootI] = rootJ;
                size[rootJ] += size[rootI];
                return size[rootJ];
            } else {
                parent[rootJ] = rootI;
                size[rootI] += size[rootJ];
                return size[rootI];
            }
        }
        return size[rootI];
    }
}
