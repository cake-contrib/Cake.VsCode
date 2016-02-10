using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.VsCode.Tests
{
    internal sealed class VcsePublisherFixture : VsceFixture<VscePublishSettings>
    {
        public VcsePublisherFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new VscePublisher(FileSystem, Environment, ProcessRunner, Globber, Resolver);
            tool.Run(Settings);
        }
    }
}