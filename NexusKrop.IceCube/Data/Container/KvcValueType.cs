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

namespace NexusKrop.IceCube.Data.Container;

/// <summary>
/// Indicates the type of the value stored in a binary-formatted <see cref="KeyValueContainer"/>.
/// </summary>
public enum KvcValueType
{
    /// <summary>
    /// An unsigned byte.
    /// </summary>
    Byte,
#if NET7_0_OR_GREATER
    /// <summary>
    /// A signed byte.
    /// </summary>
    SByte,
#endif
    /// <summary>
    /// A text character.
    /// </summary>
    Char,
    /// <summary>
    /// Signed 16-bit integer.
    /// </summary>
    Int16,
    /// <summary>
    /// Unsigned 16-bit integer.
    /// </summary>
    UInt16,
    /// <summary>
    /// Signed 32-bit integer.
    /// </summary>
    Int32,
    /// <summary>
    /// Unsigned 32-bit integer.
    /// </summary>
    UInt32,
    /// <summary>
    /// Signed 64-bit integer.
    /// </summary>
    Int64,
    /// <summary>
    /// Unsigned 64-bit integer.
    /// </summary>
    UInt64,
    /// <summary>
    /// An UTF-8 string, prepended with length.
    /// </summary>
    String,
    /// <summary>
    /// A boolean value.
    /// </summary>
    Boolean,
    /// <summary>
    /// A single-percision floating point number.
    /// </summary>
    Single,
    /// <summary>
    /// A double-percision floating point number.
    /// </summary>
    Double
}
