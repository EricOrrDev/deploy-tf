# DEPLOY.TF
Deploy.tf is a config generation project for the game Team Fortress 2.
What is going to be special about Deploy is that it will be a .NET Photino application, meaning it will be both a website but also a desktop application. The reason for this is to avoid one annoying part of the typical config process, extracting an archive to your TF2/cfg folder. The Golden Standard of config generation is CFG.tf, and thus this is a fork of CFG.tf.

Deploy should function as the best way to create, deploy, edit, and maintain a user's configuration. This will be achieved with key set of features:
- One-Click Deployment : Clicking 'Deploy' at the end of creating a new config, or when a previous config is selected seamlessly swaps in the users config while archiving the previous config.
- Config History: Much like Git, Deploy keeps a detailed record of what changes in a config and when. This is to enable recovery but also linear replay to see the iterative changes made to the user's config.

Less important features are:
- Easy Backup: A user should be able to sign into their google account and backup their repo of configs to their google drive.
- Path Ready: The application should remember the user's path to the TF2 install and assume that is correct unless otherwise changed.

usecase-beta
actor User("User")

Website("Deploy Website")
Desktop("Deploy App")
Core("Application Core")

Photino("Target: Photino")
Exe("Host: Executable")

Blazor("Target: Blazor WASM")
Azure("Host: Azure Static")

Pages("Pages")
Modals("Modals")
Forms("Forms")
FileSys("IFileSystem")

User --> Website
User --> Desktop
Website --> Core
Desktop --> Core

Website --> Azure
Website --> Blazor

Desktop --> Photino
Desktop --> Exe

Core --> Pages
Core --> Forms
Core --> Modals
Core --> FileSys