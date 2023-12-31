﻿// Copyright (C) 2023 NexusKrop & contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace NexusKrop.IceCube.Tests;

using NexusKrop.IceCube.Util.Enumerables;
using NUnit.Framework;
using System.Collections.Generic;

public class CollectionExtensionTest
{
    [Test]
    public void IsEmpty_EmptyArray()
    {
        var emptyArray = Array.Empty<int>();

        Assert.That(emptyArray.IsEmpty(), Is.True);
    }

    [Test]
    public void IsEmpty_NullList()
    {
        List<int>? nullList = null;

        Assert.That(nullList.IsEmpty(), Is.True);
    }

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

