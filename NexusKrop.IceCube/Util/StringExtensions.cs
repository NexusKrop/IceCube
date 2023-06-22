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

using System;
using System.Text;

/// <summary>
/// Provide utility methods to manipulate strings.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts the specified string to its snake case representation.
    /// </summary>
    /// <param name="str">The string to convert.</param>
    /// <param name="trim">If <see langword="true"/>, additional spaces will be trimmed out.</param>
    /// <returns>The converted string.</returns>
    public static string ToSnakeCase(this string str, bool trim = true)
    {
        // This is a complex StringBuilder implementation of the ToSnakeCase method.
        var sb = new StringBuilder();

        // This variable indicates that the next character encountered will be put to lower case.
        var nextLower = false;

        // This variable indicates that the current character is the first one.
        // Which (L40) prevents an underscore being added before it.
        var first = true;

        var wasCaps = false;

        foreach (var x in str)
        {
            // Do not add underscore if the current one is the first one.
            if (first)
            {
                sb.Append(char.ToLowerInvariant(x));
                wasCaps = char.IsUpper(x);
                first = false;
                continue;
            }

            // If the current character is spacebar, indicate next character as lower case.
            // If already have a spacebar, trim it out.
            if (x == ' ' || x == '_')
            {
                if (nextLower && trim)
                {
                    continue;
                }

                sb.Append('_');
                nextLower = true;
                continue;
            }

            if ((nextLower || wasCaps) && char.IsUpper(x))
            {
                sb.Append(char.ToLowerInvariant(x));
                nextLower = false;
                continue;
            }

            if (char.IsUpper(x))
            {
                wasCaps = true;
                sb.Append('_').Append(char.ToLowerInvariant(x));
                continue;
            }
            else
            {
                wasCaps = false;
            }

            sb.Append(x);
        }

        return sb.ToString().ToLowerInvariant();
    }
}
