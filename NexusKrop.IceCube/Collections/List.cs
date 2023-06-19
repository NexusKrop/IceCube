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
