namespace NexusKrop.IceCube.Tests;

using NexusKrop.IceCube.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
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
    public void KVC_BinaryFormatTest()
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
            readed = KeyValueContainer.ReadFromFile(mem2);
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