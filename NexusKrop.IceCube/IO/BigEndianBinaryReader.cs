﻿#if NET7_0_OR_GREATER

namespace NexusKrop.IceCube.IO;

using NexusKrop.IceCube.Exceptions;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Read primitive data types as values in Big Endian, and strings in UTF-8.
/// </summary>
public class BigEndianBinaryReader : BinaryReader
{
    private readonly byte[] _buffer;
/// <inheritdoc/>

    public BigEndianBinaryReader(Stream input) : this(input, Encoding.UTF8, false)
    {
    }
/// <inheritdoc/>

    public BigEndianBinaryReader(Stream input, bool leaveOpen) : this(input, Encoding.UTF8, leaveOpen)
    {
    }

    private BigEndianBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
    {
        int minBufferSize = encoding.GetMaxByteCount(1);  // max bytes per one char
        if (minBufferSize < 16)
        {
            minBufferSize = 16;
        }

        _buffer = new byte[minBufferSize];
    }

    private ReadOnlySpan<byte> InternalRead(int numBytes)
    {
        Debug.Assert(numBytes >= 2 && numBytes <= 16, "value of 1 should use ReadByte. value > 16 requires to change the minimal _buffer size");

        BaseStream.ReadExactly(_buffer.AsSpan(0, numBytes));

        return _buffer;
    }
/// <inheritdoc/>

    public override short ReadInt16() => BinaryPrimitives.ReadInt16BigEndian(InternalRead(2));
    /// <inheritdoc/>
    public override ushort ReadUInt16() => BinaryPrimitives.ReadUInt16BigEndian(InternalRead(2));
    /// <inheritdoc/>
    public override int ReadInt32() => BinaryPrimitives.ReadInt32BigEndian(InternalRead(4));
    /// <inheritdoc/>
    public override uint ReadUInt32() => BinaryPrimitives.ReadUInt32BigEndian(InternalRead(4));
    /// <inheritdoc/>
    public override long ReadInt64() => BinaryPrimitives.ReadInt64BigEndian(InternalRead(8));
    /// <inheritdoc/>
    public override ulong ReadUInt64() => BinaryPrimitives.ReadUInt64BigEndian(InternalRead(8));
    /// <inheritdoc/>
    public override Half ReadHalf() => BinaryPrimitives.ReadHalfBigEndian(InternalRead(2));
    /// <inheritdoc/>
    public override float ReadSingle() => BinaryPrimitives.ReadSingleBigEndian(InternalRead(4));
    /// <inheritdoc/>
    public override double ReadDouble() => BinaryPrimitives.ReadDoubleBigEndian(InternalRead(8));
/// <inheritdoc/>

    public override string ReadString()
    {
        var length = ReadInt32();

        var bytes = ReadBytes(length);

        return Encoding.UTF8.GetString(bytes);
    }
}

#endif