namespace NexusKrop.IceCube.Collections;
using System.Collections.Generic;

/// <summary>
/// Provides methods to assist in creation of lists.
/// </summary>
public static class List
{
    /// <summary>
    /// Creates a new list consisting of the specified <paramref name="values"/>.
    /// </summary>
    /// <typeparam name="T">The type of the list.</typeparam>
    /// <param name="values">The values.</param>
    /// <returns>A list consisting of the <paramref name="values"/>.</returns>
    public static IList<T> Of<T>(params T[] values)
    {
        return new List<T>(values);
    }

    /// <summary>
    /// Creates a new list consisting of the specified <paramref name="value"/>.
    /// </summary>
    /// <typeparam name="T">The type of the list.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>A list consisting of the <paramref name="value"/>.</returns>
    public static IList<T> Of<T>(T value)
    {
        return new List<T>() { value };
    }
}
