public class Solution {
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        int n = profits.Length;
        
        // 1. Group projects by (capital, profit) pairs
        (int cap, int prof)[] projects = new (int, int)[n];
        for (int i = 0; i < n; i++) {
            projects[i] = (capital[i], profits[i]);
        }
        
        // Sort projects primarily by the capital required
        Array.Sort(projects, (a, b) => a.cap.CompareTo(b.cap));
        
        // 2. Max-Heap to track profits of affordable projects
        // (In C#, invert priority values to simulate a Max-Heap)
        PriorityQueue<int, int> maxProfitHeap = new PriorityQueue<int, int>();
        
        int projectIndex = 0;
        
        // 3. Select up to k projects greedily
        for (int i = 0; i < k; i++) {
            // Push all projects we can afford into the heap
            while (projectIndex < n && projects[projectIndex].cap <= w) {
                int profit = projects[projectIndex].prof;
                maxProfitHeap.Enqueue(profit, -profit); // Negative priority for Max-Heap
                projectIndex++;
            }
            
            // If no projects are affordable, we can't proceed further
            if (maxProfitHeap.Count == 0) {
                break;
            }
            
            // Pick the project with the highest profit
            w += maxProfitHeap.Dequeue();
        }
        
        return w;
    }
}
