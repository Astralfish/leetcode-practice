namespace LeetcodePractice.Implementation.Interview150;
public class LRUCache
{
    private LinkedList<(int key, int value)> lastAccessTracker = new LinkedList<(int, int)>();
    private Dictionary<int, LinkedListNode<(int key, int value)>> cache = new Dictionary<int, LinkedListNode<(int, int)>>();
    private int capacity;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
    }

    public int Get(int key)
    {
        if (cache.TryGetValue(key, out var node))
        {
            RefreshNode(node);
            return node.Value.value;
        }
        else
        {
            return -1;
        }
    }

    public void Put(int key, int value)
    {
        if (cache.TryGetValue(key, out var node))
        {
            RefreshNode(node);
            node.Value = (key, value);
        }
        else
        {
            var newNode = lastAccessTracker.AddFirst((key, value));
            cache.Add(key, newNode);

            if (cache.Count > capacity)
            {
                var lruNode = lastAccessTracker.Last;
                lastAccessTracker.RemoveLast();
                cache.Remove(lruNode!.Value.key);
            }
        }
    }

    private void RefreshNode(LinkedListNode<(int, int)> node)
    {
        lastAccessTracker.Remove(node);
        lastAccessTracker.AddFirst(node);
    }
}
