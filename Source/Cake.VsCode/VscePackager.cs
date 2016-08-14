using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.VsCode
{
    /// <summary>
    /// The Vsce Packager used to package VsCode Extensions
    /// </summary>
    public sealed class VscePackager : VsceTool<VscePackageSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="VscePackager" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="toolLocator">The tool locator.</param>
        /// <param name="resolver">The tool resolver</param>
        public VscePackager(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator toolLocator, IVsceToolResolver resolver)
            : base(fileSystem, environment, processRunner, toolLocator, resolver)
        {
            _environment = environment;
        }

        /// <summary>
        /// Creates a Vsce package from the provided settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Run(VscePackageSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Run(settings, GetArguments(settings));
        }

        private ProcessArgumentBuilder GetArguments(VscePackageSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("package");

            if (settings.OutputFilePath != null)
            {
                builder.Append("--out");
                builder.AppendQuoted(settings.OutputFilePath.MakeAbsolute(_environment).FullPath);
            }

            if (settings.BaseContentUrl != null)
            {
                builder.Append("--baseContentUrl");
                builder.AppendQuoted(settings.BaseContentUrl);
            }

            if (settings.BaseImagesUrl != null)
            {
                builder.Append("--baseImagesUrl");
                builder.AppendQuoted(settings.BaseImagesUrl);
            }

            return builder;
        }
    }
}