using MU3.AM;

namespace UnityParrot.Components
{
    public class BackupSettingPatches
    {
        public static void Patch()
        {
            Harmony.MakeRET(typeof(BackupSetting), "get_isEventModeSettingAvailable", true);
        }
    }
}
