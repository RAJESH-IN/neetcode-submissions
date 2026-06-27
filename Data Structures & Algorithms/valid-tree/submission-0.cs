public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        // Condition 1: A valid tree must have exactly n - 1 edges
        if (edges.Length != n - 1) {
            return false;
        }

        int[] parent = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i; // Initialize each node as its own parent
        }

        // Process every edge
        foreach (var edge in edges) {
            int u = edge[0];
            int v = edge[1];

            // If find(u) == find(v), they are already connected -> Cycle found!
            if (!Union(u, v, parent)) {
                return false;
            }
        }

        return true;
    }

    // Find the root parent with path compression
    private int Find(int node, int[] parent) {
        if (parent[node] == node) {
            return node;
        }
        return parent[node] = Find(parent[node], parent); // Path compression
    }

    // Union the components. Returns false if they already belong to the same root.
    private bool Union(int u, int v, int[] parent) {
        int rootU = Find(u, parent);
        int rootV = Find(v, parent);

        if (rootU == rootV) {
            return false; // Cycle detected
        }

        parent[rootU] = rootV; // Merge sets
        return true;
    }
}
