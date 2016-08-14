using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.VsCode
{
    /// <summary>
    /// Base class for all Vsce related tools.
    /// </summary>
    /// <typeparam name="TSettings">The settings type.</typeparam>
    public abstract class VsceTool<TSettings> : Tool<TSettings>
        where TSettings : ToolSettings
    {
        private readonly IVsceToolResolver _resolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="VsceTool{TSettings}"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="toolLocator">The Tool Locator.</param>
        /// <param name="resolver">The Chocolatey tool resolver.</param>
        protected VsceTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator toolLocator, IVsceToolResolver resolver)
            : base(fileSystem, environment, processRunner, toolLocator)
        {
            _resolver = resolver;
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected sealed override string GetToolName()
        {
            return "Vsce";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected sealed override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "vsce.cmd" };
        }

        /// <summary>
        /// Gets alternative file paths which the tool may exist in
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default tool path.</returns>
        protected sealed override IEnumerable<FilePath> GetAlternativeToolPaths(TSettings settings)
        {
            var path = _resolver.ResolvePath();
            if (path != null)
            {
                return new[] { path };
            }

            return Enumerable.Empty<FilePath>();
        }
    }
}