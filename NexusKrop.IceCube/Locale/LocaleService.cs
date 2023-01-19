namespace NexusKrop.IceCube.Locale;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LocaleService
{
    private readonly Dictionary<CultureInfo, LocaleFile> _locales = new();

    public async Task ReadFromDirectoryAsync(string directory)
    {
        if (!Directory.Exists(directory))
        {

        }
    }
}
