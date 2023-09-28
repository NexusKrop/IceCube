namespace NexusKrop.IceCube.Util.Enumerables;

using NexusKrop.IceCube.Exceptions;
using System;
using System.Collections.Generic;

/// <summary>
/// Provides extensions to generic types of enumerable.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Determines whether or not the specified <paramref name="enumerable"/> is <see langword="null"/> or empty.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="enumerable"/>.</typeparam>
    /// <param name="enumerable">The enumerable to check.</param>
    /// <returns><see langword="true"/> if the <paramref name="enumerable"/> is empty; otherwise, <see langword="false"/>.</returns>
    /// <remarks>
    /// <para>
    /// If the <paramref name="enumerable"/> is null, this method immediately returns <see langword="null"/>.
    /// </para>
    /// <para>
    /// This method iterates <paramref name="enumerable"/> specified, and whenever it gets something it returns <see langword="true"/>;
    /// if there is nothing to iterate, this method returns <see langword="false"/>. This may seems to harm performance; but actually, the iteration
    /// is executed at most once.
    /// </para>
    /// <para>
    /// However, other reloads of this method is more preferable if available.
    /// </para>
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S1751", Justification = "Meant to do so")]
    public static bool IsEmpty<T>(this IEnumerable<T>? enumerable)
    {
        if (enumerable == null)
        {
            return false;
        }

        foreach (var _ in enumerable)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified collection is <see langword="null"/> empty.
    /// </summary>
    /// <param name="collection">The collection to check.</param>
    /// <returns><see langword="true"/> if the <paramref name="collection"/> is <see langword="null"/> empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty<T>(this ICollection<T>? collection)
    {
        return collection == null || collection.Count == 0;
    }

    /// <summary>
    /// Iterates through the specified <paramref name="array"/> and performs <paramref name="action"/> on each
    /// item of the array. The array may be modified during execution.
    /// </summary>
    /// <typeparam name="T">The type of the array to iterate.</typeparam>
    /// <param name="array">The array to iterate.</param>
    /// <param name="action">The iteration action.</param>
    public static void Iterate<T>(this T[] array, IterationAction<T> action)
    {
        for (int i = 0; i < array.Length; i++)
        {
            action(array[i], i);
        }
    }

    /// <summary>
    /// Iterates through the specified <paramref name="array"/> and performs <paramref name="action"/> on each
    /// item of the array, and aborts (break-out of) the iteration if the <paramref name="action"/> returns <see langword="false"/>.
    /// The array may be modified during execution.
    /// </summary>
    /// <typeparam name="T">The type of the array to iterate.</typeparam>
    /// <param name="array">The array to iterate.</param>
    /// <param name="action">The iteration action. If the action returns <see langword="false"/>, the execution is aborted.</param>
    public static void Iterate<T>(this T[] array, IterationFunc<T> action)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (!action(array[i], i))
            {
                break;
            }
        }
    }

    /// <summary>
    /// Iterates through the specified <paramref name="list"/> and performs <paramref name="action"/> on each
    /// item of the array. The list may be modified during execution.
    /// </summary>
    /// <typeparam name="T">The type of the array to iterate.</typeparam>
    /// <param name="list">The list to iterate.</param>
    /// <param name="action">The iteration action. If the action returns <see langword="false"/>, the execution is aborted.</param>
    public static void Iterate<T>(this IList<T> list, IterationAction<T> action)
    {
        for (int i = 0; i < list.Count; i++)
        {
            action(list[i], i);
        }
    }

    /// <summary>
    /// Iterates through the specified <paramref name="list"/> and performs <paramref name="action"/> on each
    /// item of the array, and aborts (break-out of) the iteration if the <paramref name="action"/> returns <see langword="false"/>.
    /// The list may be modified during execution.
    /// </summary>
    /// <typeparam name="T">The type of the array to iterate.</typeparam>
    /// <param name="list">The list to iterate.</param>
    /// <param name="action">The iteration action. If the action returns <see langword="false"/>, the execution is aborted.</param>
    public static void Iterate<T>(this IList<T> list, IterationFunc<T> action)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!action(list[i], i))
            {
                break;
            }
        }
    }

    /// <summary>
    /// Executes the specified <paramref name="action"/> to each item of the <paramref name="enumerable"/> via its
    /// enumerator.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="enumerable"/> to iterate.</typeparam>
    /// <param name="enumerable">The enumerable to iterate.</param>
    /// <param name="action">The action for iteration.</param>
    /// <exception cref="InvalidOperationException">The <paramref name="enumerable"/> was modified during execution.</exception>
    /// <remarks>
    /// Any modifications to the <paramref name="enumerable"/> specified during execution will cause <see cref="InvalidOperationException"/>
    /// to be thrown.
    /// </remarks>
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
#if NET6_0_OR_GREATER
        var act = Checks.ArgNotNull(action);
#else
        var act = Checks.ArgNotNull(action, nameof(action));
#endif

#if NET6_0_OR_GREATER
        foreach (var x in Checks.ArgNotNull(enumerable))
#else
        foreach (var x in Checks.ArgNotNull(enumerable, nameof(enumerable)))
#endif
        {
            act(x);
        }
    }

    /// <summary>
    /// Executes the specified <paramref name="action"/> to each item of the <paramref name="enumerable"/> via its
    /// enumerator.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="enumerable"/> to iterate.</typeparam>
    /// <param name="enumerable">The enumerable to iterate.</param>
    /// <param name="action">The action for iteration. If the action returns <see langword="false"/>, the iteration will break; otherwise, it continues.</param>
    /// <exception cref="InvalidOperationException">The <paramref name="enumerable"/> was modified during execution.</exception>
    /// <remarks>
    /// Any modifications to the <paramref name="enumerable"/> specified during execution will cause <see cref="InvalidOperationException"/>
    /// to be thrown.
    /// </remarks>
    public static void ForEach<T>(this IEnumerable<T> enumerable, Func<T, bool> action)
    {
#if NET6_0_OR_GREATER
        var act = Checks.ArgNotNull(action);
#else
        var act = Checks.ArgNotNull(action, nameof(action));
#endif

#if NET6_0_OR_GREATER
        foreach (var x in Checks.ArgNotNull(enumerable))
#else
        foreach (var x in Checks.ArgNotNull(enumerable, nameof(enumerable)))
#endif
        {
            if (!act(x))
            {
                break;
            }
        }
    }
}
