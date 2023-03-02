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

using System.IO;
using System.Text;

/// <summary>
/// A <see cref="BinaryReader"/> that implements <see cref="IBinaryReader"/>.
/// </summary>
public sealed class NBinaryReader : BinaryReader, IBinaryReader
{
    /// <inheritdoc />
    public NBinaryReader(Stream input) : base(input)
    {
    }

    /// <inheritdoc />
    public NBinaryReader(Stream input, Encoding encoding) : base(input, encoding)
    {
    }

    /// <inheritdoc />
    public NBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
    {
    }
}
