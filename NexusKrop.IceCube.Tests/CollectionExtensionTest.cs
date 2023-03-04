namespace NexusKrop.IceCube.Tests;

using NUnit.Framework;
using System.Collections.Generic;

public class CollectionExtensionTest
{
    [Test]
    public void Iterate_Action()
    {
        var indicesIterated = 0;
        var actualIterated = 0;

        var collection = new List<string>()
        {
            "a",
            "b",
            "c",
            "d",
            "e"
        };

        collection.Iterate((x, i) =>
        {
            indicesIterated = i;
            actualIterated++;
        });

        Assert.Multiple(() =>
        {
            Assert.That(indicesIterated, Is.EqualTo(4));
            Assert.That(actualIterated, Is.EqualTo(5));
        });
    }

    [Test]
    public void Iterate_Func()
    {
        var incides = 0;
        var actualIterated = 0;

        var collection = new List<string>()
        {
            "a",
            "b",
            "cancel",
            "d",
            "e"
        };

        collection.Iterate((x, i) =>
        {
            if (x == "cancel")
            {
                return false;
            }

            incides = i;
            actualIterated++;
            return true;
        });

        Assert.Multiple(() =>
        {
            Assert.That(incides, Is.EqualTo(1));
            Assert.That(actualIterated, Is.EqualTo(2));
        });
    }

    [Test]
    public void ForEach_Action()
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

        collection.ForEach(x =>
        {
            iterated++;
        });

        Assert.That(iterated, Is.EqualTo(5));
    }

    [Test]
    public void ForEach_Func()
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

        collection.ForEach(x =>
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

