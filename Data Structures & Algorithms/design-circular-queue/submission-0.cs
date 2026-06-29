public class MyCircularQueue {
    private int[] queue;
    private int head;
    private int tail;
    private int size;
    private int capacity;

    public MyCircularQueue(int k) {
        capacity = k;
        queue = new int[k];
        head = 0;
        tail = -1;
        size = 0;
    }
    
    // Note the capital Q
    public bool EnQueue(int value) {
        if (IsFull()) {
            return false;
        }
        tail = (tail + 1) % capacity;
        queue[tail] = value;
        size++;
        return true;
    }
    
    // Note the capital Q
    public bool DeQueue() {
        if (IsEmpty()) {
            return false;
        }
        head = (head + 1) % capacity;
        size--;
        return true;
    }
    
    public int Front() {
        if (IsEmpty()) {
            return -1;
        }
        return queue[head];
    }
    
    public int Rear() {
        if (IsEmpty()) {
            return -1;
        }
        return queue[tail];
    }
    
    public bool IsEmpty() {
        return size == 0;
    }
    
    public bool IsFull() {
        return size == capacity;
    }
}
