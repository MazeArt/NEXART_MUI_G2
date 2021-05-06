using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShuffleList
{ 
    /// <summary>
    /// Shuffles the element order of the specified list into a new List.
    /// </summary>
    public static List<T> ShuffledList<T>(this IList<T> ts)
    {
        List<T> nList = (List<T>)ts;
        var count = nList.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
        return (List<T>)nList;
    }
}
