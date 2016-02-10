namespace Cake.VsCode.Tests
{
    internal sealed class VscePublisherFixture : VsceFixture<VscePublishSettings>
    {
        protected override void RunTool()
        {
            var tool = new VscePublisher(FileSystem, Environment, ProcessRunner, Globber, Resolver);
            tool.Run(Settings);
        }
    }
}