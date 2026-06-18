public class FreqStack {
    // Maps a value to its total frequency count
    private Dictionary<int, int> freqMap;
    // Maps a frequency level to a stack of elements that have reached that frequency
    private Dictionary<int, Stack<int>> groupMap;
    // Tracks the highest frequency currently in the stack
    private int maxFreq;

    public FreqStack() {
        freqMap = new Dictionary<int, int>();
        groupMap = new Dictionary<int, Stack<int>>();
        maxFreq = 0;
    }
    
    public void Push(int val) {
        // 1. Update frequency for this value
        if (!freqMap.ContainsKey(val)) {
            freqMap[val] = 0;
        }
        freqMap[val]++;
        int currentFreq = freqMap[val];

        // 2. Keep track of the global maximum frequency
        if (currentFreq > maxFreq) {
            maxFreq = currentFreq;
        }

        // 3. Add the value to the stack corresponding to its current frequency level
        if (!groupMap.ContainsKey(currentFreq)) {
            groupMap[currentFreq] = new Stack<int>();
        }
        groupMap[currentFreq].Push(val);
    }
    
    public int Pop() {
        // 1. Get the top element from the highest frequency group stack
        int val = groupMap[maxFreq].Pop();

        // 2. Decrement the frequency of that element in our frequency tracker
        freqMap[val]--;

        // 3. Clean up the group level if its stack becomes empty
        if (groupMap[maxFreq].Count == 0) {
            maxFreq--;
        }

        return val;
    }
}


/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(val);
 * int param_2 = obj.Pop();
 */