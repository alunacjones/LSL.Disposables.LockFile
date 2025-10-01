[![Build status](https://img.shields.io/appveyor/ci/alunacjones/lsl-disposables-lockfile.svg)](https://ci.appveyor.com/project/alunacjones/lsl-disposables-lockfile)
[![Coveralls branch](https://img.shields.io/coverallsCoverage/github/alunacjones/LSL.Disposables.LockFile)](https://coveralls.io/github/alunacjones/LSL.Disposables.LockFile)
[![NuGet](https://img.shields.io/nuget/v/LSL.Disposables.LockFile.svg)](https://www.nuget.org/packages/LSL.Disposables.LockFile/)

# LSL.Disposables.LockFile

A disposable lock file for .NET. 

```csharp
using LSL.Disposables.LockFile;
...

// The file `file.lock` exists until `lockFile` is disposed
using var lockFile = new LockFileFactory().Create("file.lock");

// lockFile.WasCreated will be `true` if the lock file does not already exist
// lockFile.LockFilePath will be `file.lock`
```