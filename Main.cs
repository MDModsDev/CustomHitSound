namespace CustomHitSound;

internal class Main : MelonMod
{
    internal static Dictionary<string, string[]> SfxFilePathsDictionary { get; } = new();

    public override void OnInitializeMelon()
    {
        Load();
        foreach (var folderName in Setting.StoredSfxPacks)
        {
            var key = folderName[19..];
            SfxFilePathsDictionary.Add(key, Directory.GetFiles(folderName));
        }
    }

    public override void OnDeinitializeMelon()
    {
        if (!SfxFilePathsDictionary.ContainsKey(Setting.CurrentSfx))
        {
            Setting.CurrentSfx = string.Empty;
        }

        Save();
    }
}