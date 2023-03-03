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

namespace NexusKrop.IceCube.Data;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NexusKrop.IceCube.Annotations;
using NexusKrop.IceCube.Data.Values;

/// <summary>
/// Provides a key-to-value container that stores primitive types and utilties to store the container
/// in a binary format, as well as reading a binary-formatted container.
/// </summary>
[ApiStatus(ApiStatus.Unstable)]
public partial class KeyValueContainer
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KeyValueContainer"/> class, in a Little Endian format.
    /// </summary>
    public KeyValueContainer()
    {
        Contents = new ReadOnlyDictionary<string, object>(_keyValuePair);
    }

    private static readonly Dictionary<Type, IContainerValueIO> ValueIO = new()
    {
        { typeof(byte), new UInt8ContainerIO() },
        { typeof(short), new Int16ContainerIO() },
        { typeof(ushort), new UInt16ContainerIO() },
        { typeof(int), new Int32ContainerIO() },
        { typeof(uint), new UInt32ContainerIO() },
        { typeof(long), new Int64ContainerIO() },
        { typeof(ulong), new UInt64ContainerIO() },
        { typeof(float), new SingleContainerIO() },
        { typeof(double), new DoubleContainerIO() },
        { typeof(string), new StringContainerIO() },
        { typeof(bool), new BooleanContainerIO() },

#if NET7_0_OR_GREATER
        { typeof(sbyte), new Int8ContainerIO() }
#endif
    };

    private readonly Dictionary<string, object> _keyValuePair = new();

    /// <summary>
    /// Gets the contents of this dictionary.
    /// </summary>
    public IReadOnlyDictionary<string, object> Contents { get; }

    /// <summary>
    /// Gets or sets the value associated with the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>The value.</returns>
    public object this[string key]
    {
        get => _keyValuePair[key];
        set => Put(key, value);
    }

    /// <summary>
    /// Puts the specified key-value pair into this container.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <exception cref="ArgumentException"><paramref name="value"/> is not in a primitive type.</exception>
    public void Put(string key, object value)
    {
        if (!ValueIO.ContainsKey(value.GetType()))
        {
            throw new ArgumentException("The value provided is not in a primitive type.", nameof(value));
        }

        _keyValuePair[key] = value;
    }

    /// <summary>
    /// Postpends the specified key-value pair to the end of this container.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <exception cref="ArgumentException"><paramref name="value"/> is not in a primitive type.</exception>
    public void Add(string key, object value)
    {
        if (!ValueIO.ContainsKey(value.GetType()))
        {
            throw new ArgumentException("The value provided is not in a primitive type.", nameof(value));
        }

        _keyValuePair.Add(key, value);
    }


    /// <summary>
    /// Removes the key-value pair from this container.
    /// </summary>
    /// <param name="key">The key.</param>
    public void Remove(string key)
    {
        _keyValuePair.Remove(key);
    }
}
