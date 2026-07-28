public class Solution {
    public string foreignDictionary(string[] words) {
        // 1. Initialize adjacency list graph and in-degree tracking for all unique characters
        Dictionary<char, HashSet<char>> graph = new Dictionary<char, HashSet<char>>();
        Dictionary<char, int> inDegrees = new Dictionary<char, int>();

        foreach (string word in words) {
            foreach (char c in word) {
                if (!graph.ContainsKey(c)) {
                    graph[c] = new HashSet<char>();
                    inDegrees[c] = 0;
                }
            }
        }

        // 2. Build the graph by comparing adjacent words
        for (int i = 0; i < words.Length - 1; i++) {
            string w1 = words[i];
            string w2 = words[i + 1];
            int minLen = Math.Min(w1.Length, w2.Length);

            // Edge case: If w1 is longer than w2 but matches completely up to w2's length (e.g., "abcd" before "abc")
            if (w1.Length > w2.Length && w1.Substring(0, minLen) == w2) {
                return "";
            }

            for (int j = 0; j < minLen; j++) {
                if (w1[j] != w2[j]) {
                    char u = w1[j];
                    char v = w2[j];

                    // If the directed edge u -> v is new, add it and increment v's in-degree
                    if (!graph[u].Contains(v)) {
                        graph[u].Add(v);
                        inDegrees[v]++;
                    }
                    break; // Only the first differing character determines the order
                }
            }
        }

        // 3. Queue all characters with an in-degree of 0
        Queue<char> queue = new Queue<char>();
        foreach (var pair in inDegrees) {
            if (pair.Value == 0) {
                queue.Enqueue(pair.Key);
            }
        }

        // 4. Process the graph (BFS Topological Sort)
        StringBuilder sb = new StringBuilder();
        while (queue.Count > 0) {
            char curr = queue.Dequeue();
            sb.Append(curr);

            foreach (char neighbor in graph[curr]) {
                inDegrees[neighbor]--;
                if (inDegrees[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }

        // 5. If the result includes all unique characters, order is valid. Otherwise, a cycle exists.
        return sb.Length == inDegrees.Count ? sb.ToString() : "";
    }
}
