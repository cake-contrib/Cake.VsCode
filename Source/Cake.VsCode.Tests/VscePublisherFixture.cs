namespace Cake.VsCode.Tests
{
    internal sealed class VscePublisherFixture : VsceFixture<VscePublishSettings>
    {
        protected override void RunTool()
        {
            var tool = new VscePublisher(FileSystem, Environment, ProcessRunner, Tools, Resolver);
            tool.Run(Settings);
        }
    }
}