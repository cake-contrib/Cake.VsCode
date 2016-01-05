using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.VsCode
{
    /// <summary>
    /// Contains settings used by <see cref="VscePackager"/>.
    /// </summary>
    public sealed class VscePackageSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets a value indicating the Working Directory that should be used while running vsce.
        /// </summary>
        public DirectoryPath WorkingDirectory { get; set; }
    }
}