public class LFUCache
{
    private int capacity;

    private Dictionary<int, int> cache;

    private Dictionary<int, int> freq;

    // recent order
    private List<int> order;

    public LFUCache(int capacity)
    {
        this.capacity = capacity;

        cache = new Dictionary<int, int>();

        freq = new Dictionary<int, int>();

        order = new List<int>();
    }

    public int Get(int key)
    {
        if(!cache.ContainsKey(key))
        {
            return -1;
        }

        freq[key]++;

        // move to recent
        order.Remove(key);
        order.Add(key);

        return cache[key];
    }

    public void Put(int key, int value)
    {
        if(capacity == 0)
        {
            return;
        }

        if(cache.ContainsKey(key))
        {
            cache[key] = value;

            freq[key]++;

            order.Remove(key);
            order.Add(key);

            return;
        }

        if(cache.Count == capacity)
        {
            int minFreq = int.MaxValue;

            foreach(var k in freq.Keys)
            {
                minFreq = Math.Min(minFreq, freq[k]);
            }

            // remove least recent among min freq
            int removeKey = -1;

            foreach(int k in order)
            {
                if(freq[k] == minFreq)
                {
                    removeKey = k;
                    break;
                }
            }

            cache.Remove(removeKey);

            freq.Remove(removeKey);

            order.Remove(removeKey);
        }

        cache[key] = value;

        freq[key] = 1;

        order.Add(key);
    }
}