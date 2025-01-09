namespace ConsoleApp1.Problems;

public class LRUCache
{
    private LinkedList<CacheItem> position;
    private Dictionary<int,LinkedListNode<CacheItem>> dict;
    private int limit = 0;

    public LRUCache(int capacity)
    {
        position = new LinkedList<CacheItem>();
        limit = capacity;
        dict = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
    }
    
    public int Get(int key) 
    {
        if (dict.TryGetValue(key, out var data))
        {
            position.Remove(data);
            position.AddFirst(data);
            return data.Value.Value;
        }

        return -1;
    }
    
    public void Put(int key, int value) 
    {
        if (dict.TryGetValue(key, out var data))
        {
            if (data.Value.Value != value)
            {
                dict[key] = new LinkedListNode<CacheItem>(new CacheItem(key, value));
            }
            position.Remove(data);
            position.AddFirst(data);
        }
        else
        {            
            var newEntry = new LinkedListNode<CacheItem>(new CacheItem(key, value));
            if(dict.Any() && dict.Count >= limit)
            {
                var evicted = position.Last.Value;
                dict.Remove(evicted.Key);
                position.Remove(evicted);
            }
            position.AddFirst(newEntry);
            dict.Add(key, newEntry);
        }
    }

    private class CacheItem
    {
        public CacheItem(int key, int value)
        {
            Key = key;
            Value = value;
        }

        internal int Key {get;set;}
        internal int Value {get;set;}
    }
}