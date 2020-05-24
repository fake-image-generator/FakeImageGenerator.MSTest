# FakeImageGenerator.MSTest
[![NuGet](https://img.shields.io/nuget/v/FakeImageGenerator.MSTest)](https://www.nuget.org/packages/FakeImageGenerator.MSTest/) [![Github Actions](https://img.shields.io/github/workflow/status/fake-image-generator/FakeImageGenerator.MSTest/.NET%20Core)]([https://github.com/fake-image-generator/FakeImageGenerator.MSTest/actions?query=workflow%3A%22.NET+Core%22](https://github.com/fake-image-generator/FakeImageGenerator.MSTest/actions?query=workflow%3A".NET+Core"))



<img align="left" width="100" height="100" src="fake-image-generator.png">

For more details about this project please check the main repository in [FakeImageGenerator](https://github.com/fake-image-generator/FakeImageGenerator).

### Requirements

.NET Core 3.1

### Installation

```
Install-Package FakeImageGenerator.MSTest
```

### Usage

Add the `FakeImageGeneratorAttribute` in all `MSTest` data tests in which you need fake images like this:

```csharp
[DataTestMethod]
[FakeImageGeneratorAttribute(10000000, "Png", "C:/")]
public void GenerateFakeImageWithOutputPathShouldBeOk(string path)
{
    var file = new FileInfo(path);

    Assert.AreEqual(10000000, file.Length);
    Assert.AreEqual(".png", file.Extension);
}

[DataTestMethod]
[FakeImageGeneratorAttribute(10000000, "Png")]
public void GenerateFakeImageWithoutOutputPathShouldBeOk(byte[] array)
{
    Assert.AreEqual(10000000, array.Length);
}
```

