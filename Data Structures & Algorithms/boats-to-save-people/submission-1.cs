public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        Array.Sort(people);
        int left=0;
        int right=people.Length-1;
        int boat=0;

        while(left<=right)
        {
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