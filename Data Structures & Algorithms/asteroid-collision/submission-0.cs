public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
         Stack<int> stack = new Stack<int>();
        
        foreach (int ast in asteroids) {
            bool destroyed = false;
            
            // Collision happens only if top moves right (+) and current moves left (-)
            while (stack.Count > 0 && ast < 0 && stack.Peek() > 0) {
                if (stack.Peek() < -ast) {
                    stack.Pop(); // Top explodes
                    continue;
                } else if (stack.Peek() == -ast) {
                    stack.Pop(); // Both explode
                    destroyed = true;
                    break;
                } else {
                    destroyed = true; // Current explodes
                    break;
                }
            }
            
            if (!destroyed) {
                stack.Push(ast);
            }
        }
        
        int[] result = stack.ToArray();
        Array.Reverse(result);
        return result;
    }
}