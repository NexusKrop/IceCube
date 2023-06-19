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

namespace NexusKrop.IceCube.Tests;

using NexusKrop.IceCube.IO;

public class BigEndianIOTest
{
    public const string HELLO_WORLD = "Hello, World!";

    [Test]
    public void StringReadWriteTest()
    {
        byte[] buffer;

        // Write "Hello, World!" to stream
        using (var streamA = new MemoryStream())
        {
            var writer = new BigEndianBinaryWriter(streamA);

            writer.Write(HELLO_WORLD);
            buffer = streamA.ToArray();
        }

        string str;

        // Read the string from stream
        using (var streamB = new MemoryStream(buffer))
        {
            var reader = new BigEndianBinaryReader(streamB);

            str = reader.ReadString();
        }

        Assert.That(str, Is.EqualTo(HELLO_WORLD));
    }
}