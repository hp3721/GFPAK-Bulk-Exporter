# GFPAK-Bulk-Exporter
Bulk exports GFPAK files using pkNX.Containers

## Usage
* Run `"GFPAK Bulk Exporter.exe" <path to archive directory in romfs>`

## Dependencies
Decompressing data within a `*.gfpak` archive for PLA requires having the [Oodle Decompressor dll](http://www.radgametools.com/oodlecompressors.htm) in the same folder as the executable. This program has a hardcoded reference to `oo2core_8_win64.dll`, which can be sourced from other games (for example Warframe, which is free on Steam).
