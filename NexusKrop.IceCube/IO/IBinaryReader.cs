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

namespace NexusKrop.IceCube.IO;

/// <summary>
/// Defines a reader that reads primitive types from any data flow.
/// </summary>
public interface IBinaryReader
{
    /// <summary>
    /// Reads a byte.
    /// </summary>
    /// <returns>The result.</returns>
    byte ReadByte();

    /// <summary>
    /// Reads the specified amount of bytes.
    /// </summary>
    /// <returns>The result.</returns>
    byte[] ReadBytes(int length);

    /// <summary>
    /// Reads a length-prefixed string.
    /// </summary>
    /// <returns>The result.</returns>
    string ReadString();

    /// <summary>
    /// Reads a signed 16-bit integer value.
    /// </summary>
    /// <returns>The result.</returns>
    short ReadInt16();
    /// <summary>
    /// Reads an unsigned 64-bit integer value.
    /// </summary>
    /// <returns>The result.</returns>
    ushort ReadUInt16();

    /// <summary>
    /// Reads a signed 32-bit integer value.
    /// </summary>
    /// <returns>The result.</returns>
    int ReadInt32();

    /// <summary>
    /// Reads an unsigned 32-bit integer value.
    /// </summary>
    /// <returns>The result.</returns>
    uint ReadUInt32();

#if NET6_0_OR_GREATER
    /// <summary>
    /// Reads a signed byte value.
    /// </summary>
    /// <returns>The result.</returns>
    sbyte ReadSByte();
#endif

    /// <summary>
    /// Reads a signed 64-bit integer value.
    /// </summary>
    /// <returns>The result.</returns>
    long ReadInt64();

    /// <summary>
    /// Reads an unsigned 64-bit integer value.
    /// </summary>
    /// <returns>The result.</returns>
    ulong ReadUInt64();

    /// <summary>
    /// Reads a single-percision floating point number.
    /// </summary>
    /// <returns>The result.</returns>
    float ReadSingle();

    /// <summary>
    /// Reads a double-percision floating point number.
    /// </summary>
    /// <returns>The result.</returns>
    double ReadDouble();
}
