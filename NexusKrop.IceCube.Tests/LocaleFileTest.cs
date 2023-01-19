namespace NexusKrop.IceCube.Tests;

using NexusKrop.IceCube.Locale;

[TestClass]
public class LocaleFileTest
{
    [TestMethod]
    public void LocaleFileAcquireTest()
    {
        var file = new LocaleFile("en-GB");

        file.Add("test_key", "test_value");

        Assert.AreEqual("test_value", file.GetLine("test_key"));
    }

    [TestMethod]
    public void LocalFileNumericFormatTest()
    {
        var file = new LocaleFile("en-GB");
        file.Add("test_key", "test_value{0}");

        Assert.AreEqual("test_valueABCD", file.GetLineFormat("test_key", "ABCD"));
    }

    [TestMethod]
    public async Task LocalFileReadFromFileTest()
    {
        var tempFile = Path.GetTempFileName();

        await File.WriteAllTextAsync(tempFile, "{\"test_key\":\"test_value\", \"test_key2\": \"test_value2\"}");

        var file = new LocaleFile("en-GB");
        await file.ReadAsync(tempFile);

        Assert.AreEqual("test_value", file.GetLine("test_key"));
        Assert.AreEqual("test_value2", file.GetLine("test_key2"));
    }
}