using System;
using System.Collections.Generic;

namespace DSA.Lab03
{
    public sealed class IntHashTable<TValue>
    {
        private readonly List<Entry<TValue>>[] _buckets;
        private int _count; 

        public IntHashTable(int bucketCount)
        {
            if (bucketCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bucketCount));
            }

            _buckets = new List<Entry<TValue>>[bucketCount];
            for (int i = 0; i < _buckets.Length; ++i)
            {
                _buckets[i] = new List<Entry<TValue>>();
            }
        }

        public int Count => _count;
        public int BucketCount => _buckets.Length;

         public void Set(int key, TValue value)
         { 
                int bucketIndex = GetBucketIndex(key);

                List<Entry<TValue>> currentBucket = _buckets[bucketIndex];
            
                for(int i = 0; i < currentBucket.Count; i++)
                {
                    if (currentBucket[i].Key == key)
                    {
                        currentBucket[i] = new Entry<TValue>(key,value);
                        return; 
                    }
                }

            currentBucket.Add(new Entry<TValue>(key, value));
            _count++; 

            // TODO: search only the correct bucket, replace or append.
         }

        public bool TryGetValue(int key, out TValue value)
        {
            value = default!;

            int bucketIndex = GetBucketIndex(key);

            List<Entry<TValue>> currentBucket = _buckets[bucketIndex];

            for (int i = 0; i < currentBucket.Count; i++)
            {
                if (currentBucket[i].Key == key)
                {
                    value = currentBucket[i].Value;
                    return true; 
                }
            }


            return false; 
            // TODO: search only the correct bucket.
        }

        public bool ContainsKey(int key)
        {
            int bucketIndex = GetBucketIndex(key);

            List<Entry<TValue>> currentBucket = _buckets[bucketIndex];

            for (int i = 0; i < currentBucket.Count; i++)
            {
                if (currentBucket[i].Key == key)
                {
                    return true;
                }
            }

            return false;
        }

        private int GetBucketIndex(int key)
        {
            if (key < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "This learning implementation uses non-negative integer keys.");
            }

            return key % _buckets.Length;
        }
    }
}
