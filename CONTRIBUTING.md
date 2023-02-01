# Contribution Guidelines

First, thanks for your interest on contributing to this project.

## Coding conventions

### Commit messages

While it is not strictly required, this is still very neccessary as it will avoid to make
our commit log look clutter.

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
- `ci`: GitHub Actions workflow and pipeline configuration.
- `collection`: Collections and collection related extension classes.
- `process`: Process related extension classes.
- `math`: [`MathUtil`](NexusKrop.IceCube/MathUtil.cs) class, and related files
- `misc`: Any other

If you want a new scope for a new feature, just ask.

