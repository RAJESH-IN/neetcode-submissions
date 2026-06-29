public class MinStack {
    private Stack<int> stack;
    private Stack<int> minStack;

    public MinStack() {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }
    
    public void Push(int val) {
        stack.Push(val);
        
        // The new min is either the value itself or the previous minimum
        if (minStack.Count == 0 || val <= minStack.Peek()) {
            minStack.Push(val);
        } else {
            minStack.Push(minStack.Peek());
        }
    }
    
    public void Pop() {
        stack.Pop();
        minStack.Pop();
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        return minStack.Peek();
    }
}
