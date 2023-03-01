namespace NexusKrop.IceCube.Tests;

using NexusKrop.IceCube.Exceptions;
using System;

public class ChecksTest
{
    [Test]
    public void ArgNotNull_ThrowsWhenNull()
    {
        var x = Assert.Throws<ArgumentNullException>(() => ArgNotNull_Internal(null));
        Assert.That(x.ParamName, Is.EqualTo("arg"));
    }

    [Test]
    public void ArgNotNullOrEmpty_ThrowsWhenEmpty()
    {
        var x = Assert.Throws<ArgumentException>(() => ArgNotNullOrWhitespace_Internal(string.Empty));
        Assert.That(x.ParamName, Is.EqualTo("arg"));
    }

    [Test]
    public void ArgNotNullOrEmpty_ThrowsWhenWhitespace()
    {
        var x = Assert.Throws<ArgumentException>(() => ArgNotNullOrWhitespace_Internal("    "));
        Assert.That(x.ParamName, Is.EqualTo("arg"));
    }

    [Test]
    public void FileExists_ThrowsIfNotExist()
    {
        Assert.Throws<FileNotFoundException>(() =>
            Checks.FileExists("/asdasd/as/f/as/fas/d/asd/as/ds/"));
    }

    [Test]
    public void DirectoryExists_ThrowsIfNotExist()
    {
        Assert.Throws<DirectoryNotFoundException>(() =>
            Checks.DirectoryExists("/asdf/ew/g/rr/a/e/gwe/fw/ef"));
    }

    [Test]
    public void OsPlatformCheckTest()
    {
        if (OperatingSystem.IsWindows())
        {
            Checks.OnWindows();
        }
        else if (OperatingSystem.IsLinux())
        {
            Checks.OnLinux();
        }
        else
        {
            Assert.Fail("Unknown OS platform.");
        }
    }

    private static void ArgNotNullOrWhitespace_Internal(string? arg)
    {
        Checks.ArgNotNullOrWhitespace(arg);
    }

    private static void ArgNotNull_Internal(string? arg)
    {
        Checks.ArgNotNull(arg);
    }
}
