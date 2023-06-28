﻿namespace NexusKrop.IceCube.Util.Enumerables;

using NexusKrop.IceCube.Exceptions;
using System;
using System.Collections.Generic;

/// <summary>
/// Provides extensions to generic types of enumerable.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Determines whether or not the specified <paramref name="enumerable"/> is empty.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="enumerable"/>.</typeparam>
    /// <param name="enumerable">The enumerable to check.</param>
    /// <returns><see langword="true"/> if the <paramref name="enumerable"/> is empty; otherwise, <see langword="false"/>.</returns>
    /// <remarks>
    /// <para>
    /// This method iterates <paramref name="enumerable"/> specified, and whenever it gets something it returns <see langword="true"/>;
    /// if there is nothing to iterate, this method returns <see langword="false"/>. This may seems to harm performance; but actually, the iteration
    /// is executed at most once.
    /// </para>
    /// <para>
    /// However, <see cref="IsEmpty{T}(ICollection{T})"/> is more perferrable if available.
    /// </para>
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S1751:Loops with at most one iteration should be refactored", Justification = "Meant to do so")]
    public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
    {
#if NET7_0_OR_GREATER
        foreach (var _ in Checks.ArgNotNull(enumerable))
#else
        foreach (var _ in Checks.ArgNotNull(enumerable, nameof(enumerable)))
#endif
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the collection is empty.
    /// </summary>
    /// <typeparam name="T">The type of the collection.</typeparam>
    /// <param name="collection">The collection.</param>
    /// <returns><see langword="true"/> if the <paramref name="collection"/> is empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty<T>(this ICollection<T> collection)
    {
        return collection.Count == 0;
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
#if NET7_0_OR_GREATER
        var act = Checks.ArgNotNull(action);
#else
        var act = Checks.ArgNotNull(action, nameof(action));
#endif

#if NET7_0_OR_GREATER
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
#if NET7_0_OR_GREATER
        var act = Checks.ArgNotNull(action);
#else
        var act = Checks.ArgNotNull(action, nameof(action));
#endif

#if NET7_0_OR_GREATER
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