#r "Cake.VsCode.dll"

try
{
    VscePackage(new VscePackageSettings()
    {
        WorkingDirectory = Directory("C:/github/gep13/chocolatey-vscode")
    });
}
catch(Exception ex)
{
    Error("{0}", ex);
}

Console.ReadLine();