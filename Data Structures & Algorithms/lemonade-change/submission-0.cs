public class Solution {
    public bool LemonadeChange(int[] bills) {
           int fiveCount = 0;
        int tenCount = 0;

        foreach (int bill in bills) {
            if (bill == 5) {
                // No change needed, accept the bill
                fiveCount++;
            } 
            else if (bill == 10) {
                // Need to return $5 change
                if (fiveCount == 0) return false;
                fiveCount--;
                tenCount++;
            } 
            else { 
                // bill == 20: Need to return $15 change
                // Strategy: Prefer one $10 and one $5 to save $5 bills
                if (tenCount > 0 && fiveCount > 0) {
                    tenCount--;
                    fiveCount--;
                } 
                // Alternative: Use three $5 bills
                else if (fiveCount >= 3) {
                    fiveCount -= 3;
                } 
                else {
                    return false;
                }
            }
        }

        return true;
    }
}