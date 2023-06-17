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

namespace NexusKrop.IceCube.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

#if NET6_0_OR_GREATER
[SupportedOSPlatform("windows")]
#endif
internal static partial class MsvcRuntime
{
#if NET7_0_OR_GREATER
    [LibraryImport("msvcrt.dll", SetLastError = true)]
    internal static partial int _wsystem([MarshalAs(UnmanagedType.LPWStr)] string? command);
#else
    [DllImport("msvcrt.dll", SetLastError = true)]
    internal static extern int _wsystem([MarshalAs(UnmanagedType.LPWStr)] string? command);
#endif
}
