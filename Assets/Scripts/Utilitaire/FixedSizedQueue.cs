using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FixedSizedQueue<T> : IEnumerable
{
    List<T> q;

    public int Limit { get; set; }

    public FixedSizedQueue(int limit)
    {
        q = new List<T>(limit);
        Limit = limit;
    }

    public void Enqueue(T obj)
    {
        lock (this)
        {
            q.Add(obj);
            if(q.Count > Limit)
                q.Remove(q[Limit]);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        lock (this) 
            return q.GetEnumerator();
    }
}
