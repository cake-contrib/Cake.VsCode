# Build Script

In order to make use of the Cake.VsCode Addin, you will need to first use the `#addin` preprocessor to install Cake.VsCode, but once that is done, you can directly use both the `VscePackage` and `VscePublish` commands.

<div class="admonition note">
    <p class="first admonition-title">Note</p>
    <p class="last">
        You can see an example of this Addin in action in the [build.cake](https://github.com/gep13/chocolatey-vscode/blob/master/build.cake) file.
    </p>
</div>

## VscePackage

Due to the way in which vsce works, it is possible to execute the command line utility directly, without any additional settings.  This will simply package the `package.json` file, and output the resulting `vsix` file to the same directory.

```csharp
#addin Cake.VsCode

Task("Package-Extension")
    .Does(() =>
{
    VscePackage();
});
```

If you want some more control over how this works though, you can use the following:

```csharp
#addin Cake.VsCode

var version = "0.1.0";
var buildResultDir = Directory("./build")
var packageFile = File("chocolatey-vscode-" + version + ".vsix");

Task("Package-Extension")
    .IsDependentOn("Find-Version-Number") 
    .Does(() =>
{
    VscePackage(new VscePackageSettings() {
        OutputFilePath = buildResultDir + packageFile,
        BaseContentUrl = new Uri("http://mydomain.com"),
        BaseImagesUrll = new Uri("http://mydomain.com/images")
    });
});
```

## VscePublish

Again, due to the way in which vsce works, it is possible to run `vsce publish` without any paramaters.  It will simply use the latest `vsix` file contained within the directory being executed on, and it will assume that the publisher has already been logged in.

```csharp
#addin Cake.VsCode

Task("Publish-Extension")
    .Does(() =>
{    
    VscePublish();
});
```

However, it is more realistic that you want to run this on some type of build server, in which case, the publisher is NOT already going to be logged in.  To account for this, you can pass the publishers Personal Access Token into the VscePublish command, as follows:

```csharp
#addin Cake.VsCode

Task("Publish-Extension")
    .IsDependentOn("Create-Release-Notes")
    .Does(() =>
{
    var personalAccessToken = EnvironmentVariable("VSCE_PAT");
    
    VscePublish(new VscePublishSettings(){
        PersonalAccessToken = personalAccessToken
    });
});
```

<div class="admonition note">
    <p class="first admonition-title">Note</p>
    <p class="last">
        Here the Personal Access Token is being recovered from an Environmental variable where it is located.
    </p>
</div>