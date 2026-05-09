public class Node
{
    public int key;
    public int value;

    public Node prev;
    public Node next;

    public Node(int k, int v)
    {
        key = k;
        value = v;
    }
}

public class LRUCache
{
    private int capacity;

    private Dictionary<int, Node> cache;

    private Node left;   // LRU
    private Node right;  // MRU

    public LRUCache(int capacity)
    {
        this.capacity = capacity;

        cache = new Dictionary<int, Node>();

        left = new Node(0, 0);
        right = new Node(0, 0);

        left.next = right;
        right.prev = left;
    }

    // remove node
    private void Remove(Node node)
    {
        Node prev = node.prev;
        Node next = node.next;

        prev.next = next;
        next.prev = prev;
    }

    // insert at right (most recent)
    private void Insert(Node node)
    {
        Node prev = right.prev;

        prev.next = node;
        node.prev = prev;

        node.next = right;
        right.prev = node;
    }

    public int Get(int key)
    {
        if(cache.ContainsKey(key))
        {
            Node node = cache[key];

            Remove(node);
            Insert(node);

            return node.value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        if(cache.ContainsKey(key))
        {
            Remove(cache[key]);
            cache.Remove(key);
        }

        Node node = new Node(key, value);

        cache[key] = node;

        Insert(node);

        if(cache.Count > capacity)
        {
            Node lru = left.next;

            Remove(lru);

            cache.Remove(lru.key);
        }
    }
}