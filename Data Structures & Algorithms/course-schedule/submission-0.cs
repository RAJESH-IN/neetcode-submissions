public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        // Step 1: Initialize the adjacency list and in-degree array
        List<int>[] graph = new List<int>[numCourses];
        int[] inDegree = new int[numCourses];
        
        for (int i = 0; i < numCourses; i++) {
            graph[i] = new List<int>();
        }
        
        // Step 2: Build the graph structure
        // prerequisites[i] = [a, b] means b -> a (b is a prerequisite for a)
        foreach (var prereq in prerequisites) {
            int course = prereq[0];
            int nextCourse = prereq[1];
            graph[nextCourse].Add(course);
            inDegree[course]++;
        }
        
        // Step 3: Add all courses with 0 prerequisites to the queue
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (inDegree[i] == 0) {
                queue.Enqueue(i);
            }
        }
        
        // Step 4: Process courses in topological order
        int completedCoursesCount = 0;
        while (queue.Count > 0) {
            int currentCourse = queue.Dequeue();
            completedCoursesCount++;
            
            // Reduce the in-degree of all neighbor courses
            foreach (int neighbor in graph[currentCourse]) {
                inDegree[neighbor]--;
                // If a neighbor has no more prerequisites, enqueue it
                if (inDegree[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }
        
        // Step 5: If we visited all courses, no cycle exists
        return completedCoursesCount == numCourses;
    }
}
