# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Added extension method `EndGracefully()` for `Process` class that ends a process gracefully
  (behaviour depending on platform) for Windows and GNU/Linux on .NET 6+
- Added extension method `Iterate<T>(Func<bool, T>)` for enumerables that breaks if the `Func` returns `false`

### Deprecated

- Made `Iterate<T>(Predicate<T>, Action<T>)` extension method obsolete in favour of `Iterate<T>(Func<bool, T>)`

## [0.1.0]

- Initial release.

[Unreleased]: https://github.com/NexusKrop/IceCube/compare/v0.1.0-alpha...HEAD
[0.1.0]: https://github.com/NexusKrop/IceCube/releases/tag/v0.1.0-alpha