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

namespace NexusKrop.IceCube.Util;
using System.Text;

/// <summary>
/// Provide utilities to manipulate URL paths.
/// </summary>
public static class UrlPath
{
    /// <summary>
    /// Combines two or more URL paths to a single URL path.
    /// </summary>
    /// <param name="parts">The parts of the URL path to combine.</param>
    /// <returns>The combined result.</returns>
    public static string Combine(params string[] parts)
    {
        var builder = new StringBuilder();

        foreach (var part in parts)
        {
            builder.Append(part);

#if NET6_0_OR_GREATER
            if (!part.EndsWith('/'))
#else
            if (!part.EndsWith("/"))
#endif
            {
                builder.Append('/');
            }
        }

        return builder.ToString();
    }
}
