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
