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

namespace NexusKrop.IceCube.Locale;

using NexusKrop.IceCube.Exceptions;
using SmartFormat;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

/// <summary>
/// Represents a simple locale file.
/// </summary>
public class LocaleFile
{
    internal Dictionary<string, string>? _locale;

    public string Language { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LocaleFile"/> class.
    /// </summary>
    /// <param name="languageName">The name of the language to associate with the instance.</param>
    /// <exception cref="ArgumentException">The <paramref name="languageName"/> is empty.</exception>
    /// <exception cref="ArgumentNullException">The <paramref name="languageName"/> is <see langword="null"/>.</exception>
    public LocaleFile(string languageName)
    {
        Checks.NotNullOrWhitespace(languageName, nameof(languageName));

        Language = languageName;
    }

    /// <summary>
    /// Adds the specified key to this locale file.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public void Add(string key, string value)
    {
        _locale ??= new();
        _locale.Add(key, value);
    }

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
