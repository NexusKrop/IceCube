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
#if NET_70_OR_GREATER
        foreach (var _ in Checks.ArgNotNull(enumerable))
#else
#pragma warning disable S3236 // Caller information arguments should not be provided explicitly
        foreach (var _ in Checks.ArgNotNull(enumerable, nameof(enumerable)))
#endif
        {
            return true;
        }
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly

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
    /// Iterates the specified <paramref name="enumerable"/> with the specified <paramref name="action"/>.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="enumerable"/> to iterate.</typeparam>
    /// <param name="enumerable">The enumerable to iterate.</param>
    /// <param name="action">The action for iteration.</param>
    public static void Iterate<T>(this IEnumerable<T> enumerable, Action<T> action)
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
    /// Iterates the specified <paramref name="enumerable"/> with the specified <paramref name="action"/>, and <see langword="break"/>s the iteration
    /// if <paramref name="action"/> returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="enumerable"/> to iterate.</typeparam>
    /// <param name="enumerable">The enumerable to iterate.</param>
    /// <param name="action">The action for iteration. If the action returns <see langword="false"/>, the iteration will break; otherwise, it continues.</param>
    public static void Iterate<T>(this IEnumerable<T> enumerable, Func<T, bool> action)
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
