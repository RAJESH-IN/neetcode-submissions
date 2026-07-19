
    
   public class MyHashSet {
    private bool[] data;

    public MyHashSet() {
        data = new bool[1000001];
    }
    
    public void Add(int key) {
        data[key] = true;
    }
    
    public void Remove(int key) {
        data[key] = false;
    }
    
    public bool Contains(int key) {
        return data[key];
    }


}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */