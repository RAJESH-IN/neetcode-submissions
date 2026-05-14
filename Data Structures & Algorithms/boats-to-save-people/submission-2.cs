public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        // Step 1: Sort weights from lightest to heaviest
        Array.Sort(people);
       
        int left=0;
        int right=people.Length-1;
        int boat=0;

        // Step 2: Pair people using two pointers
        while(left<=right)
        {
             // If the lightest and heaviest can share a boat
            if(people[left]+people[right]<=limit)
            {
                left++;// Lightest person gets on the boat
            }
            right--; // Heaviest person always gets on the boat

            boat++; // One boat is used
        }
        return boat;
    }
}