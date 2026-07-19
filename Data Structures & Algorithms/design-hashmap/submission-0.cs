public class MyHashMap {
    private int[] data;

    public MyHashMap() {
        data = new int[1000001];
        System.Array.Fill(data, -1);
    }
    
    public void Put(int key, int value) {
        data[key] = value;
    }
    
    public int Get(int key) {
        return data[key];
    }
    
    public void Remove(int key) {
        data[key] = -1;
    }
}


/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */