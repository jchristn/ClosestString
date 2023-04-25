# ClosestString

ClosestString is a simple static library that will find the closest matching string, and its edit distance, based on a supplied string and list of valid strings.

[![NuGet Version](https://img.shields.io/nuget/v/ClosestString.svg?style=flat)](https://www.nuget.org/packages/ClosestString/) [![NuGet](https://img.shields.io/nuget/dt/ClosestString.svg)](https://www.nuget.org/packages/ClosestString) 

## Help, Feedback, Contribute

If you have any issues or feedback, please file an issue here in Github. We'd love to have you help by contributing code for new features, optimization to the existing codebase, ideas for future releases, or fixes!

## New in v1.0.x

- Initial release using Levenshtein (Wagner Fischer)
- Added ```ClosestMatches``` static class to retrieve multiple matches ordered by edit distance

## Example Project

Refer to the ```Test``` project for exercising the library.

```csharp
using FindClosestString;

List<string> validValues = new List<string> { "foo", "bar", "baz", "joel", "maria", "lucas", "sienna", "khaleesi" };
(string, int) closest = ClosestString.UsingLevenshtein("fox", validValues);
// closest.Item1 -> "foo"
// closest.Item2 -> 1 

List<(string, int)> matches = ClosestStrings.UsingLevenshtein("fox", validValues, 10); // max 10 results
```

## Version History

Refer to CHANGELOG.md for version history.
