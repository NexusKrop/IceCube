namespace NexusKrop.IceCube.Tests;

using NexusKrop.IceCube.Util;

public class UrlPathTests
{
    [Test]
    public void Combine_CompletePath()
    {
        var combineResult = UrlPath.Combine("https://", "example.com", "shutter");

        Assert.That(combineResult, Is.EqualTo("https://example.com/shutter/"));
    }
}
