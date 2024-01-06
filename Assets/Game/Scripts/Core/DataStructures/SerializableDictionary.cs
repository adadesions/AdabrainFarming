using System;
using System.Collections.Generic;

namespace Game.Scripts.Core.DataStructures
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue>
    {
        public List<TKey> keys;
        public List<TValue> values;

        public SerializableDictionary(Dictionary<TKey, TValue> dictionary)
        {
            keys = new List<TKey>(dictionary.Keys);
            values = new List<TValue>(dictionary.Values);
        }

        public Dictionary<TKey, TValue> ToDictionary()
        {
            var dictionary = new Dictionary<TKey, TValue>();

            if (keys.Count != values.Count)
            {
                return dictionary;
            }

            for (int i = 0; i < keys.Count; i++)
            {
                dictionary.Add(keys[i], values[i]);
            }

            return dictionary;
        }
    }
}