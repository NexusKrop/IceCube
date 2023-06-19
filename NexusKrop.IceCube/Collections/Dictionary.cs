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
