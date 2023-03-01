# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

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

[Unreleased]: https://github.com/NexusKrop/IceCube/compare/v0.1.2-alpha...HEAD
[0.1.2-alpha]: https://github.com/NexusKrop/IceCube/compare/v0.1.1-alpha...v0.1.2-alpha
[0.1.1-alpha]: https://github.com/NexusKrop/IceCube/compare/v0.1.0-alpha...v0.1.1-alpha
[0.1.0-alpha]: https://github.com/NexusKrop/IceCube/releases/tag/v0.1.0-alpha