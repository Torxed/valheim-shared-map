# valheim-shared-map
A minimal version of real-time map-sharing/map-discovery

When discovering new areas, the location will be shared with other online players.
Map sharing won't work for players that are offline.

# Building

> :warning: **Backup your files**! The mod will modify core game files!

**Backup any files in:** `C:\Program Files (x86)\Steam\steamapps\common\Valheim\valheim_Data\Managed`<br>
And save them to a safe location. The mod will modify existing core game files and might make the game unable to start.

> :warning: **Unverified sources for the downloads**! These files have not been verified by me or anyone, if possible build them from source. These were found online and might contain fishy stuff. If you wish to build from source, the  repositories can be found in dependencies as well as in the `shared/` folder in the client and server folders respectively.

## Prerequisits

1. Download [https://hvornum.se/valheim/?f=Valheim_Bepinex_5.4.5.zip](https://hvornum.se/valheim/?f=1318a156df5d0055bf781f1eb96a07ae544e1b20a488009ad786c93d00b9fe6a) *(Build from [source](https://github.com/BepInEx/BepInEx/releases) if possible)*
2. Copy the contents of the zip file into the valheim common folder structure:
 - `BepInEx` to `C:\Program Files (x86)\Steam\steamapps\common\Valheim\`
 - `valheim_Data\Managed\<files>` into `C:\Program Files (x86)\Steam\steamapps\common\Valheim\valheim_Data\Managed\`
 - `doorstop_config.ini` to `C:\Program Files (x86)\Steam\steamapps\common\Valheim\`
 - `winhttp.dll` to `C:\Program Files (x86)\Steam\steamapps\common\Valheim\`
3. Download [https://hvornum.se/valheim/?f=AssemblyPublicizerByMrPurple6411.zip](https://hvornum.se/valheim/?f=4bab83faecaadf16830481de64ca6195e1fa889098912639377e390e625071b3) *(You should try to build the source from [MrPurple6411](https://github.com/MrPurple6411/Bepinex-Tools/releases/tag/1.0.0-Publicizer) if possible)*
4. Drag and drop all `assembly_.dll` files in `C:\Program Files (x86)\Steam\steamapps\common\Valheim\valheim_Data\Managed\` onto the `AssemblyPublicizer.exe` file as if the `.exe` is a folder.

> :information_source: Make sure you have `Visual Studio 2019 Community` installed with `Universal Windows Platform development` selected as well as `Visual Studio Build Tools 2019`.

## Running the build

Start Visual Studio by clicking on `ValheimSharedMap.csproj` in the `client/` and `server/` folders.<br>
You can merge the sources and compile once, but I split it to separate some server logic from the client to save some space.

Go to `build` in the Visual Studio menu and press `build ValheimSharedMap` *(Or press Ctrl+F6 by default)*.
Copy the built mod from `bin/release/net4.0/ValheimSharedMap.dll` and place it in `C:\Program Files (x86)\Steam\steamapps\common\Valheim\BepInEx\Plugins`
<br>
<br>
> :information_source: **Server note:** The same steps applies to the server, but the base destination path will be `C:\Program Files (x86)\Steam\steamapps\common\Valheim dedicated server` instead.

Once you run the game, if you don't get a windows terminal opening up that says `1 plugin loaded` something failed and you should start over.


# Download pre-built binary

You should build it yourself and understand what's going on.<br>
But here's a binary tested with valheim v0.145.6: [SharedMap.zip](https://hvornum.se/valheim/?f=8ff0cd673423c318aac9712bbb1d17b65919d507f0d2fb86f05a26f9fbb22f62) *(This was built using the unverified binaries mentioned before)*