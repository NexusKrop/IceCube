# IceCube

![GitHub top language](https://img.shields.io/github/languages/top/NexusKrop/IceCube?label=%20&logo=csharp&style=flat-square)
![GitHub tag (latest SemVer)](https://img.shields.io/github/v/tag/NexusKrop/IceCube?color=gray&label=%20&logo=git&logoColor=white&sort=semver&style=flat-square)
![MyGet](https://img.shields.io/myget/nexuskrop/v/NexusKrop.IceCube?color=gray&label=%20&logo=nuget&style=flat-square)
![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/NexusKrop/IceCube/dotnet.yml?logo=github&style=flat-square)

The IceCube project contains common code used by various C# NexusKrop projects,
across different platforms.

## Installation

### Via NuGet

All prebuilt binaries are uploaded to our [MyGet feed](https://www.myget.org/feed/Details/nexuskrop).

### Building from Source

**Via Command line**
- Open project folder, open your terminal.
- Make sure [.NET 6.0 SDK](https://dotnet.microsoft.com) or later is installed.
- Run `dotnet build` in your terminal.
- Binaries should be available in `NexusKrop.IceCube/bin`.

**Via Visual Studio**
- Make sure you have Visual Studio 2022 installed with .NET Desktop Development workload, and .NET 7 SDK.
- Open solution with Visual Studio 2022.
- Click `Build -> Build Solution`.
- Binaries should be available in `NexusKrop.IceCube/bin`.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update [tests](NexusKrop.IceCube.Tests) as appropriate.

## Licence

[Apache-2.0](LICENSE.txt)