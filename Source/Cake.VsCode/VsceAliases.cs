using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.VsCode
{
    /// <summary>
    /// Contains functionality for working with Vsce.
    /// </summary>
    [CakeAliasCategory("Vsce")]
    public static class VsceAliases
    {
        /// <summary>
        /// Packages a VsCode Extension.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        ///     VscePackage();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Package")]
        public static void VscePackage(this ICakeContext context)
        {
            VscePackage(context, new VscePackageSettings());
        }

        /// <summary>
        /// Packages a VsCode Extension using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     VscePackage(new VscePackageSettings()
        ///     {
        ///         WorkingDirectory = Directory("C:/vscodeextension")
        ///     });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Package")]
        public static void VscePackage(this ICakeContext context, VscePackageSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var resolver = new VsceToolResolver(context.FileSystem, context.Environment);
            var packager = new VscePackager(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber, resolver);
            packager.Run(settings);
        }

        /// <summary>
        /// Publishes a VsCode Extension.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        ///     VscePublish();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Publish")]
        public static void VscePublish(this ICakeContext context)
        {
            VscePublish(context, new VscePublishSettings());
        }

        /// <summary>
        /// Publishes a VsCode Extension using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     VscePublish(new VscePublishSettings()
        ///     {
        ///         WorkingDirectory = Directory("C:/vscodeextension")
        ///     });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Publish")]
        public static void VscePublish(this ICakeContext context, VscePublishSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var resolver = new VsceToolResolver(context.FileSystem, context.Environment);
            var publisher = new VscePublisher(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber, resolver);
            publisher.Run(settings);
        }
    }
}