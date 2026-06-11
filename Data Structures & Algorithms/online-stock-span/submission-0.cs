public class StockSpanner {
    // Stack stores pairs: Key = price, Value = accumulated span
    private Stack<KeyValuePair<int, int>> stack;

    public StockSpanner() {
        stack = new Stack<KeyValuePair<int, int>>();
    }
    
    public int Next(int price) {
        int span = 1;
        
        // Pop elements from the stack that have a price less than or equal to current price
        while (stack.Count > 0 && stack.Peek().Key <= price) {
            span += stack.Pop().Value;
        }
        
        // Push the current price and its calculated span onto the stack
        stack.Push(new KeyValuePair<int, int>(price, span));
        
        return span;
    }
}


/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */