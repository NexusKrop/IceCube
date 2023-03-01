# IceCube

The IceCube project contains common code used by various C# NexusKrop projects,
across different platforms.

## Installation

### NuGet

This is the recommended method.
Newer version can be found in the Packages page (if theres none means we have not yet released one).

This is a package currently only for internal usage but it will be released on `nuget.org` whenever any other package requires it.

### Building from Source

#### Via .NET CLI

- Open project folder, open your terminal.
- Make sure [.NET 7 SDK](https://dotnet.microsoft.com) or later is installed.
- Run `dotnet build` in your terminal.
- Binaries should be available in `NexusKrop.IceCube/bin`.

#### Via Visual Studio

- Make sure you have Visual Studio 2022 installed with .NET Desktop Development workload, and .NET 7 SDK.
- Open solution with Visual Studio 2022.
- Click `Build -> Build Solution`.
- Binaries should be available in `NexusKrop.IceCube/bin`.

### Via other tools

Follow your IDE/tool instructions to build this project.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update [tests](NexusKrop.IceCube.Tests) as appropriate.

For more information, please check the [CONTRIBUTING](CONTRIBUTING.md) file.

## Licence

[Apache-2.0](LICENSE.txt)