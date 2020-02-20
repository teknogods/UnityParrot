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
        void Start()
        {
            Harmony.PatchAllInType(typeof(AimePatches));
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
