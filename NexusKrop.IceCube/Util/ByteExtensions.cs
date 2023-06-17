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
/// Provides extensions to <see cref="byte"/>.
/// </summary>
/// <seealso href="https://derekwill.com/2015/03/05/bit-processing-in-c/"/>
public static class ByteExtensions
{
    /// <summary>
    /// Determines whether the specified bit is set to a value equivalent to <c>1</c>.
    /// </summary>
    /// <param name="b">The byte to process.</param>
    /// <param name="pos">A zero-based index indicating the position of the bit. Must be between <c>0</c> and <c>7</c>.</param>
    /// <returns><see langword="true"/> if the specified bit is set to a value equivalent <c>1</c>; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The <paramref name="pos"/> is not within the range of <c>0</c> and <c>7</c>.</exception>
    public static bool IsBitSet(this byte b, int pos)
    {
        if (pos < 0 || pos > 7)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Index must be in the range of 0-7.");
        }

        return (b & (1 << pos)) != 0;
    }

    /// <summary>
    /// Sets the specified bit to a value equivalent to the specified value.
    /// </summary>
    /// <param name="b">The byte to process.</param>
    /// <param name="pos">A zero-based index indicating the position of the bit. Must be between <c>0</c> and <c>7</c>.</param>
    /// <param name="value">The value to set to.</param>
    /// <returns>The byte with the specified bit set.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The <paramref name="pos"/> is not within the range of <c>0</c> and <c>7</c>.</exception>
    public static byte SetBit(this byte b, int pos, bool value)
    {
        if (value)
        {
            return SetBit(b, pos);
        }
        else
        {
            return UnsetBit(b, pos);
        }
    }

    /// <summary>
    /// Sets the specified bit to a value equivalent to <c>1</c>.
    /// </summary>
    /// <param name="b">The byte to process.</param>
    /// <param name="pos">A zero-based index indicating the position of the bit. Must be between <c>0</c> and <c>7</c>.</param>
    /// <returns>The byte with the specified bit set.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The <paramref name="pos"/> is not within the range of <c>0</c> and <c>7</c>.</exception>
    public static byte SetBit(this byte b, int pos)
    {
        if (pos < 0 || pos > 7)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Index must be in the range of 0-7.");
        }

        return (byte)(b | (1 << pos));
    }

    /// <summary>
    /// Sets the specified bit to a value equivalent to <c>0</c>.
    /// </summary>
    /// <param name="b">The byte to process.</param>
    /// <param name="pos">A zero-based index indicating the position of the bit. Must be between <c>0</c> and <c>7</c>.</param>
    /// <returns>The byte with the specified bit set.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The <paramref name="pos"/> is not within the range of <c>0</c> and <c>7</c>.</exception>
    public static byte UnsetBit(this byte b, int pos)
    {
        if (pos < 0 || pos > 7)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Index must be in the range of 0-7.");
        }

        return (byte)(b & ~(1 << pos));
    }

    /// <summary>
    /// Reverses the specified bit between <c>1</c> and <c>0</c>.
    /// </summary>
    /// <param name="b">The byte to process.</param>
    /// <param name="pos">A zero-based index indicating the position of the bit. Must be between <c>0</c> and <c>7</c>.</param>
    /// <returns>The byte with the specified bit set.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The <paramref name="pos"/> is not within the range of <c>0</c> and <c>7</c>.</exception>
    public static byte ToggleBit(this byte b, int pos)
    {
        if (pos < 0 || pos > 7)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Index must be in the range of 0-7.");
        }

        return (byte)(b ^ (1 << pos));
    }

    /// <summary>
    /// Converts the specified <see cref="byte"/> to the string representation of its bits in a binary format.
    /// </summary>
    /// <param name="b">The byte to convert to.</param>
    /// <returns>The string representation of its bits in a binary format.</returns>
    public static string ToBinaryString(this byte b)
    {
        return Convert.ToString(b, 2).PadLeft(8, '0');
    }
}
