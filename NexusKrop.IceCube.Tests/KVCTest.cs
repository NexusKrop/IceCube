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

using NexusKrop.IceCube.Data.Container;
using System.Threading.Tasks;

public class KVCTest
{
    private static readonly KeyValueContainer SampleContainer = new();

    static KVCTest()
    {
        SampleContainer.Add("string", "value");
        SampleContainer.Add("int", 1);
        SampleContainer.Add("long", 2L);
        SampleContainer.Add("float", 3F);
        SampleContainer.Add("double", 4D);
        SampleContainer.Add("byte", (byte)5);
        SampleContainer.Add("uint", 6u);
        SampleContainer.Add("ulong", 7uL);
        SampleContainer.Add("sbyte", (sbyte)8);
        SampleContainer.Add("bool", true);
        SampleContainer.Add("short", (short)10);
        SampleContainer.Add("ushort", (ushort)11);
    }

    [Test]
    public async Task KVC_RawFormatTest()
    {
        byte[] buffer;

        KeyValueContainer readed;

        using (var mem = new MemoryStream())
        {
            await SampleContainer.WriteRawAsync(mem);
            buffer = mem.ToArray();
        }

        using (var mem2 = new MemoryStream(buffer))
        {
            readed = await KeyValueContainer.ReadRawAsync(mem2);
        }

        foreach (var value in readed.Contents)
        {
            Assert.Multiple(() =>
            {
                Assert.That(SampleContainer.Contents.ContainsKey(value.Key), Is.True);
                Assert.That(value.Value, Is.EqualTo(SampleContainer[value.Key]));
            });
        }
    }

    [Test]
    public async Task KVC_FileFormatTest()
    {
        byte[] buffer;

        KeyValueContainer readed;

        using (var mem = new MemoryStream())
        {
            SampleContainer.WriteToFile(mem);
            buffer = mem.ToArray();
        }

        using (var mem2 = new MemoryStream(buffer))
        {
            readed = await KeyValueContainer.ReadFromFile(mem2);
        }

        foreach (var value in readed.Contents)
        {
            Assert.Multiple(() =>
            {
                Assert.That(SampleContainer.Contents.ContainsKey(value.Key), Is.True);
                Assert.That(value.Value, Is.EqualTo(SampleContainer[value.Key]));
            });
        }
    }
}