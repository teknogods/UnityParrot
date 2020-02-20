using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    class AccessCodePatches : MonoBehaviour
    {
        void Start()
        {
            Harmony.PatchAllInType(typeof(AimeIdPatches));
        }

        [MethodPatch(PatchType.Prefix, typeof(AccessCodePatches), "get_IsValid")]
        private static bool GetIsValid(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AccessCode IsValid");

            __result = true;

            return false;
        }
    }
}
