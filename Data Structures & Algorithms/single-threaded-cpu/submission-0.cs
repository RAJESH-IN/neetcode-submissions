public class Solution {
    public int[] GetOrder(int[][] tasks) {
        int n = tasks.Length;
        int[] result = new int[n];
        
        // Store tasks with their original index: [enqueueTime, processingTime, originalIndex]
        int[][] sortedTasks = new int[n][];
        for (int i = 0; i < n; i++) {
            sortedTasks[i] = new int[] { tasks[i][0], tasks[i][1], i };
        }
        
        // Sort tasks primarily by enqueueTime
        Array.Sort(sortedTasks, (a, b) => a[0].CompareTo(b[0]));
        
        // Min-Heap stores: (processingTime, originalIndex)
        // We define a custom comparer to prioritize processing time, then original index
        var comparer = Comparer<(int procTime, int index)>.Create((a, b) => {
            int cmp = a.procTime.CompareTo(b.procTime);
            if (cmp != 0) return cmp;
            return a.index.CompareTo(b.index);
        });
        
        PriorityQueue<(int procTime, int index), (int procTime, int index)> minHeap = 
            new PriorityQueue<(int procTime, int index), (int procTime, int index)>(comparer);
        
        long currentTime = 0;
        int taskIdx = 0;
        int resIdx = 0;
        
        while (taskIdx < n || minHeap.Count > 0) {
            // If the heap is empty and the current time is behind the next available task's enqueue time,
            // jump the timeline forward to that task's enqueue time.
            if (minHeap.Count == 0 && currentTime < sortedTasks[taskIdx][0]) {
                currentTime = sortedTasks[taskIdx][0];
            }
            
            // Push all tasks that have arrived up to the currentTime into the heap
            while (taskIdx < n && sortedTasks[taskIdx][0] <= currentTime) {
                var currentTask = (sortedTasks[taskIdx][1], sortedTasks[taskIdx][2]);
                minHeap.Enqueue(currentTask, currentTask);
                taskIdx++;
            }
            
            // Process the best available task from the min-heap
            var nextTask = minHeap.Dequeue();
            result[resIdx++] = nextTask.index;
            currentTime += nextTask.procTime; // Advance time by processing duration
        }
        
        return result;
    }
}
