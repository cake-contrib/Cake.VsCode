using System;
using Cake.Core;
using Cake.Core.IO;

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
        /// <param name="globber">The globber.</param>
        /// <param name="resolver">The tool resolver</param>
        public VscePublisher(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber, IVsceToolResolver resolver)
            : base(fileSystem, environment, processRunner, globber, resolver)
        {
            _environment = environment;
        }

        /// <summary>
        /// Publishes a Vsce package from the provided settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Publish(VscePublishSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Run(settings, GetArguments(settings), new ProcessSettings { WorkingDirectory = settings.WorkingDirectory }, null);
        }

        private ProcessArgumentBuilder GetArguments(VscePublishSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("publish");

            if (settings.Package != null)
            {
                builder.AppendQuoted(settings.Package.MakeAbsolute(_environment).FullPath);
            }

            return builder;
        }
    }
}