using MU3.AM;
using MU3.DB;

namespace UnityParrot.Components
{
    public class BackupSettingPatches
    {
        public static void Patch()
        {
            Harmony.PatchAllInType(typeof(BackupSettingPatches));
            Harmony.MakeRET(typeof(BackupSetting), "get_isEventModeSettingAvailable", false);
        }

        [MethodPatch(PatchType.Prefix, typeof(BackupSetting), "get_gpPurchaseCreditLimit")]
        static bool gpPurchaseCreditLimit(ref GpPurchaseCreditLimitID __result)
        {
            __result = GpPurchaseCreditLimitID.Off;
            return false;
        }


}
}
