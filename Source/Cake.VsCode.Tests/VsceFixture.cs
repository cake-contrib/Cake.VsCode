using Cake.Core.Diagnostics;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;
using NSubstitute;

namespace Cake.VsCode.Tests
{
    internal abstract class VsceFixture<TSettings> : ToolFixture<TSettings>
        where TSettings : ToolSettings, new()
    {
        public ICakeLog Log { get; set; }
        public IVsceToolResolver Resolver { get; set; }

        protected VsceFixture()
            : base("vsce.cmd")
        {
            Log = Substitute.For<ICakeLog>();
            Resolver = Substitute.For<IVsceToolResolver>();
        }
    }
}