using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.VsCode
{
    /// <summary>
    /// Contains settings used by <see cref="VscePublisher"/>.
    /// </summary>
    public sealed class VscePublishSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the Package that should packaged.
        /// </summary>
        /// <value>The Package File path.</value>
        public FilePath Package { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the Working Directory that should be used while running vsce.
        /// </summary>
        public DirectoryPath WorkingDirectory { get; set; }
    }
}