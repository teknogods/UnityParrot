using AMDaemon;

namespace UnityParrot.Components
{
    public class AMDaemonPatches
    {
        public static void Patch()
        {
            Harmony.MakeRET(typeof(Error), "Set", false, new System.Type[] { typeof(int), typeof(int) });
        }
    }
}
