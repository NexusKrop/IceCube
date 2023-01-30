namespace NexusKrop.IceCube.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass]
public class CollectionExtensionTest
{
    [TestMethod]
    public void IterateActionTest()
    {
        var iterated = 0;

        var collection = new List<string>()
        {
            "a",
            "b",
            "c",
            "d",
            "e"
        };

        collection.Iterate(x =>
        {
            iterated++;
        });

        Assert.AreEqual(5, iterated);
    }

    [TestMethod]
    public void IterateFuncTest()
    {
        var iterated = 0;

        var collection = new List<string>()
        {
            "a",
            "b",
            "c",
            "d",
            "cancel here",
            "e"
        };

        collection.Iterate(x =>
        {
            iterated++;

            if (x == "cancel here")
            {
                return false;
            }

            return true;
        });

        Assert.AreEqual(5, iterated);
    }
}
