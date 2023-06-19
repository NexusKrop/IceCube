# Contribution Guidelines

First, thanks for your interest on contributing to this project.

## Tools

### Windows

If you are on Windows, Visual Studio 2022 with the following extensions is
highly recommended:

- SonarLint

Most of the time the IceCube is developed via the tools above in Windows.

### GNU/Linux

I recommend VS Code/Codium on GNU/Linux, but you may use any other tool you'd
like to use.

MonoDevelop is not supported and will not work with .NET 5+.

### macOS

Visual Studio for Mac is recommended.

## Coding conventions

### Commit messages

While it is not _strictly_ required, this is the recommended way to write your
commit messages when contributing to this repo, as it helps us to organise the
commits and it looks easier on the eyes.

Commit messages are in this format:

```
<emoji> (<scope>) <message>
```

- **Emoji:** [Gitmoji](https://gitmoji.dev/). Use "development script" to indicate
  project-file only changes, except for version bumps which uses "version tags".
- **Scope:** See [Commit scopes](#commit-scopes).
- **Message:** Commit message or summary.

### Commit scopes

- `general`: Project/solution file only changes, documentations, and other misc config changes.
- `checks`: [`Checks`](NexusKrop.IceCube/Exceptions/Checks.cs) class, and related files
- `test`: Unit tests.
- `release`: Version bumps.
- `ci`: CI workflow and pipeline configuration.
- `collection`: Collections and collection related extension classes.
- `process`: Process related extension classes.
- `math`: [`MathUtil`](NexusKrop.IceCube/MathUtil.cs) class, and related files
- `vb`: Visual Basic wrapper modules and codes
- `misc`: Any other

If you want a new scope for a new major feature, just ask.

