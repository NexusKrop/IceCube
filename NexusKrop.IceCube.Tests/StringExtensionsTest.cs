// Copyright (C) 2023 NexusKrop & contributors
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

using NexusKrop.IceCube.Util;

public class StringExtensionsTest
{
    [Test]
    public void ToSnakeCase_FromPascal()
    {
        Assert.That("PascalCase".ToSnakeCase(), Is.EqualTo("pascal_case"));
    }

    [Test]
    public void ToSnakeCase_FromScream()
    {
        Assert.That("SCREAM_CASE".ToSnakeCase(), Is.EqualTo("scream_case"));
    }

    [Test]
    public void ToSnakeCase_FromCamel()
    {
        Assert.That("camelCase".ToSnakeCase(), Is.EqualTo("camel_case"));
    }

    [Test]
    public void ToSnakeCase_FromTitle()
    {
        Assert.That("Title Case".ToSnakeCase(), Is.EqualTo("title_case"));
    }

    [Test]
    public void ToSnakeCase_FromSentence()
    {
        Assert.That("Sentence case".ToSnakeCase(), Is.EqualTo("sentence_case"));
    }

    [Test]
    public void ToSnakeCase_FromSentenceTrim()
    {
        Assert.That("Sentence    case".ToSnakeCase(), Is.EqualTo("sentence_case"));
    }

    [Test]
    public void ToSnakeCase_FromSentenceNoTrim()
    {
        Assert.That("Sentence    case".ToSnakeCase(false), Is.EqualTo("sentence____case"));
    }
}
