#Cake.VsCode Documentation

Cake.VsCode is an Addin for [Cake](http://cakebuild.net/) which allows you to easily add [VCSE](https://github.com/Microsoft/vscode-vsce) packaging and publishing into your build scripts.

This addin supports the following commands:

* package
* publish

Although there are other commands available to the vsce command line, for example:

* ls
* unpublish
* list
* ls-publishers
* create-publisher
* delete-publisher
* login
* logout

It was determined that these commands would not be required as part of a build pipeline.  However, if you would like to see these commands added to the Addin, then please get in touch via the [issues](https://github.com/gep13/Cake.VsCode/issues).

<div class="admonition attention">
    <p class="first admonition-title">Attention</p>
    <p class="last">
        In order to make use of this Addin, the vsce command line utility will have to be installed in the [normal way](https://code.visualstudio.com/docs/tools/vscecli).  Cake not "currently" support the ability to add tools from NPM, however, there is work in progress to allow this to happen.
    </p>
</div>