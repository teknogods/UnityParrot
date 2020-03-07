using AMDaemon;

namespace UnityParrot.Components
{
    public class AccessCodePatches
    {
        public static void Patch()
        {
            Harmony.MakeRET(typeof(AccessCode), "get_IsValid", true);
        }
    }
}
