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

#if NET7_0_OR_GREATER

namespace NexusKrop.IceCube.IO;

using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;

/// <summary>
/// Writes primitive types in binary to a stream, in Big Endian format, and supports writing strings in
/// UTF-8 encoding.
/// </summary>
public sealed class BigEndianBinaryWriter : BinaryWriter, IBinaryWriter
{
    /// <inheritdoc/>
    public BigEndianBinaryWriter(Stream output) : base(output)
    {
    }
    /// <inheritdoc/>

    public BigEndianBinaryWriter(Stream output, Encoding encoding) : base(output, encoding)
    {
    }
    /// <inheritdoc/>

    public BigEndianBinaryWriter(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen)
    {
    }
    /// <inheritdoc/>

    protected BigEndianBinaryWriter()
    {
    }
    /// <inheritdoc/>

    public override void Write(double value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];
        BinaryPrimitives.WriteDoubleBigEndian(buffer, value);
        OutStream.Write(buffer);
    }
    /// <inheritdoc/>

    public override void Write(short value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];
        BinaryPrimitives.WriteInt16BigEndian(buffer, value);
        OutStream.Write(buffer);
    }
    /// <inheritdoc/>

    public override void Write(ushort value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];
        BinaryPrimitives.WriteUInt16BigEndian(buffer, value);
        OutStream.Write(buffer);
    }
    /// <inheritdoc/>

    public override void Write(int value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];
        BinaryPrimitives.WriteInt32BigEndian(buffer, value);
        OutStream.Write(buffer);
    }
    /// <inheritdoc/>

    public override void Write(uint value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];
        BinaryPrimitives.WriteUInt32BigEndian(buffer, value);
        OutStream.Write(buffer);
    }
    /// <inheritdoc/>
    public override void Write(long value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];
        BinaryPrimitives.WriteInt64BigEndian(buffer, value);
        OutStream.Write(buffer);
    }
    /// <inheritdoc/>

    public override void Write(ulong value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        BinaryPrimitives.WriteUInt64BigEndian(buffer, value);
        OutStream.Write(buffer);
    }
    /// <inheritdoc/>

    public override void Write(float value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];
        BinaryPrimitives.WriteSingleBigEndian(buffer, value);
        OutStream.Write(buffer);
    }
    /// <inheritdoc/>

    public override void Write(Half value)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort) /* = sizeof(Half) */];
        BinaryPrimitives.WriteHalfBigEndian(buffer, value);
        OutStream.Write(buffer);
    }
    /// <inheritdoc/>

    public override void Write(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Write(bytes.Length);
        Write(bytes);
    }
}

#endif