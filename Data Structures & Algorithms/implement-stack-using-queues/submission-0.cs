public class MyStack {
    private Queue<int> queue;

    public MyStack() {
        queue = new Queue<int>();
    }
    
    // Pushes element x to the top of the stack.
    public void Push(int x) {
        queue.Enqueue(x);
        
        // Rotate the queue to bring the newly added element to the front
        int size = queue.Count;
        for (int i = 0; i < size - 1; i++) {
            queue.Enqueue(queue.Dequeue());
        }
    }
    
    // Removes the element on the top of the stack and returns it.
    public int Pop() {
        return queue.Dequeue();
    }
    
    // Returns the element on the top of the stack.
    public int Top() {
        return queue.Peek();
    }
    
    // Returns true if the stack is empty, false otherwise.
    public bool Empty() {
        return queue.Count == 0;
    }
}
