public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        int n = position.Length;
        if (n == 0) return 0;

        // Pair up position and calculated time to destination
        Car[] cars = new Car[n];
        for (int i = 0; i < n; i++) {
            // Use double for precise time division
            double time = (double)(target - position[i]) / speed[i];
            cars[i] = new Car(position[i], time);
        }

        // Sort cars by starting position in descending order
        Array.Sort(cars, (a, b) => b.Position.CompareTo(a.Position));

        int fleets = 0;
        double currentFleetTime = 0.0;

        foreach (var car in cars) {
            // If this car takes more time than the leading fleet, it forms a new fleet
            if (car.TimeToTarget > currentFleetTime) {
                fleets++;
                currentFleetTime = car.TimeToTarget;
            }
        }

        return fleets;
    }

    private struct Car {
        public int Position;
        public double TimeToTarget;
        public Car(int pos, double time) {
            Position = pos;
            TimeToTarget = time;
        }
    }
}
