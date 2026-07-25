public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        // Map each character to its custom alphabetical index position
        int[] charOrderMap = new int[26];
        for (int i = 0; i < order.Length; i++) {
            charOrderMap[order[i] - 'a'] = i;
        }

        // Compare adjacent pairs of words
        for (int i = 0; i < words.Length - 1; i++) {
            if (!IsPairSorted(words[i], words[i + 1], charOrderMap)) {
                return false;
            }
        }

        return true;
    }

    private bool IsPairSorted(string word1, string word2, int[] charOrderMap) {
        int minLength = Math.Min(word1.Length, word2.Length);

        for (int i = 0; i < minLength; i++) {
            int char1Index = charOrderMap[word1[i] - 'a'];
            int char2Index = charOrderMap[word2[i] - 'a'];

            // Found the first mismatching character
            if (char1Index != char2Index) {
                return char1Index < char2Index;
            }
        }

        // If all characters match up to minLength, the shorter word must come first
        return word1.Length <= word2.Length;
    }
}
