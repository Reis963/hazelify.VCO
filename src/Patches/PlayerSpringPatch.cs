using System.Reflection;
using EFT.Animations;
using HarmonyLib;
using SPT.Reflection.Patching;
using UnityEngine;

namespace hazelify.VCO.Patches;

internal sealed class PlayerSpringPatch : ModulePatch
{
    protected override MethodBase GetTargetMethod()
    {
        return AccessTools.Method(typeof(PlayerSpring), nameof(PlayerSpring.Start));
    }

    [PatchPostfix]
    private static void PatchPostfix(ref Vector3 ___CameraOffset)
    {
        ViewmodelOffset.Apply(ref ___CameraOffset);
    }
}
