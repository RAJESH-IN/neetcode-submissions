public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        // Base edge case validation
        if (hand.Length % groupSize != 0) {
            return false;
        }

        // Step 1: Track frequencies in a regular dictionary
        Dictionary<int, int> cardCounts = new Dictionary<int, int>();
        foreach (int card in hand) {
            if (!cardCounts.ContainsKey(card)) {
                cardCounts[card] = 0;
            }
            cardCounts[card]++;
        }

        // Step 2: Sort the array to process values sequentially from smallest to largest
        Array.Sort(hand);

        // Step 3: Iterate through sorted elements safely
        foreach (int card in hand) {
            // Skip if this card was already used up as part of a previous group
            if (cardCounts[card] == 0) continue;

            // Attempt to form a valid consecutive sequence starting from 'card'
            for (int i = 0; i < groupSize; i++) {
                int currentCard = card + i;

                // Check if the required consecutive card is missing or completely depleted
                if (!cardCounts.ContainsKey(currentCard) || cardCounts[currentCard] <= 0) {
                    return false;
                }

                // Decrement the count of the consumed card safely
                cardCounts[currentCard]--;
            }
        }

        return true;
    }
}
