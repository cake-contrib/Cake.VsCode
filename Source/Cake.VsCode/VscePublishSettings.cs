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
        /// Gets or sets the Personal Access Token to be used for publishing.
        /// </summary>
        /// <value>The Personal Access Token.</value>
        public string PersonalAccessToken { get; set; }
    }
}