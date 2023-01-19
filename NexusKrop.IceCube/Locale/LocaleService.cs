namespace NexusKrop.IceCube.Locale;

using NexusKrop.IceCube.Exceptions;
using SmartFormat;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LocaleService
{
    private readonly Dictionary<CultureInfo, LocaleFile> _locales = new();

    public CultureInfo Current { get; set; } = CultureInfo.CurrentCulture;

    public static readonly CultureInfo UnitedStates = new("en-US");

    /// <summary>
    /// Gets the specified translation line.
    /// </summary>
    /// <param name="key">The key of the translation line.</param>
    /// <returns>The translation line, if the specified translation line exists; otherwise, the <paramref name="key"/> itself.</returns>
    public string GetLine(string key)
    {
        if (!_locales.TryGetValue(Current, out LocaleFile? lc)
            && !_locales.TryGetValue(UnitedStates, out lc))
        {
            return key;
        }

        if (lc == null)
        {
            return key;
        }

        return lc.GetLine(key);
    }

    /// <summary>
    /// Gets the specified translation line, and format with <paramref name="values"/>.
    /// </summary>
    /// <param name="key">The key of the translation line.</param>
    /// <param name="values"></param>
    /// <returns>The translation line, formatted with <paramref name="values"/>, if the specified translation line exists; otherwise, the <paramref name="key"/> itself, without formatting.</returns>
    public string GetLineFormat(string key, params string[] values)
    {
        if (!_locales.TryGetValue(Current, out LocaleFile? lc)
            && !_locales.TryGetValue(UnitedStates, out lc))
        {
            return key;
        }

        if (lc == null)
        {
            return key;
        }

        return lc.GetLineFormat(key, values);
    }

    public async Task ReadFromDirectoryAsync(string directory)
    {
        ExceptionHelper.ThrowIfDirectoryNotExist(directory);

        foreach (var file in Directory.GetFiles(directory, "*.json"))
        {
            try
            {
                var culture = new CultureInfo(Path.GetFileNameWithoutExtension(file));
                var lang = new LocaleFile(culture);
                await lang.ReadAsync(file);

                _locales.Add(culture, lang);
            }
            catch (CultureNotFoundException)
            {
                continue;
            }
        }
    }
}
