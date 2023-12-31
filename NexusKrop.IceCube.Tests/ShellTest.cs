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

using NexusKrop.IceCube.Util;
using System;
using System.Runtime.Versioning;

public class ShellTest
{
    [Test]
    [SupportedOSPlatform("windows")]
    [SupportedOSPlatform("linux")]
    public void ShellSystemTest()
    {
        if (!OperatingSystem.IsWindows()
    && !OperatingSystem.IsLinux())
        {
            Assert.Warn("Not a supported platform");
            Assert.Pass();
        }

        Assert.DoesNotThrow(() => Shell.System("echo test"));
    }

    [Test]
    [SupportedOSPlatform("windows")]
    [SupportedOSPlatform("linux")]
    public void ShellAvailableTest()
    {
        if (!OperatingSystem.IsWindows()
            && !OperatingSystem.IsLinux())
        {
            Assert.Warn("Not a supported platform");
            Assert.Pass();
        }

        Assert.That(Shell.IsAvailable());
    }
}
