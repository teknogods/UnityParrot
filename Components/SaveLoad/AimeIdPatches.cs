using AMDaemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    class AimeIdPatches : MonoBehaviour
    {
        void Start()
        {
            Harmony.PatchAllInType(typeof(AimeIdPatches));
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeId), "get_IsValid")]
        private static bool GetIsValid(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeId IsValid");

            __result = true;

            return false;
        }
    }
}
