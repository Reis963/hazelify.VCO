using System.Reflection;
using EFT.Settings.Game;
using HarmonyLib;
using SPT.Reflection.Patching;
using UnityEngine;

namespace hazelify.VCO.Patches;

internal sealed class FovRangePatch : ModulePatch
{
    protected override MethodBase GetTargetMethod()
    {
        return AccessTools.Method(
            typeof(GameSettingsGroup.CG_Ctor),
            nameof(GameSettingsGroup.CG_Ctor.method_0));
    }

    [PatchPostfix]
    private static void PatchPostfix(int x, ref int __result)
    {
        int maximum = Plugin.ExpandedFovRange.Value ? 150 : 75;
        __result = Mathf.Clamp(x, 50, maximum);
    }
}
