# Viewmodel Camera Offset

A lightweight SPT *(Single Player Tarkov)* client mod that adjusts the horizontal and vertical position
of the first-person viewmodel. It can also expand the FOV range available in
the Tarkov settings menu.

## Installation

Extract the release archive into the root of your SPT installation. The plugin
must be located at:

`BepInEx/plugins/hazelify.VCO/hazelify.VCO.dll`

## Configuration

Open the BepInEx Configuration Manager with `F12` and find **Viewmodel Camera
Offset**.

- **Horizontal offset** adjusts the horizontal viewmodel position. Default:
  `0.04`. Recommended: `-0.01`.
- **Vertical offset** moves the viewmodel down or up. Default: `0.04`.
  Recommended: `0.065`.
- **Enable expanded range** changes the FOV range in the Tarkov settings menu
  from `50-75` to `50-150`. The FOV value itself is still selected in Tarkov.

## Compatibility

Other mods that change the viewmodel camera offset or FOV limits may conflict
with this mod.

## Credits

Originally created by [minihazel](https://github.com/minihazel/hazelify.VCO).

## License

This project is licensed under the [MIT License](LICENSE).
