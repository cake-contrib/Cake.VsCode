using System;
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

        /// <summary>
        /// Gets or sets a value indicating the Output Directory that should be used when packaging is complete.
        /// </summary>
        public DirectoryPath OutputDirectory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the Url which will be prepended to all relative links in README.md.
        /// </summary>
        public Uri BaseContentUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the Url which will be prepended to all relative image links in README.md.
        /// </summary>
        public Uri BaseImagesUrl { get; set; }
    }
}