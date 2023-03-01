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