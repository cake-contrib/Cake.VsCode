using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.VsCode
{
    /// <summary>
    /// The Vsce Packager used to package VsCode Extensions
    /// </summary>
    public sealed class VscePackager : VsceTool<VscePackageSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VscePackager" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="globber">The globber.</param>
        /// <param name="resolver">The tool resolver</param>
        public VscePackager(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber, IVsceToolResolver resolver)
            : base(fileSystem, environment, processRunner, globber, resolver)
        {
        }

        /// <summary>
        /// Creates a Vsce package from the provided settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Package(VscePackageSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Run(settings, GetArguments(), new ProcessSettings { WorkingDirectory = settings.WorkingDirectory }, null);
        }

        private ProcessArgumentBuilder GetArguments()
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("package");

            return builder;
        }
    }
}