using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.VsCode.Tests
{
    internal sealed class VscePackagerFixture : VsceFixture<VscePackageSettings>
    {
        public VscePackagerFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new VscePackager(FileSystem, Environment, ProcessRunner, Globber, Resolver);
            tool.Run(Settings);
        }
    }
}