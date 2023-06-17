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

namespace NexusKrop.IceCube.Util;

using System;

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
    public static T[] Of<T>(T value)
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
    public static T[] Of<T>(params T[] values)
    {
        return values;
    }

    /// <summary>
    /// Creates an array of <typeparamref name="T"/> solely consisting of the specified <paramref name="value"/>.
    /// </summary>
    /// <typeparam name="T">The type of the array to create.</typeparam>
    /// <param name="value">The single value of the array.</param>
    /// <returns>The created array consisting of the value specified.</returns>
    [Obsolete("Use Of method instead.")]
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
    [Obsolete("Use Of method instead.")]
    public static T[] From<T>(params T[] values)
    {
        return values;
    }
}
