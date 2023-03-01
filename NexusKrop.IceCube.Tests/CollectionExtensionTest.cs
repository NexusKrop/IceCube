namespace NexusKrop.IceCube.Tests;

using NUnit.Framework;
using System.Collections.Generic;

public class CollectionExtensionTest
{
    [Test]
    public void Iterate_Action()
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

        Assert.That(iterated, Is.EqualTo(5));
    }

    [Test]
    public void Iterate_Func()
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

        Assert.That(iterated, Is.EqualTo(5));
    }
}

