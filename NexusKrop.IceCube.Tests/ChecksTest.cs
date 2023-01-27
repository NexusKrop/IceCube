namespace NexusKrop.IceCube.Tests;

using NexusKrop.IceCube.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class ChecksTest
{
    [TestMethod]
    public void ArgNotNull_ThrowsWhenNull()
    {
        var x = Assert.ThrowsException<ArgumentNullException>(() => ArgNotNull_Internal(null));
        Assert.AreEqual("arg", x.ParamName);
    }

    [TestMethod]
    public void ArgNotNullOrEmpty_ThrowsWhenEmpty()
    {
        var x = Assert.ThrowsException<ArgumentException>(() => ArgNotNullOrWhitespace_Internal(string.Empty));
        Assert.AreEqual("arg", x.ParamName);
    }

    [TestMethod]
    public void ArgNotNullOrEmpty_ThrowsWhenWhitespace()
    {
        var x = Assert.ThrowsException<ArgumentException>(() => ArgNotNullOrWhitespace_Internal("    "));
        Assert.AreEqual("arg", x.ParamName);
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