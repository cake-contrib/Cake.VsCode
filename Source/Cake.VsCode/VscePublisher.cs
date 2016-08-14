using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.VsCode
{
    /// <summary>
    /// The Vsce Publisher used to publish VsCode Extensions
    /// </summary>
    public sealed class VscePublisher : VsceTool<VscePublishSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="VscePublisher" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="toolLocator">The tool locator.</param>
        /// <param name="resolver">The tool resolver</param>
        public VscePublisher(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator toolLocator, IVsceToolResolver resolver)
            : base(fileSystem, environment, processRunner, toolLocator, resolver)
        {
            _environment = environment;
        }

        /// <summary>
        /// Publishes a Vsce package from the provided settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Run(VscePublishSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Run(settings, GetArguments(settings));
        }

        private ProcessArgumentBuilder GetArguments(VscePublishSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("publish");

            if (settings.Package != null)
            {
                builder.AppendQuoted(settings.Package.MakeAbsolute(_environment).FullPath);
            }

            if (!string.IsNullOrWhiteSpace(settings.PersonalAccessToken))
            {
                builder.Append("--pat");
                builder.Append(settings.PersonalAccessToken);
            }

            return builder;
        }
    }
}