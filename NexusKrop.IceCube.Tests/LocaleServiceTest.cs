namespace NexusKrop.IceCube.Tests;

using NexusKrop.IceCube.Locale;
using System.Globalization;

[TestClass]
public class LocaleServiceTest
{
    [TestMethod]
    public async Task ReadFromDirectoryTest()
    {
        var temp = Path.Combine(Path.GetTempPath(), $"LocaleServiceTest-{DateTime.Now.Ticks}");

        if (Directory.Exists(temp))
        {
            Directory.Delete(temp, true);
        }

        Directory.CreateDirectory(temp);
        var service = new LocaleService();

        await File.WriteAllTextAsync(Path.Combine(temp, $"{service.CurrentLanguage}.json"),
    "{\"test_key\":\"test_value\", \"test_key2\": \"test_value2\"}");
        await File.WriteAllTextAsync(Path.Combine(temp, $"en_idonotnowwhatisthis.json"),
            "{\"test_key\":\"test_fail\", \"test_key2\": \"test_fail2\"}");

        await service.ReadFromDirectoryAsync(temp);

        Console.WriteLine(service.CurrentLanguage);

        Assert.AreEqual("test_value", service.GetLine("test_key"));
        Assert.AreEqual("test_value2", service.GetLine("test_key2"));
    }
}
