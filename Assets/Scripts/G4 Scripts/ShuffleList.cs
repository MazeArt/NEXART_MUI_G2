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
            var tmp = nList[i];
            nList[i] = nList[r];
            nList[r] = tmp;
        }
        return (List<T>)nList;
    }
    /// <summary>
    /// Shuffles the two elements order of the specified list into the same list.
    /// </summary>
    public static void ShuffledTwoListKeepingSamePosition(List<string> lOne, List<Sprite> lTwo)
    {
        //List<T> nList = lOne;
        //List<T> nListTwo = lTwo;
        var count = lOne.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = lOne[i];
            lOne[i] = lOne[r];
            lOne[r] = tmp;
            var tmp2 = lTwo[i];
            lTwo[i] = lTwo[r];
            lTwo[r] = tmp2;
        }
        //return (List<T>)lOne;
    }
}
