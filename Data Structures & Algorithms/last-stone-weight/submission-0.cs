public class Solution {
    public int LastStoneWeight(int[] stones) {
        // Create a Max-Heap by passing a custom comparer that sorts high-to-low
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        // Insert all stones into the heap
        foreach (int stone in stones) {
            maxHeap.Enqueue(stone, stone);
        }

        // Simulate smashing until 0 or 1 stone remains
        while (maxHeap.Count > 1) {
            int stone1 = maxHeap.Dequeue(); // Heaviest stone (y)
            int stone2 = maxHeap.Dequeue(); // Second heaviest stone (x)

            if (stone1 != stone2) {
                int newStone = stone1 - stone2;
                maxHeap.Enqueue(newStone, newStone);
            }
        }

        // If 1 stone is left, return its weight; otherwise return 0
        return maxHeap.Count == 1 ? maxHeap.Peek() : 0;
    }
}
