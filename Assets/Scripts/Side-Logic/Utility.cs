﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public static class Utility
{
    public static T Log<T>(T value, string prefix = "")
    {
        //    Debug.Log(prefix + value);
        return value;
    }

    public static IEnumerable<T> Generate<T>(T seed, Func<T, T> mutate)
    {
        var accum = seed;
        while (true)
        {
            yield return accum;
            accum = mutate(accum);
        }
    }

    public static bool In<T>(this T x, HashSet<T> set)
    {
        return set.Contains(x);
    }

    public static bool In<K, V>(this KeyValuePair<K, V> x, Dictionary<K, V> dict)
    {
        return dict.Contains(x);
    }

    public static void UpdateWith<K, V>(this Dictionary<K, V> a, Dictionary<K, V> b)
    {
        foreach (var kvp in b)
        {
            a[kvp.Key] = kvp.Value;
        }
    }

    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> list)
    {
        return new HashSet<T>(list);
    }

    public static V DefaultGet<K, V>(
        this Dictionary<K, V> dict,
        K key,
        Func<V> defaultFactory
    )
    {
        V v;
        if (!dict.TryGetValue(key, out v))
            dict[key] = v = defaultFactory();
        return v;
    }

    public static int[] xMoveVector8 = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };
    public static int[] yMoveVector8 = new int[] { 1, 1, 0, -1, -1, -1, 0, 1 };

    public static int Clampi(int v, int min, int max)
    {
        return v < min ? min : (v > max ? max : v);
    }

    public static bool InRangeSquared(Vector3 destiny, Vector3 origen, float distance)
    {
        return (destiny - origen).sqrMagnitude < distance * distance;
    }

    public static T GetComponentCustom <T> (string type, MonoBehaviour from) where T: MonoBehaviour
    {
        return from.GetComponent(type) as T;
    }

    public static T GetComponentCustomCasted<T>(string type, MonoBehaviour from)
    {
        return Cast<T> (from.GetComponent(type));
    }

    public static T Cast<T>(object o)
    {
        return (T)o;
    }

    public static Vector3 SetYInVector3(Vector3 vec, float y)
    {
        return new Vector3(vec.x, y, vec.z);
    }
}
