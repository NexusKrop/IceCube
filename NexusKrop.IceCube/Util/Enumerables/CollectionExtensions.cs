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

namespace NexusKrop.IceCube.Util.Enumerables;

using System.Collections.Generic;

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
    /// Reverses the keys and values in this instance.
    /// </summary>
    /// <typeparam name="TKey">The original key (new value) of the dictionary.</typeparam>
    /// <typeparam name="TValue">The original value (new key) of the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <returns>The reversed dictionary.</returns>
    public static IDictionary<TValue, TKey> Invert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
    {
        var dict = new Dictionary<TValue, TKey>(dictionary.Count);

        foreach (var pair in dictionary)
        {
            dict.Add(pair.Value, pair.Key);
        }

        return dict;
    }
}
