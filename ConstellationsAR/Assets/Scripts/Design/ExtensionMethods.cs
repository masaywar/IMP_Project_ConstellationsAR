using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Text;
using System;

public static class ExtensionMethods
{
    public static void ForEach<T>(this IEnumerable<T> source, System.Action<T> action)
    {
        foreach (var e in source)
            action(e);
    }

    public static IEnumerable<T> SubArray<T>(this IEnumerable<T> source, int start, int count)
    {
        return source.Skip(start).Take(count);
    }

    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>("{\"items\":" + json + "}");
        return wrapper.items;
    }

    public static string LoadJson(string path, string fileName)
    {
        return File.ReadAllText(path + "/" + fileName);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }
}

