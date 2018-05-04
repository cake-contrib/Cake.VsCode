using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.VsCode
{
    /// <summary>
    /// <para>Contains aliases related to <see href="https://code.visualstudio.com/docs/tools/vscecli">VSCode Extension Manager</see>.</para>
    /// <para>
    /// In order to use the commands for this addin, you will need to include the following in your build.cake file to download and
    /// reference from NuGet.org:
    /// <code>
    /// #addin Cake.VsCode
    /// </code>
    /// </para>
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
        ///         BaseImagesUrl = "http://mydomain.com")
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

            var packager = new VscePackager(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
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
        ///         PersonalAccessToken = "ABCDEF")
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

            var publisher = new VscePublisher(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            publisher.Run(settings);
        }
    }
}
