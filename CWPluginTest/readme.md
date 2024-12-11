Example Content Warning Steam Workshop Mod
===

This is an example mod for content warning to show how to use the modding API!

Here's the components of this example project:

- ExampleCWPlugin.csproj: this specifies the location of Content Warning and its dlls. If it's not installed in the default steam location of `C:\Program Files (x86)\Steam\steamapps\common\Content Warning`, you can edit that here.
  - There's also a build step that copies the built dll and preview.png to the content warning plugins directory when building, letting you easily test your code by just building then launching content warning.
- preview.png: This is the image used for your mod's steam workshop page when uploading the mod.
- Example.cs: The code for the mod. Check out the comments in the code for details!

---

Content Warning can load mods from 3 places:

- The Steam Workshop, which automatically handles downloading and installing mods you are subscribed to. (Mods are installed to a directory outside the game folder)
- Locally installed Steam Workshop mods. This is intended purely for development of mods, and is not expected to be used by regular players. Any mods put in the directory `C:\Program Files (x86)\Steam\steamapps\common\Content Warning\Plugins` will be loaded as if they're a steam workshop mod. If you're subscribed to a mod with the same GUID as a mod in the Plugins folder, the subscribed mod will not be loaded (the locally installed mod takes priority).
- Mods managed by BepInEx, MelonLoader, etc. - these are mostly ignored by the vanilla content warning modloader (as loading them is handled by BepInEx/etc.), except to show them in the list of mods installed.

---

To upload a mod to the Steam Workshop, first install the mod locally to the content warning local plugins directory (`C:\Program Files (x86)\Steam\steamapps\common\Content Warning\Plugins\YourPluginName`). An option to upload the mod (or update the published mod if you have already published it) will show up in the Mod Manager ingame. Make sure to include your preview.png in the plugin directory!
