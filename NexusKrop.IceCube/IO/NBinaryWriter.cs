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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A <see cref="BinaryWriter"/> that implements <see cref="IBinaryWriter"/>.
/// </summary>
public sealed class NBinaryWriter : BinaryWriter, IBinaryWriter
{
    /// <inheritdoc />
    public NBinaryWriter(Stream output) : base(output)
    {
    }

    /// <inheritdoc />
    public NBinaryWriter(Stream output, Encoding encoding) : base(output, encoding)
    {
    }

    /// <inheritdoc />
    public NBinaryWriter(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen)
    {
    }

    /// <inheritdoc />
    protected NBinaryWriter()
    {
    }
}
