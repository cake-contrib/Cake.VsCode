using Cake.Core.IO;

namespace Cake.VsCode
{
    /// <summary>
    /// Represents a Vsce path resolver.
    /// </summary>
    public interface IVsceToolResolver
    {
        /// <summary>
        /// Resolves the path to vsce.
        /// </summary>
        /// <returns>The path to vsce.</returns>
        FilePath ResolvePath();
    }
}