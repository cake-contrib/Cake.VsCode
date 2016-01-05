using System;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.VsCode
{
    /// <summary>
    /// Contains Vsce path resolver functionality
    /// </summary>
    public sealed class VsceToolResolver : IVsceToolResolver
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;
        private IFile _cachedPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="VsceToolResolver" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        public VsceToolResolver(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            _fileSystem = fileSystem;
            _environment = environment;

            if (fileSystem == null)
            {
                throw new ArgumentNullException("fileSystem");
            }

            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
        }

        /// <summary>
        /// Resolves the path to vsce..
        /// </summary>
        /// <returns>The path to vsce.</returns>
        public FilePath ResolvePath()
        {
            // Check if path allready resolved
            if (_cachedPath != null && _cachedPath.Exists)
            {
                return _cachedPath.Path;
            }

            // Last resort try path
            var envPath = _environment.GetEnvironmentVariable("path");
            if (!string.IsNullOrWhiteSpace(envPath))
            {
                var pathFile = envPath
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(path => _fileSystem.GetDirectory(path))
                    .Where(path => path.Exists)
                    .Select(path => path.Path.CombineWithFilePath("vsce.cmd"))
                    .Select(_fileSystem.GetFile)
                    .FirstOrDefault(file => file.Exists);

                if (pathFile != null)
                {
                    _cachedPath = pathFile;
                    return _cachedPath.Path;
                }
            }

            throw new CakeException("Could not locate vsce.");
        }
    }
}