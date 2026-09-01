using System.Reflection;
using EFT.Settings.Game;
using EFT.UI;
using EFT.UI.Settings;
using HarmonyLib;
using SPT.Reflection.Patching;

namespace hazelify.VCO.Patches;

internal sealed class FovSliderPatch : ModulePatch
{
    private static NumberSlider _fovSlider;
    private static GameSettingsGroup _gameSettings;

    protected override MethodBase GetTargetMethod()
    {
        return AccessTools.Method(typeof(GameSettingsTab), nameof(GameSettingsTab.Show));
    }

    [PatchPostfix]
    private static void PatchPostfix(NumberSlider ____fov, GameSettingsGroup ____gameSettings)
    {
        _fovSlider = ____fov;
        _gameSettings = ____gameSettings;
        Refresh();
    }

    internal static void Refresh()
    {
        if (_fovSlider == null || _gameSettings == null)
        {
            return;
        }

        int maximum = Plugin.ExpandedFovRange.Value ? 150 : 75;
#pragma warning disable CS0618 // Tarkov 4.1.3 still binds its FOV NumberSlider through this API.
        SettingsTab.BindNumberSliderToSetting(
            _fovSlider,
            _gameSettings.FieldOfView,
            50,
            maximum);
#pragma warning restore CS0618
    }
}
