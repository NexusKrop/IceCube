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

namespace NexusKrop.IceCube.Data.Values;

using NexusKrop.IceCube.IO;
using System;

internal class UInt16ContainerIO : IContainerValueIO
{
    public object Read(IBinaryReader reader)
    {
        return reader.ReadUInt16();
    }

    public void Write(IBinaryWriter writer, object o)
    {
        if (o is not ushort value)
        {
            throw new ArgumentException("Value is not UInt16", nameof(o));
        }

        writer.Write(value);
    }
}
