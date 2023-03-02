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
/// Defines a <see cref="System.IO.BinaryWriter"/>-like interface.
/// </summary>
public interface IBinaryWriter
{
    /// <inheritdoc cref="System.IO.BinaryWriter.Write(string)"/>
    void Write(string value);

    /// <inheritdoc cref="System.IO.BinaryWriter.Write(byte[])"/>
    void Write(byte[] value);

    /// <inheritdoc cref="System.IO.BinaryWriter.Write(bool)"/>
    void Write(bool value);

    /// <inheritdoc cref="System.IO.BinaryWriter.Write(byte)"/>
    void Write(byte value);

#if NET6_0_OR_GREATER
    /// <inheritdoc cref="System.IO.BinaryWriter.Write(sbyte)"/>
    void Write(sbyte value);
#endif

    /// <inheritdoc cref="System.IO.BinaryWriter.Write(short)"/>
    void Write(short value);
    /// <inheritdoc cref="System.IO.BinaryWriter.Write(ushort)"/>
    void Write(ushort value);
    /// <inheritdoc cref="System.IO.BinaryWriter.Write(int)"/>
    void Write(int value);
    /// <inheritdoc cref="System.IO.BinaryWriter.Write(uint)"/>
    void Write(uint value);
    /// <inheritdoc cref="System.IO.BinaryWriter.Write(long)"/>
    void Write(long value);
    /// <inheritdoc cref="System.IO.BinaryWriter.Write(ulong)"/>
    void Write(ulong value);

    /// <inheritdoc cref="System.IO.BinaryWriter.Write(float)"/>
    void Write(float value);
    /// <inheritdoc cref="System.IO.BinaryWriter.Write(double)"/>
    void Write(double value);
}
