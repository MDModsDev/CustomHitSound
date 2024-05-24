using HarmonyLib;
using Il2Cpp;
using UnityEngine.UI;

namespace CustomHitSound.Patches;

[HarmonyPatch(typeof(VolumeSelect), nameof(VolumeSelect.SetSelectImage))]
internal static class VolumeSelectPatch
{
    private static void Postfix(VolumeSelect __instance)
    {
        if (Setting.CurrentSfx == string.Empty)
        {
            return;
        }

        var label = __instance.transform.GetChild(7, 2, 0);
        label.GetComponent<Text>().text = Setting.CurrentSfx;
    }
}