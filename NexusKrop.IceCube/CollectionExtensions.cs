// Copyright (C) 2023 NexusKrop & contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace NexusKrop.IceCube;

using System;
using System.Collections.Generic;
using NexusKrop.IceCube.Exceptions;

/// <summary>
/// Defines a function that iterates through a list or collection.
/// </summary>
/// <typeparam name="T">The type of the enumeration to iterate.</typeparam>
/// <param name="x">The value of the current entry.</param>
/// <param name="index">The index of the current entry.</param>
/// <returns><see langword="true"/> if the iteration may continue; otherwise, <see langword="false"/>.</returns>
public delegate bool IterationFunc<in T>(T x, int index);

/// <summary>
/// Defines a function that iterates through a list or collection.
/// </summary>
/// <typeparam name="T">The type of the enumeration to iterate.</typeparam>
/// <param name="x">The value of the current entry.</param>
/// <param name="index">The index of the current entry.</param>
public delegate void IterationAction<in T>(T x, int index);

/// <summary>
/// Provides extension methods for collections.
/// </summary>
public static class CollectionExtensions
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
    /// enumerator. This method is deprecated; the <see cref="ForEach{T}(IEnumerable{T}, Action{T})"/> method should be used instead.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="enumerable"/> to iterate.</typeparam>
    /// <param name="enumerable">The enumerable to iterate.</param>
    /// <param name="action">The action for iteration.</param>
    /// <seealso cref="ForEach{T}(IEnumerable{T}, Action{T})"/>
    [Obsolete("Use ForEach instead.")]
    public static void Iterate<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        ForEach(enumerable, action);
    }

    /// <summary>
    /// Executes the specified <paramref name="action"/> to each item of the <paramref name="enumerable"/> via its
    /// enumerator. This method is deprecated; the <see cref="ForEach{T}(IEnumerable{T}, Action{T})"/> method should be used instead.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="enumerable"/> to iterate.</typeparam>
    /// <param name="enumerable">The enumerable to iterate.</param>
    /// <param name="action">The action for iteration. If the action returns <see langword="false"/>, the iteration will break; otherwise, it continues.</param>
    /// <seealso cref="ForEach{T}(IEnumerable{T}, Func{T, bool})"/>
    [Obsolete("Use ForEach instead.")]
    public static void Iterate<T>(this IEnumerable<T> enumerable, Func<T, bool> action)
    {
        ForEach(enumerable, action);
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
