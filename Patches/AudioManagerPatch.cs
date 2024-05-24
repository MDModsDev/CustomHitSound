using HarmonyLib;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppRuntimeAudioClipLoader;

namespace CustomHitSound.Patches;

[HarmonyPatch(typeof(AudioManager), nameof(AudioManager.PreloadBattleSfx))]
internal static class AudioManagerPatch
{
    private static void Postfix(AudioManager __instance)
    {
        if (!SfxFilePathsDictionary.TryGetValue(Setting.CurrentSfx, out var sfxFilePaths))
        {
            Setting.CurrentSfx = string.Empty;
            return;
        }

        foreach (var sfxFilePath in sfxFilePaths)
        {
            var length = Setting.CurrentSfx.Length + 1;
            var sfxName = Path.GetFileNameWithoutExtension(sfxFilePath)[..^length];
            var audioClip = Manager.Load(sfxFilePath);
            __instance.m_SfxBuffer[sfxName] = audioClip;
        }

        if (!Setting.DebugModeEnabled)
        {
            return;
        }

        foreach (var pair in __instance.m_SfxBuffer)
        {
            MelonLogger.Msg($"Key name: {pair.Key}");
            MelonLogger.Msg($"Audio path: {pair.Value.name}");
            MelonLogger.WriteLine();
        }
    }
}