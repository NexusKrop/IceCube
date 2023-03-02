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
