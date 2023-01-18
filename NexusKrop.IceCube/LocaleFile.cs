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

namespace NexusKrop.IceCube.Localisation;

using SmartFormat;
using System.Text.Json;

/// <summary>
/// Represents a simple locale file.
/// </summary>
public class LocaleFile
{
    internal Dictionary<string, string>? _locale;

    /// <summary>
    /// Asynchronously reads the specified file.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public async Task ReadAsync(string file)
    {
        using var stream = File.OpenRead(file);

        _locale = await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(stream);
    }

    /// <summary>
    /// Gets the specified translation line.
    /// </summary>
    /// <param name="key">The key of the translation line.</param>
    /// <returns>The translation line, if the specified translation line exists; otherwise, the <paramref name="key"/> itself.</returns>
    public string GetLine(string key)
    {
        if (_locale == null)
        {
            return key;
        }

        if (!_locale.TryGetValue(key, out var value))
        {
            return key;
        }

        return value;
    }

    /// <summary>
    /// Gets the specified translation line, and format with <paramref name="values"/>.
    /// </summary>
    /// <param name="key">The key of the translation line.</param>
    /// <param name="values"></param>
    /// <returns>The translation line, formatted with <paramref name="values"/>, if the specified translation line exists; otherwise, the <paramref name="key"/> itself, without formatting.</returns>
    public string GetLineFormat(string key, params string[] values)
    {
        if (_locale == null)
        {
            return key;
        }

        if (!_locale.TryGetValue(key, out var value))
        {
            return key;
        }

        return Smart.Format(value, values);
    }
}
