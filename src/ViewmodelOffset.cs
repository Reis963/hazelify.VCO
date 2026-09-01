using Comfort.Common;
using EFT;
using UnityEngine;

namespace hazelify.VCO;

internal static class ViewmodelOffset
{
    internal static void Apply(ref Vector3 cameraOffset)
    {
        cameraOffset.y = Plugin.VerticalOffset.Value;
        cameraOffset.z = Plugin.HorizontalOffset.Value;
    }

    internal static void ApplyToMainPlayer()
    {
        GameWorld gameWorld = Singleton<GameWorld>.Instance;
        if (gameWorld?.MainPlayer?.ProceduralWeaponAnimation?.HandsContainer == null)
        {
            return;
        }

        Vector3 cameraOffset = gameWorld.MainPlayer.ProceduralWeaponAnimation.HandsContainer.CameraOffset;
        Apply(ref cameraOffset);
        gameWorld.MainPlayer.ProceduralWeaponAnimation.HandsContainer.CameraOffset = cameraOffset;
    }
}
