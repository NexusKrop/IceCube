# IceCube

IceCube is a library written to simpify some of the boilerplate
codes, and makes your life easier by providing utility methods to help you
create commonly created collections, as well as providing API sugars to simpify
some API usages.

This library compiles natively to most .NET frameworks, and also compiles to
.NET Standard library to support more .NET frameworks.

## Features

- Exception throwing utilities
- Simplified creation of some collections (Lists, Dictionaries, etc.)
- Binary-formatted Key-to-primitive-value dictionary
- Big Endian binary support
- Exception throwing utilities
- Process utilities such as ending a process gracefully and `ShellExecute`
- Many more...

## Installation

### NuGet

This is the recommended method.

- with .NET CLI: `dotnet add package NexusKrop.IceCube`
- with VS GUI: Search `NexusKrop.IceCube` with "Include prerelease" option ticked.
- with VS Package Manager Console: `NuGet\Install-Package NexusKrop.IceCube`

See [the NuGet.org page](https://www.nuget.org/packages/NexusKrop.IceCube) for latest version and more installation methods.

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