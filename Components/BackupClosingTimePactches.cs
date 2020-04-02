using MU3.AM;

namespace UnityParrot.Components
{
    public class BackupClosingTimePatches
    {
        public static void Patch()
        {
            Harmony.PatchAllInType(typeof(BackupClosingTimePatches));
        }

        [MethodPatch(PatchType.Prefix, typeof(BackupClosingTime.BackupClosingTimeRecord), "getRemainingMinutes")]
        static bool getRemainingMinutes(ref int __result)
        {
            __result = 99;
            return false;
        }
    }
}
