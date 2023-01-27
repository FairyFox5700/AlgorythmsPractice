using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.ModerateChapter
{
    // 16.25 LRU Cache: Design and build a "least recently used" cache, which evicts the least recently used item.
    //   The cache should map from keys to values(allowing you to insert and retrieve a value associated
    // with a particular key) and be initialized with a max size.When it is full, it should evict the least
    // recently used item.You can assume the keys are integers and the values are strings.
    public class LastRecentlyUsedCache
    {
        private LinkedList<KeyValuePair<int, int>> list;
        private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> map;
        private int maxCapacity;

        public LastRecentlyUsedCache(int maxCapacity)
        {
            this.maxCapacity = maxCapacity;
            list = new();
            map = new();
        }

        // inserting Key, Value Pair: We need to be able to insert a (key, value) pair.
        // linked list is sorted by last used data
        public void InsertValue(KeyValuePair<int, int> keyValuePair)
        {
            if (map.ContainsKey(keyValuePair.Key))
            {
                var node = map[keyValuePair.Key];
                list.Remove(node);
                map[keyValuePair.Key] = list.AddFirst(keyValuePair);
            }
            else
            {
                if (map.Count >= maxCapacity)
                {
                    map.Remove(list.Last().Key);
                    list.RemoveLast();
                }

                map[keyValuePair.Key] = list.AddFirst(keyValuePair);
            }
        }

        /* Get value for key and mark as most necently used. */
        public int GetValue(int key)
        {
            if (map.ContainsKey(key))
            {
                var node = map[key];
                list.Remove(node);
                list.AddFirst(node);
                return node.Value.Value;
            }

            return 0;
        }
    }
}
