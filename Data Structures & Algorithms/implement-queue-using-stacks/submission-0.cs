public class MyQueue {
    private Stack<int> input;
    private Stack<int> output;

    public MyQueue() {
        input = new Stack<int>();
        output = new Stack<int>();
    }
    
    // Push element x to the back of the queue.
    public void Push(int x) {
        input.Push(x);
    }
    
    // Removes the element from the front of the queue and returns it.
    public int Pop() {
        ShiftStacks();
        return output.Pop();
    }
    
    // Returns the element at the front of the queue.
    public int Peek() {
        ShiftStacks();
        return output.Peek();
    }
    
    // Returns true if the queue is empty, false otherwise.
    public bool Empty() {
        return input.Count == 0 && output.Count == 0;
    }

    // Helper method to move elements from input stack to output stack when needed
    private void ShiftStacks() {
        if (output.Count == 0) {
            while (input.Count > 0) {
                output.Push(input.Pop());
            }
        }
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */