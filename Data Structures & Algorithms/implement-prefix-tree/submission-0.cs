public class PrefixTree {

    private class TrieNode {
        public TrieNode[] Children = new TrieNode[26];
        public bool IsEndOfWord = false;
    }

    private TrieNode root;

    public PrefixTree() {
        root = new TrieNode();
    }
    
    // Inserts a word into the prefix tree
    public void Insert(string word) {
        TrieNode curr = root;
        foreach (char c in word) {
            int index = c - 'a';
            if (curr.Children[index] == null) {
                curr.Children[index] = new TrieNode();
            }
            curr = curr.Children[index];
        }
        curr.IsEndOfWord = true;
    }
    
    // Returns true if the word is exactly in the prefix tree
    public bool Search(string word) {
        TrieNode curr = root;
        foreach (char c in word) {
            int index = c - 'a';
            if (curr.Children[index] == null) {
                return false;
            }
            curr = curr.Children[index];
        }
        return curr.IsEndOfWord;
    }
    
    // Returns true if there is any word in the trie that starts with the given prefix
    public bool StartsWith(string prefix) {
        TrieNode curr = root;
        foreach (char c in prefix) {
            int index = c - 'a';
            if (curr.Children[index] == null) {
                return false;
            }
            curr = curr.Children[index];
        }
        return true;
    }
}
