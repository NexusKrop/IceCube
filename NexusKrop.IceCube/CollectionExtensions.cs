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
using System.Collections;

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
    public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
    {
        foreach (var _ in enumerable)
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
    /// Iterates the specified <paramref name="enumerable"/> with the specified <paramref name="action"/>.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="enumerable"/> to iterate.</typeparam>
    /// <param name="enumerable">The enumerable to iterate.</param>
    /// <param name="action">The action for iteration.</param>
    public static void Iterate<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        ArgumentNullException.ThrowIfNull(enumerable);

        foreach (var x in enumerable)
        {
            action(x);
        }
    }

    /// <summary>
    /// Iterates the specified <paramref name="enumerable"/> with the specified <paramref name="action"/> for all
    /// items that passes the <paramref name="validator"/>.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="enumerable"/> to iterate.</typeparam>
    /// <param name="enumerable">The enumerable to iterate.</param>
    /// <param name="validator">The predicate.</param>
    /// <param name="action">The action for iteration.</param>
    public static void Iterate<T>(this IEnumerable<T> enumerable, Predicate<T> validator, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        ArgumentNullException.ThrowIfNull(enumerable);
        ArgumentNullException.ThrowIfNull(validator);

        foreach (var x in enumerable)
        {
            if (validator(x))
            {
                action(x);
            }
        }
    }
}
