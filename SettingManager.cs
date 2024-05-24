using Tomlet.Attributes;
using Directory = Il2CppSystem.IO.Directory;

namespace CustomHitSound;

internal static class SettingManager
{
    private static readonly string _configPath = Path.Combine("UserData", "CustomHitSound.cfg");

    private static readonly string _sfxPath = Path.Combine("UserData", "BattleSfx");
    internal static Data Setting { get; private set; } = new("Celeste", false);

    internal static void Load()
    {
        if (!File.Exists(_configPath))
        {
            var defaultConfig = TomletMain.TomlStringFrom(Setting);
            File.WriteAllText(_configPath, defaultConfig);
        }

        var data = File.ReadAllText(_configPath);
        Setting = TomletMain.To<Data>(data);

        if (!Directory.Exists(_sfxPath))
        {
            Directory.CreateDirectory(_sfxPath);
        }

        Setting.StoredSfxPacks = Directory.GetDirectories(_sfxPath);
    }

    internal static void Save() => File.WriteAllText(_configPath, TomletMain.TomlStringFrom(Setting));
}

internal class Data
{
    [TomlPrecedingComment("The current using sfx pack")]
    internal string CurrentSfx { get; set; }

    [TomlPrecedingComment("Whether debug mode enabled or not")]
    internal bool DebugModeEnabled { get; set; }

    [TomlPrecedingComment("Stored sfx pack paths")]
    internal string[] StoredSfxPacks { get; set; }

    public Data()
    {
    }

    internal Data(string currentSfx, bool debugModeEnabled)
    {
        CurrentSfx = currentSfx;
        DebugModeEnabled = debugModeEnabled;
    }
}