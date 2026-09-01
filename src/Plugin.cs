using BepInEx;
using BepInEx.Configuration;
using hazelify.VCO.Patches;

namespace hazelify.VCO;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
[BepInDependency("com.SPT.core", "4.1.3")]
public sealed class Plugin : BaseUnityPlugin
{
    public const string PluginGuid = "hazelify.vco";
    public const string PluginName = "Viewmodel Camera Offset";
    public const string PluginVersion = "2.0.0";

    internal static ConfigEntry<float> HorizontalOffset { get; private set; }
    internal static ConfigEntry<float> VerticalOffset { get; private set; }
    internal static ConfigEntry<bool> ExpandedFovRange { get; private set; }

    private void Awake()
    {
        HorizontalOffset = Config.Bind(
            "Camera",
            "Horizontal offset",
            0.04f,
            new ConfigDescription(
                "Adjusts the horizontal viewmodel position. Recommended: -0.01.",
                new AcceptableValueRange<float>(-0.5f, 0.5f)));

        VerticalOffset = Config.Bind(
            "Camera",
            "Vertical offset",
            0.04f,
            new ConfigDescription(
                "Moves the viewmodel down or up. Recommended: 0.065.",
                new AcceptableValueRange<float>(-0.5f, 0.5f)));

        ExpandedFovRange = Config.Bind(
            "Field of view",
            "Enable expanded range",
            false,
            "Expands the FOV range in the Tarkov settings menu from 50-75 to 50-150.");

        HorizontalOffset.SettingChanged += OnOffsetChanged;
        VerticalOffset.SettingChanged += OnOffsetChanged;
        ExpandedFovRange.SettingChanged += OnFovRangeChanged;

        new PlayerSpringPatch().Enable();
        new FovRangePatch().Enable();
        new FovSliderPatch().Enable();

        Logger.LogInfo($"{PluginName} {PluginVersion} loaded");
    }

    private static void OnOffsetChanged(object sender, System.EventArgs args)
    {
        ViewmodelOffset.ApplyToMainPlayer();
    }

    private static void OnFovRangeChanged(object sender, System.EventArgs args)
    {
        FovSliderPatch.Refresh();
    }
}
