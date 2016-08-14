namespace Cake.VsCode.Tests
{
    internal sealed class VscePackagerFixture : VsceFixture<VscePackageSettings>
    {
        protected override void RunTool()
        {
            var tool = new VscePackager(FileSystem, Environment, ProcessRunner, Tools, Resolver);
            tool.Run(Settings);
        }
    }
}