using AMDaemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    class SerialPatches : MonoBehaviour
    {
        void Start()
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
