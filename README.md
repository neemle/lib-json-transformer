# Neemle.Utils.JsonTransformer

[![CI/CD Pipeline](https://github.com/neemle/lib-json-transformer/actions/workflows/ci-cd.yml/badge.svg)](https://github.com/neemle/lib-json-transformer/actions/workflows/ci-cd.yml)
[![NuGet](https://img.shields.io/nuget/v/Neemle.Utils.JsonTransformer.svg)](https://www.nuget.org/packages/Neemle.Utils.JsonTransformer/)

A library for simple JSON serialization and deserialization with code trimming support in .NET 9.

## Installation

```bash
dotnet add package Neemle.Utils.JsonTransformer
```

## Usage

Add documentation about how to use your library.

## Development

### Requirements

- .NET 9 SDK

### Project Structure

- `Transformer` - main library
- `Transformer.Tests` - unit tests
- `Transformer.IntegrationTest` - integration tests

### Testing

Run tests with coverage:

```bash
./test-report.sh
```

### CI/CD

This project uses GitHub Actions for CI/CD:

1. **Automatic verification** for each PR and push to main branches
2. **Automatic testing** with code coverage check (minimum 80%)
3. **Automatic publishing** of NuGet package when creating a version tag (v*)

### Releases

To create a new release:

1. Update the version in `Transformer.csproj`
2. Create a new tag with prefix `v` (for example, `v1.0.1`)
3. Push the tag to the repository

```bash
git tag v1.0.1
git push origin v1.0.1
```

After this, GitHub Actions will automatically create a release and publish the package to NuGet.
