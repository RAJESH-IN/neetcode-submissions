public class Solution {
    public int CountComponents(int n, int[][] edges) {
        int[] parent = new int[n];
        int count = n; // Start with n individual components

        // Initialize each node to be its own parent
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }

        // Merge components for each edge
        foreach (var edge in edges) {
            int u = edge[0];
            int v = edge[1];

            if (Union(u, v, parent)) {
                count--; // Reduce component count if a merge happens
            }
        }

        return count;
    }

    // Find with path compression
    private int Find(int node, int[] parent) {
        if (parent[node] == node) {
            return node;
        }
        return parent[node] = Find(parent[node], parent); // Path compression
    }

    // Union returns true if components were merged, false if already connected
    private bool Union(int u, int v, int[] parent) {
        int rootU = Find(u, parent);
        int rootV = Find(v, parent);

        if (rootU == rootV) {
            return false; // Already in the same component
        }

        parent[rootU] = rootV; // Merge
        return true;
    }
}
