public class Solution {
    public class TrieNode {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public string Word = null;
    }

    public List<string> FindWords(char[][] board, string[] words) {
        List<string> result = new List<string>();
        TrieNode root = BuildTrie(words);

        for (int r = 0; r < board.Length; r++) {
            for (int c = 0; c < board[0].Length; c++) {
                DFS(board, r, c, root, result);
            }
        }

        return result;
    }

    private void DFS(char[][] board, int r, int c, TrieNode node, List<string> result) {
        if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length) return;
        
        char ch = board[r][c];
        if (ch == '#' || !node.Children.ContainsKey(ch)) return;

        TrieNode nextNode = node.Children[ch];
        if (nextNode.Word != null) {
            result.Add(nextNode.Word);
            nextNode.Word = null; // Prevent duplicate findings
        }

        board[r][c] = '#'; // Mark as visited

        DFS(board, r + 1, c, nextNode, result);
        DFS(board, r - 1, c, nextNode, result);
        DFS(board, r, c + 1, nextNode, result);
        DFS(board, r, c - 1, nextNode, result);

        board[r][c] = ch; // Backtrack

        // Optimization: Prune the leaf node if it has no children
        if (nextNode.Children.Count == 0) {
            node.Children.Remove(ch);
        }
    }

    private TrieNode BuildTrie(string[] words) {
        TrieNode root = new TrieNode();
        foreach (string word in words) {
            TrieNode current = root;
            foreach (char ch in word) {
                if (!current.Children.ContainsKey(ch)) {
                    current.Children[ch] = new TrieNode();
                }
                current = current.Children[ch];
            }
            current.Word = word;
        }
        return root;
    }
}
