using AMDaemon;
using MU3;
using MU3.Operation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class AimePatches : MonoBehaviour
    {
        static bool shouldCoreBeReady = false;

        void Start()
        {
            Harmony.PatchAllInType(typeof(AimePatches));
        }

        void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.F2))
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

        [MethodPatch(PatchType.Prefix, typeof(OperationManager), "isAimeOffline")]
        public static bool IsAimeOffline(ref bool __result)
        {
            NekoClient.Logging.Log.Info("isAimeOffline");
            __result = false;
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(OperationManager), "isAimeLoginDisable")]
        public static bool IsAimeLoginDisable(ref bool __result)
        {
            NekoClient.Logging.Log.Info("isAimeLoginDisable");
            __result = false;
            return false;
        }
    }
}
