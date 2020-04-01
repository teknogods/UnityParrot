using AMDaemon;
using AMDaemon.Abaas;
using System;
using UnityEngine;

namespace UnityParrot.Components
{
    public class InitAimePatches
    {
        public static void Patch()
        {
            Harmony.PatchAllInType(typeof(InitAimePatches));
        }

        [MethodPatch(PatchType.Prefix, typeof(Aime), "get_Units")]
        private static bool GetUnits(ref LazyCollection<AimeUnit> __result)
        {
            NekoClient.Logging.Log.Info("GetUnits");

            __result = new LazyCollection<AimeUnit>(() =>
            {
                return 1;
            },
            (a) =>
            {
                return (AimeUnit)Activator.CreateInstance(typeof(AimeUnit), (System.Reflection.BindingFlags)62, null, new object[] { IntPtr.Zero }, null);
            }, true);

            return false;
        }
    }

    public class AimePatches : MonoBehaviour
    {
        static bool shouldCoreBeReady = false;

        void Start()
        {
            Harmony.PatchAllInType(typeof(AimePatches));
        }

        void Update()
        {
            if (UnityEngine.Input.GetKey(SettingsManager.instance.settings.AimeButton))
            {
                shouldCoreBeReady = true;
            }
        }

        [MethodPatch(PatchType.Prefix, typeof(AMDaemon.Core), "get_IsReady")]
        private static bool IsReady(ref bool __result)
        {
            if (shouldCoreBeReady)
            {
                __result = true;
            }
            else
            {
                __result = false;
            }

            return false;
        }
    }
}
