namespace NexusKrop.IceCube.Tests;

using NexusKrop.IceCube.IO;

[TestClass]
public class BigEndianIOTest
{
    public const string HELLO_WORLD = "Hello, World!";

    [TestMethod]
    public void BigEndianStringTest()
    {
        byte[] buffer;

        using (var streamA = new MemoryStream())
        {
            var writer = new BigEndianBinaryWriter(streamA);

            writer.Write(HELLO_WORLD);
            buffer = streamA.ToArray();
        }

        string str;

        using (var streamB = new MemoryStream(buffer))
        {
            var reader = new BigEndianBinaryReader(streamB);

            str = reader.ReadString();
        }

        Assert.AreEqual(HELLO_WORLD, str);
    }
}
