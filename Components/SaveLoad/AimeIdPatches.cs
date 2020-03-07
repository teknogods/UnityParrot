using AMDaemon;

namespace UnityParrot.Components
{
    public class AimeIdPatches
    {
        public static void Patch()
        {
            Harmony.MakeRET(typeof(AimeId), "get_IsValid", true);
        }
    }
}
