using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.GeneralLocalization;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace CustomHitSound.Patches;

[HarmonyPatch(typeof(BattleSfxSelect))]
internal static class BattleSfxSelectPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(BattleSfxSelect.OnAwake))]
    private static void AwakePostfix(BattleSfxSelect __instance)
    {
        GenerateToggles(__instance);
        FixOriginalSelection(__instance);
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(BattleSfxSelect.OnBattleSfxToggle))]
    private static void OnBattleSfxTogglePostfix(int index, bool isOn, BattleSfxSelect __instance)
    {
        var targetToggle = __instance.m_BattleSfx[index];
        var imgBg = targetToggle.transform.GetChild(0);
        var img = imgBg.GetComponent<Image>();
        var checkmark = imgBg.GetChild(0).gameObject;
        if (isOn || Setting.CurrentSfx == string.Empty)
        {
            img.color = __instance.highLight;
            checkmark.SetActive(true);
            return;
        }

        targetToggle.isOn = false;
        img.color = __instance.normal;
        checkmark.SetActive(false);

        var correctIndex = __instance.m_BattleSfx.FindIndex(new Func<Toggle, bool>(x => x.name == $"Tgl{Setting.CurrentSfx}"));
        var correctImgBg = __instance.m_Content.GetChild(correctIndex).GetChild(0);
        __instance.m_BattleSfx[correctIndex].isOn = true;
        correctImgBg.GetComponent<Image>().color = __instance.highLight;
        correctImgBg.GetChild(0).gameObject.SetActive(true);

        __instance.txtBattleSfxLabel.text = Setting.CurrentSfx;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(BattleSfxSelect.SetSelectImage))]
    private static bool SetSelectImagePrefix() => Setting.CurrentSfx == string.Empty;

    [HarmonyPostfix]
    [HarmonyPatch(nameof(BattleSfxSelect.OnEnablePnl))]
    private static void OnEnablePnlPostfix(BattleSfxSelect __instance)
    {
        if (Setting.CurrentSfx == string.Empty)
        {
            return;
        }

        __instance.OnBattleSfxToggle(DataHelper.battleSfxType, false);
    }


    private static void FixOriginalSelection(BattleSfxSelect __instance)
    {
        foreach (var toggle in __instance.m_BattleSfx)
        {
            var img = toggle.transform.GetChild(0).GetComponent<Image>();
            toggle.onValueChanged.AddListener((Action<bool>)(selected =>
            {
                if (!selected)
                {
                    img.color = __instance.normal;
                }
            }));
        }
    }

    private static void GenerateToggles(BattleSfxSelect __instance)
    {
        var tglDefaultGameObject = __instance.m_Content.GetChild(0).gameObject;
        foreach (var sfxPackName in SfxFilePathsDictionary.Select(x => x.Key))
        {
            var toggle = tglDefaultGameObject.FastInstantiate(__instance.m_Content);
            toggle.name = $"Tgl{sfxPackName}";

            var imgBg = toggle.transform.GetChild(0);
            var txt = imgBg.GetChild(1);
            Object.Destroy(txt.GetComponent<Localization>());
            txt.GetComponent<Text>().text = sfxPackName;

            var toggleComp = toggle.GetComponent<Toggle>();
            toggleComp.onValueChanged.AddListener((Action<bool>)(selected =>
            {
                if (selected)
                {
                    Setting.CurrentSfx = sfxPackName;
                    __instance.OnBattleSfxToggle(DataHelper.battleSfxType, false);
                    DataHelper.battleSfxType = 0;
                }
                else
                {
                    Setting.CurrentSfx = string.Empty;
                    imgBg.GetComponent<Image>().color = __instance.normal;
                }
            }));

            __instance.m_BattleSfx.Add(toggleComp);
        }
    }
}