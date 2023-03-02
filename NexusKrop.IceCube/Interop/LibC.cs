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

#if NET6_0_OR_GREATER
using System.Runtime.Versioning;
#endif
using System.Runtime.InteropServices;

#if NET6_0_OR_GREATER
[SupportedOSPlatform("linux")]
#endif
internal static class LibC
{
    [DllImport("libc.so.6", SetLastError = true)]
    internal static extern int kill(int pid, int signum);
}
