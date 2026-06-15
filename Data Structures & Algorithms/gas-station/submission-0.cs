public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int totalTank = 0;
        int currentTank = 0;
        int startIndex = 0;

        for (int i = 0; i < gas.Length; i++) {
            int netGas = gas[i] - cost[i];
            totalTank += netGas;
            currentTank += netGas;

            // If the car runs out of fuel at the current station
            if (currentTank < 0) {
                // The next station becomes the new candidate start
                startIndex = i + 1;
                // Reset the tank for the new journey
                currentTank = 0;
            }
        }

        // If total gas is less than total cost, it's impossible
        return totalTank >= 0 ? startIndex : -1;
    }
}
