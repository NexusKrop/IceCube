namespace NexusKrop.IceCube.Data;

using NexusKrop.IceCube.IO;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public partial class KeyValueContainer
{
    /// <summary>
    /// The data version of the key-value containers.
    /// </summary>
    public const int DataVersion = 1;

    #region Internal Write Helper

    internal static void WriteFileHeader(IBinaryWriter writer)
    {
        // Magic number
        // 0x3C 0x3F
        writer.Write((byte)0x3C);
        writer.Write((byte)0x3F);

        // Data version
        writer.Write(DataVersion);
    }

    private Task WriteEntries(IBinaryWriter writer)
    {
        try
        {
            // For each item:
            // The key
            // The full name of the type
            // The value
            _keyValuePair.Iterate(x =>
            {
                var type = x.Value.GetType();
                var io = ValueIO[type];

                // This should only be null if it is auto-generated
                Debug.Assert(type.FullName != null);

                writer.Write(x.Key);
                writer.Write((byte)KvcTypeService.KvcTypeValues[type]);
                io.Write(writer, x.Value);
            });
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }

        return Task.CompletedTask;
    }

    #endregion

    #region Internal Read Helper

    private static void VerifyHeader(IBinaryReader reader)
    {
        // Validate the magic bytes.
        var magicA = reader.ReadByte();
        var magicB = reader.ReadByte();

        if (magicA != 0x3C || magicB != 0x3F)
        {
            throw new InvalidDataException("The file is not a KVC file.");
        }

        var version = reader.ReadInt32();

        if (version != DataVersion)
        {
            throw new InvalidDataException($"KVC Data version is incorrect. Excepted {DataVersion} but got version {version}");
        }
    }

    private static async Task<KeyValueContainer> ReadRawInternal(IBinaryReader reader)
    {
        var result = new KeyValueContainer();
        var amount = reader.ReadInt32();

        await ReadEntries(amount, reader, result);
        return result;
    }


    private static Task ReadEntries(int amount, IBinaryReader rd, KeyValueContainer result)
    {
        try
        {
            for (int i = 0; i < amount; i++)
            {
                var name = rd.ReadString();
                var typeId = rd.ReadByte();

                var type = KvcTypeService.KvcValueTypes[(KvcValueType)typeId];

                if (type == null || !ValueIO.ContainsKey(type))
                {
                    throw new InvalidDataException($"Invalid data type {type} for pair {name}.");
                }

                var value = ValueIO[type].Read(rd);

                result.Add(name, value);
            }
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }

        return Task.CompletedTask;
    }

    #endregion

    #region Write Raw Format
    /// <summary>
    /// Asynchronously writes this container, in raw format, to the specified stream.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <param name="leaveOpen">If <see langword="true"/>, the stream will be left open after the operation is complete.</param>
    public async Task WriteRawAsync(Stream target, bool leaveOpen = false)
    {
        using var writer = new NBinaryWriter(target, Encoding.UTF8, leaveOpen);

        writer.Write(_keyValuePair.Count);
        await WriteEntries(writer);
    }
    #endregion

    #region Write File Format
    /// <summary>
    /// Asynchronously writes this container, in a file format, to the specified file.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public async Task WriteToFileAsync(string file)
    {
        var stream = File.Create(file);

        using var target = stream;
        await WriteToFileAsync(target);
    }


    /// <summary>
    /// Writes this container, in a file format, to the specified stream.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <param name="leaveOpen">If <see langword="true"/>, the stream will be left open after the operation is complete.</param>
    public async Task WriteToFileAsync(Stream target, bool leaveOpen = false)
    {
        using var writer = new NBinaryWriter(target, Encoding.UTF8, leaveOpen);

        WriteFileHeader(writer);
        writer.Write(_keyValuePair.Count);
        await WriteEntries(writer);
    }

    /// <summary>
    /// Writes this container, in a file format, to the specified stream.
    /// </summary>
    /// <param name="target"></param>
    public void WriteToFile(Stream target) => WriteToFileAsync(target).Wait();

    /// <summary>
    /// Writes this container, in a file format, to the specified stream.
    /// </summary>
    /// <param name="file"></param>
    public void WriteToFile(string file) => WriteToFileAsync(file).Wait();

    #endregion

    #region Read File Format
    /// <summary>
    /// Parses a file-format KVC data.
    /// </summary>
    /// <param name="stream">The stream to parse.</param>
    /// <param name="leaveOpen">Whether or not to leave the stream open.</param>
    /// <returns>The parsed KVC data.</returns>
    /// <exception cref="InvalidDataException">The KVC file is invalid. -or- One or more of the KVC entries are invalid.</exception>
    public static async Task<KeyValueContainer> ReadFromFile(Stream stream, bool leaveOpen = false)
    {
        IBinaryReader rd = new NBinaryReader(stream, Encoding.UTF8, leaveOpen);

        VerifyHeader(rd);
        return await ReadRawInternal(rd);
    }
    #endregion

    #region Read Raw Format
    /// <summary>
    /// Parses raw KVC data from the specified buffer.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <returns>The parsed <see cref="KeyValueContainer"/>.</returns>
    /// <exception cref="InvalidDataException">One or more of the KVC entries are invalid.</exception>
    public static async Task<KeyValueContainer> ReadRaw(byte[] buffer)
    {
        using var memory = new MemoryStream(buffer);
        return await ReadRawAsync(memory);
    }

    /// <summary>
    /// Parses raw KVC data from the specified stream.
    /// </summary>
    /// <param name="stream">The stream to read.</param>
    /// <param name="leaveOpen">If <see langword="true"/>, the stream will be left open after the operation is complete.</param>
    /// <returns>The parsed <see cref="KeyValueContainer"/>.</returns>
    /// <exception cref="InvalidDataException">One or more of the KVC entries are invalid.</exception>
    public static async Task<KeyValueContainer> ReadRawAsync(Stream stream, bool leaveOpen = false)
    {
        return await ReadRawInternal(new NBinaryReader(stream, Encoding.UTF8, leaveOpen));
    }
    #endregion
}
