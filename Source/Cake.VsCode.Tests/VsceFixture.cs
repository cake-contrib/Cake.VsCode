using Cake.Core.Diagnostics;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;

namespace Cake.VsCode.Tests
{
    internal abstract class VsceFixture<TSettings> : ToolFixture<TSettings>
        where TSettings : ToolSettings, new()
    {
        protected VsceFixture()
            : base("vsce.cmd")
        {
        }
    }
}
