# Netboot - Cache [![Build](https://github.com/NetbootCommunity/Netboot-Cache/actions/workflows/build.yml/badge.svg)](https://github.com/NetbootCommunity/Netboot-Cache/actions/workflows/build.yml) [![NuGet Version](http://img.shields.io/nuget/v/Netboot.Utility.Cache.svg?style=flat)](https://www.nuget.org/packages/Netboot.Utility.Cache/)  [![Reliability Rating](https://sonarqube.netboot.fr/api/project_badges/measure?project=netboot_cache&metric=reliability_rating)](https://sonarqube.netboot.fr/dashboard?id=netboot_cache) [![Security Rating](https://sonarqube.netboot.fr/api/project_badges/measure?project=netboot_cache&metric=security_rating)](https://sonarqube.netboot.fr/dashboard?id=netboot_cache)  [![Code Smells](https://sonarqube.netboot.fr/api/project_badges/measure?project=netboot_cache&metric=code_smells)](https://sonarqube.netboot.fr/dashboard?id=netboot_cache)

Simple and powerful strongly typed read-through caching extensions for .NET's IDistributedCache.

## Please show the value

Choosing a project dependency could be difficult. We need to ensure stability and maintainability of our projects.
Surveys show that GitHub stars count play an important factor when assessing library quality.

⭐ Please give this repository a star. It takes seconds and help thousands of developers! ⭐

## Support development

It doesn't matter if you are a professional developer, creating a startup or work for an established company.
All of us care about our tools and dependencies, about stability and security, about time and money we can safe, about quality we can offer.
Please consider sponsoring to give me an extra motivational push to develop the next great feature.

> If you represent a company, want to help the entire community and show that you care, please consider sponsoring using one of the higher tiers.
Your company logo will be shown here for all developers, building a strong positive relation.

## Installation

The library is available as a nuget package. You can install it as any other nuget package from your IDE, try to search by `Netboot.Utility.Cache`. You can find package details [on this webpage](https://www.nuget.org/packages/Netboot.Utility.Cache).

```xml
// Package Manager
Install-Package Netboot.Utility.Cache

// .NET CLI
dotnet add package Netboot.Utility.Cache

// Package reference in .csproj file
<PackageReference Include="Netboot.Utility.Cache" Version="6.1.0" />
```

## Configuration

To use this package, add the following line to have this implementation with a distributed memory cache.

```csharp
services.AddDistributedCache()
    .AddDistributedMemoryCache();
```

## How to Contribute

Everyone is welcome to contribute to this project! Feel free to contribute with pull requests, bug reports or enhancement suggestions.

## Bugs and Feedback

For bugs, questions and discussions please use the [GitHub Issues](https://github.com/NetbootCommunity/Dotnet-Utility-Cache/issues).

## License

This project is licensed under [MIT License](https://github.com/NetbootCommunity/Dotnet-Utility-Cache/blob/main/LICENSE).
