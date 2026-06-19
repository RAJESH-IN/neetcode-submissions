public class WordDictionary {
    private class TrieNode {
        public TrieNode[] Children = new TrieNode[26];
        public bool IsEndOfWord = false;
    }

    private readonly TrieNode root;

    public WordDictionary() {
        root = new TrieNode();
    }
    
    public void AddWord(string word) {
        TrieNode current = root;
        foreach (char c in word) {
            int index = c - 'a';
            if (current.Children[index] == null) {
                current.Children[index] = new TrieNode();
            }
            current = current.Children[index];
        }
        current.IsEndOfWord = true;
    }
    
    public bool Search(string word) {
        return SearchInNode(word, 0, root);
    }

    private bool SearchInNode(string word, int wordIndex, TrieNode node) {
        // Base case: reached the end of the search word string
        if (wordIndex == word.Length) {
            return node.IsEndOfWord;
        }

        char c = word[wordIndex];

        // Handle the wildcard character '.'
        if (c == '.') {
            // Check all 26 possible branches recursively
            for (int i = 0; i < 26; i++) {
                if (node.Children[i] != null && SearchInNode(word, wordIndex + 1, node.Children[i])) {
                    return true;
                }
            }
            return false;
        } 
        // Handle normal alphabetical lowercase characters
        else {
            int index = c - 'a';
            if (node.Children[index] == null) {
                return false;
            }
            return SearchInNode(word, wordIndex + 1, node.Children[index]);
        }
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
