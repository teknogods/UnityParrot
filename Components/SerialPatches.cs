using AMDaemon;

namespace UnityParrot.Components
{
    class SerialPatches
    {
        public static void Patch()
        {
            Harmony.PatchAllInType(typeof(SerialPatches));
        }

        [MethodPatch(PatchType.Prefix, typeof(SerialId), "get_Value")]
        private static bool GetSerialId(ref string __result)
        {
            __result = "T3KNOG0DZ";

            return false;
        }
    }
}
