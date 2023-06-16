namespace NexusKrop.IceCube.Util;

/// <summary>
/// Provides methods to manipulate and create instances of array.
/// </summary>
public static class Arrays
{
    /// <summary>
    /// Creates an array of <typeparamref name="T"/> solely consisting of the specified <paramref name="value"/>.
    /// </summary>
    /// <typeparam name="T">The type of the array to create.</typeparam>
    /// <param name="value">The single value of the array.</param>
    /// <returns>The created array consisting of the value specified.</returns>
    public static T[] From<T>(T value)
    {
        return new T[] { value };
    }

    /// <summary>
    /// Creates an array of <typeparamref name="T"/> consisting of the specified <paramref name="values"/>.
    /// </summary>
    /// <typeparam name="T">The type of the array to create.</typeparam>
    /// <param name="values">The values.</param>
    /// <returns>The created array consisting of the values specified.</returns>
    /// <remarks>
    /// <para>
    /// This method simply returns the <see langword="params"/> argument of <paramref name="values"/>, although you can
    /// pass an actual array as an argument, it will be returned as-is.
    /// </para>
    /// </remarks>
    public static T[] From<T>(params T[] values)
    {
        return values;
    }
}
