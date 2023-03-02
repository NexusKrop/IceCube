#if NET7_0_OR_GREATER
#define BIG_ENDIAN
#endif

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

using NexusKrop.IceCube.Data.Values;
using NexusKrop.IceCube.Exceptions;
using NexusKrop.IceCube.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides a key-to-value container that stores primitive types and utilties to store the container
/// in a binary format, as well as reading a binary-formatted container.
/// </summary>
public class KeyValueContainer
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KeyValueContainer"/> class, in a Little Endian format.
    /// </summary>
    public KeyValueContainer()
#if BIG_ENDIAN
        : this(false)
#endif
    {
#if !BIG_ENDIAN
        Contents = new ReadOnlyDictionary<string, ValueType>(_keyValuePair);
#endif
    }

#if BIG_ENDIAN
    /// <summary>
    /// Initializes a new instance of the <see cref="KeyValueContainer" /> class.
    /// </summary>
    /// <param name="bigEndian">If <paramref name="bigEndian"/>, this instance is read and written in Big Endian.</param>
    public KeyValueContainer(bool bigEndian)
    {
        BigEndian = bigEndian;
        Contents = new ReadOnlyDictionary<string, ValueType>(_keyValuePair);
    }
#endif

    /// <summary>
    /// The data version of the key-value containers.
    /// </summary>
    public const int DataVersion = 1;

    private static readonly Dictionary<Type, IContainerValueIO> ValueIO = new()
    {
        { typeof(byte), new UInt8ContainerIO() },
        { typeof(short), new Int16ContainerIO() },
    };

    private readonly Dictionary<string, ValueType> _keyValuePair = new();

#if BIG_ENDIAN
    /// <summary>
    /// Gets or sets a value indicating whether to write in a big-endian format.
    /// </summary>
    public bool BigEndian { get; set; }
#endif

    /// <summary>
    /// Gets the contents of this dictionary.
    /// </summary>
    public IReadOnlyDictionary<string, ValueType> Contents { get; }

    /// <summary>
    /// Adds the specified key-value pair to this container.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <exception cref="ArgumentException"><paramref name="value"/> is not in a primitive type.</exception>
    public void Add(string key, ValueType value)
    {
        if (!ValueIO.ContainsKey(value.GetType()))
        {
            throw new ArgumentException("The type provided is not primitive!", nameof(value));
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

    internal void WriteHeader(IBinaryWriter writer)
    {
        // Magic number
        // 0x3C 'K' 'V' 'C'
        writer.Write((byte)0x3C);
        writer.Write('K');
        writer.Write('V');
        writer.Write('C');

        // Data version
        writer.Write(DataVersion);

        // Endianness indicator
        // For targets do not support BIG_ENDIAN this is simply a false
        // otherwise write if this is created as BigEndian
#if BIG_ENDIAN
        writer.Write(BigEndian);
#else
        writer.Write(false);
#endif

        writer.Write(_keyValuePair.Count);
    }

    /// <summary>
    /// Asynchronously writes this container, in a file format, to the specified file.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public async Task WriteToFileAsync(string file)
    {
        var stream = File.Create(file);

        using var target = stream;
        await WriteToFileAsync(target);
    }

    /// <summary>
    /// Writes this container, in a file format, to the specified stream. This call is not async, but can be awaited.
    /// </summary>
    /// <param name="target">The target.</param>
    public Task WriteToFileAsync(Stream target)
    {
        using var stream = target;

        IBinaryWriter writer;

#if BIG_ENDIAN
        if (BigEndian)
        {
            writer = new BigEndianBinaryWriter(stream);
        }
        else
        {
#endif
            writer = new NBinaryWriter(stream);
#if BIG_ENDIAN
        }
#endif

        WriteHeader(writer);

        // For each item:
        // The key
        // The full name of the type
        // The value
        _keyValuePair.Iterate(x =>
        {
            var type = x.Value.GetType();
            var io = ValueIO[type];

            // This should only be null if it is auto-generated
            Debug.Assert(type.FullName != null);

            writer.Write(x.Key);
            writer.Write(type.FullName);
            io.Write(writer, x.Value);
        });

        return Task.CompletedTask;
    }

    /// <summary>
    /// Writes this container, in a file format, to the specified stream.
    /// </summary>
    /// <param name="target"></param>
    public void WriteToFile(Stream target) => WriteToFileAsync(target).Wait();

    /// <summary>
    /// Writes this container, in a file format, to the specified stream.
    /// </summary>
    /// <param name="file"></param>
    public void WriteToFile(string file) => WriteToFileAsync(file).Wait();

    private static void VerifyMagic(IBinaryReader input, out bool bigEndian)
    {
        using var reader = input;

        // Validate the magic bytes.
        var magic = reader.ReadByte();
        var chA = reader.ReadChar();
        var chB = reader.ReadChar();
        var chC = reader.ReadChar();

        if (magic != 0x3C || chA == 'K' || chB == 'V' || chC == 'C')
        {
            throw new InvalidDataException("The file is not a KVC file.");
        }

        bigEndian = reader.ReadBoolean();
    }

    /// <summary>
    /// Parses a file-format KVC data.
    /// </summary>
    /// <param name="stream">The stream to parse.</param>
    /// <param name="leaveOpen">Whether or not to leave the stream open.</param>
    /// <returns>The parsed KVC data.</returns>
    /// <exception cref="InvalidDataException">The provided data is invalid.</exception>
    public static KeyValueContainer ReadFromFile(Stream stream, bool leaveOpen = false)
    {
        VerifyMagic(new NBinaryReader(stream, Encoding.UTF8, true), out var bigEndian);

#if !BIG_ENDIAN
        if (bigEndian)
        {
            throw new NotSupportedException(ExceptionHelperResources.RuntimeNoBigEndian);
        }
#endif

        var result = new KeyValueContainer();

#if BIG_ENDIAN
        IBinaryReader rd = bigEndian ? new BigEndianBinaryReader(stream, leaveOpen) : new NBinaryReader(stream, Encoding.UTF8, leaveOpen);
#else
        IBinaryReader rd = new NBinaryReader();
#endif

        var amount = rd.ReadInt32();

        for (int i = 0; i < amount; i++)
        {
            var name = rd.ReadString();
            var type = rd.ReadString();

            var actualType = Type.GetType(type);

            if (actualType == null || !ValueIO.ContainsKey(actualType))
            {
                throw new InvalidDataException($"Invalid data type {type} for pair {name}.");
            }

            var value = ValueIO[actualType].Read(rd);

            result.Add(name, value);
        }

        return result;
    }
}
