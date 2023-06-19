namespace NexusKrop.IceCube.Collections;
using System.Collections.Generic;

/// <summary>
/// Provides utilities for manipulating dictionaries.
/// </summary>
public static class Dictionary
{
    /// <summary>
    /// Creates a dictionary from the specified list of Key-Value pairs.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="pairs">The pairs to create dictionary from.</param>
    /// <returns>A new instance of dictionary.</returns>
    public static IDictionary<TKey, TValue> From<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        where TKey : notnull
    {
        var result = new Dictionary<TKey, TValue>();

        foreach (var pair in pairs)
        {
            result.Add(pair.Key, pair.Value);
        }

        return result;
    }
}
