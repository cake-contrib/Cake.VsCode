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
        /// Gets or sets a value indicating the Working Directory that should be used while running Vsce.
        /// </summary>
        public DirectoryPath WorkingDirectory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the Output FilePath that should be used when packaging is complete.
        /// </summary>
        public FilePath OutputFilePath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the Url which will be prepended to all relative links in README.md.
        /// </summary>
        public string BaseContentUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the Url which will be prepended to all relative image links in README.md.
        /// </summary>
        public string BaseImagesUrl { get; set; }
    }
}