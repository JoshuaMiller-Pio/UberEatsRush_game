using System;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : Singleton<SFXManager>
{
    public List<AudioClip> SFXClips = new List<AudioClip>();
    private  MyHashMap<string, AudioClip> hashMap;
    private AudioSource source;
    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    void Awake()
    {
        
        hashMap = new MyHashMap<string, AudioClip>(); 
        for (int i = 0; i < SFXClips.Count; i++)
        {
            hashMap.Add(SFXClips[i].name, SFXClips[i]);

        }
    }





   public void PlaySound(String name)
   {
       source.PlayOneShot(hashMap.Get(name));
   }
}




public class MyHashMap<TKey, TValue>
{
    
    //allows the setting of the genric values
      private class Entry
        {
            public TKey Key;
            public TValue Value;
            public Entry Next;
            public int Hashcode;
        }

      //sets the start and max capacity I didnt add an increase capacity method
        private const int StartCapacity = 6;
        
        //basically just a node but allows multiple entries 
        private Entry[] buckets;
        private int index;
        
        public MyHashMap() : this(StartCapacity)
        { }

        //sets capacity 
        public MyHashMap(int capacity)
        {
            if (capacity < StartCapacity)
            {
                capacity = StartCapacity;
            }
            buckets = new Entry[capacity];
        }

        
        //method adds to the hashmap
        public void Add(TKey key, TValue value)
        {
            //assignes a hashcode to quickly identify it
            int hashcode = key.GetHashCode();
            
            int targetBucket = (hashcode & int.MaxValue) % buckets.Length;
            Entry entry = null;

            // Search for existing key
            for (entry = buckets[targetBucket]; entry != null; entry = entry.Next)
            {
                if (entry.Hashcode == hashcode && entry.Key.Equals(key))
                {
                    // Key already exists
                    entry.Value = value;
                    return;
                }
            }
            
            // Create new entry 
            entry = new Entry()
            {
                Key = key,
                Value = value,
                Hashcode = hashcode
            };
            
            // And add to table
            entry.Next = buckets[targetBucket];
            buckets[targetBucket] = entry;
            index++;
        }

        //gets the value based on the key
        public TValue Get(TKey key)
        {
            Entry entry = Find(key);
            if (entry != null)
                return entry.Value;
            return default(TValue);
        }

       
        //is called by get, just finds the key but makes sure the keep the hashcode private 
        private Entry Find(TKey key)
        {
            int hashcode = key.GetHashCode();
            int targetBucket = (hashcode & int.MaxValue) % buckets.Length;
            // Search for entry
            for (Entry ent = buckets[targetBucket]; ent != null; ent = ent.Next)
            {
                if (ent.Hashcode == hashcode && ent.Key.Equals(key))
                    return ent;
            }
            return null;
        }

       

}



