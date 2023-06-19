# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

All dates are in UTC+8 unless otherwise specified.

## [Unreleased]

## [0.3.1-alpha] - 2023/6/19

### Added

- Added Visual Basic wrapper modules as a seperate package
- Added `Dictionary.Of` and `List.Of` creation helpers that works similar to `Arrays.Of` but for lists and dictionaries

### Changed

- Renamed `Arrays.From` to `Arrays.Of` and deprecated the old one

## [0.3.0-alpha] - 2023/6/16

This is a major release that adds new utility methods and changed existing API definitions.
Please be noted that there are multiple breaking changes in this version.

### Added

- Added new Iterate functions which are for-based, and provides index, plus allowing modification of the collection during operation
- Added new `Throws` class to create exception instances for throwing
- Added new `Shell` class for interaction with the command-line or GUI shell
    - Added `Shell.System` and `Shell.IsAvailable`
- Added `ByteExtensions` class to operate bits in a byte
- Added new `UrlPath` class with URL processing utilities
- Added `IterationFunc` and `IterationAction` as delegates for iteration

### Changed

- Renamed old `foreach`-based Iterate functions to `ForEach`
- Deprecated old Iterate functions (they are now wrappers to ForEach).
- Made `Checks` functions to make use of `Throws` instead of creating one directly
- Move `ProcessUtil.ShellExecute` to `Shell.ShellExecute`

### Fixed

- Fixed a build failure in `ProcessUtil`

## [0.2.0-alpha] - 2023/3/3

### Added

- Added Key-to-Value Container that can be formatted as binary, and stores primitive data
- Added annotation attribute `ApiStatus` to indicate the status of an API
- Added `TypeExtensions` class
- Added `IsPrimitive` extension method for types to check if the type is primitive
- Added IntelliSense documentation file (`XML` Documentation) to build output and NuGet package
- Added `IBinaryWriter` and `IBinaryReader` interfaces to represent generic Binary writing and reading
- Added wrappers for `BinaryWriter` and `BinaryReader` (N-prefixed) that implements `IBinaryWriter` and `IBinaryReader` respectively 

### Changed

- The following methods can now be used on .NET Framework and Mono:
    - `ProcessExtensions.EndGracefully()`
    - `Checks.OnWindows()`
- Further improve NuGet package metadata.
- Changed the icon of the NuGet package to the new logo.
- `BigEndianBinaryWriter` no longer available for .NET 6 target
- Made `BigEndianBinaryWriter` and `BigEndianBinaryReader` implement `IBinaryWriter` and `IBinaryReader` respectively

## [0.1.4-alpha] - 2023/3/1

### Fixed

- Fixed SourceLink.

## [0.1.3-alpha] - 2023/2/1

### Added

- Added `BigEndianBinaryReader` and `BigEndianBinaryWriter` for Big Endian binary I/O

### Changed

- Now IceCube builds for .NET 7

### Removed

- Removed deprecated extension method `Iterate<T>(Predicate<T>, Action<T>)`
- Removed localisation module (and tests for it) completely since it is not used anywhere

## [0.1.2-alpha] - 2023/2/1

### Changed

- Decouple localisation module from IceCube main package

## [0.1.1-alpha] - 2023/1/30

### Added

- Added extension method `EndGracefully()` for `Process` class that ends a process gracefully
  (behaviour depending on platform) for Windows and GNU/Linux on .NET 6+
- Added extension method `Iterate<T>(Func<bool, T>)` for enumerables that breaks if the `Func` returns `false`
- Added check method `ProcessRunning(Process)` to check (assert) if a process is running or not

### Changed

- Fixed an issue resulted in `LanguageService.CurrentLanguage` not producing a default value outside of Windows

### Deprecated

- Made `Iterate<T>(Predicate<T>, Action<T>)` extension method obsolete in favour of `Iterate<T>(Func<bool, T>)`

## [0.1.0-alpha] - 2023/1/27

- Initial release.

[Unreleased]: https://codeberg.org/NexusKrop/IceCube/compare/v0.3.1-alpha...HEAD
[0.3.1-alpha]: https://codeberg.org/NexusKrop/IceCube/compare/v0.3.0-alpha...v0.3.1-alpha
[0.3.0-alpha]: https://codeberg.org/NexusKrop/IceCube/compare/v0.2.0-alpha...v0.3.0-alpha
[0.2.0-alpha]: https://codeberg.org/NexusKrop/IceCube/compare/v0.1.4-alpha...v0.2.0-alpha
[0.1.4-alpha]: https://codeberg.org/NexusKrop/IceCube/compare/v0.1.3-alpha...v0.1.4-alpha
[0.1.3-alpha]: https://codeberg.org/NexusKrop/IceCube/compare/v0.1.2-alpha...v0.1.3-alpha
[0.1.2-alpha]: https://codeberg.org/NexusKrop/IceCube/compare/v0.1.1-alpha...v0.1.2-alpha
[0.1.1-alpha]: https://codeberg.org/NexusKrop/IceCube/compare/v0.1.0-alpha...v0.1.1-alpha
[0.1.0-alpha]: https://codeberg.org/NexusKrop/IceCube/releases/tag/v0.1.0-alpha