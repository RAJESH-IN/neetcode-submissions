public class LRUCache
{
    private int capacity;

    private Dictionary<int, int> cache;

    private List<int> order;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;

        cache = new Dictionary<int, int>();

        order = new List<int>();
    }

    public int Get(int key)
    {
        if(!cache.ContainsKey(key))
        {
            return -1;
        }

        // move key to recent
        order.Remove(key);
        order.Add(key);

        return cache[key];
    }

    public void Put(int key, int value)
    {
        if(cache.ContainsKey(key))
        {
            cache[key] = value;

            order.Remove(key);
            order.Add(key);
        }
        else
        {
            if(cache.Count == capacity)
            {
                int lru = order[0];

                order.RemoveAt(0);

                cache.Remove(lru);
            }

            cache[key] = value;

            order.Add(key);
        }
    }
}