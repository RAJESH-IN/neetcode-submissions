public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        // Step 1: Sort weights from lightest to heaviest
        Array.Sort(people);
        
        int left = 0;
        int right = people.Length - 1;
        int boats = 0;
        
        // Step 2: Match people using two pointers
        while (left <= right) {
            // If the lightest and heaviest person can fit together
            if (people[left] + people[right] <= limit) {
                left++; // Lightest person gets on the boat
            }
            
            // The heaviest person always gets a boat
            right--; 
            boats++;
        }
        
        return boats;
    }
}
