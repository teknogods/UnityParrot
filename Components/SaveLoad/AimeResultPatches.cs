using AMDaemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class AimeResultPatches : MonoBehaviour
    {
        void Start()
        {
            // ALSO PATCH: AimeId.get_IsValid, 

            Harmony.PerformPatch("AimeResult # .ctor",
                typeof(AimeResult).GetConstructor((System.Reflection.BindingFlags)62, null, new Type[] { typeof(IntPtr) }, null),
                prefix: Harmony.GetPatch("CtorPatch", typeof(AimeResultPatches)));

            Harmony.PatchAllInType(typeof(AimeResultPatches));
        }

        private static bool CtorPatch()
        {
            NekoClient.Logging.Log.Info("AimeResult .ctor");

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_AccessCode")]
        private static bool GetAccessCode(ref AccessCode __result)
        {
            NekoClient.Logging.Log.Info("AimeResult AccessCode");

            __result = AccessCode.Zero;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_AimeId")]
        private static bool GetAimeId(ref AimeId __result)
        {
            NekoClient.Logging.Log.Info("AimeResult AimeId");

            __result = new AimeId(1337u);

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_FirmVersion")]
        private static bool GetFirmVersion(ref string __result)
        {
            NekoClient.Logging.Log.Info("AimeResult FirmVersion");

            __result = "";

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_HardVersion")]
        private static bool GetHardVersion(ref string __result)
        {
            NekoClient.Logging.Log.Info("AimeResult HardVersion");

            __result = "";

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_IsMobile")]
        private static bool GetIsMobile(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeResult IsMobile");

            __result = true;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_IsReaderDetected")]
        private static bool GetIsReaderDetected(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeResult IsReaderDetected");

            __result = true;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_IsSegaIdRegistered")]
        private static bool GetIsSegaIdRegistered(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeResult IsSegaIdRegistered");

            __result = false;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_IsValid")]
        private static bool GetIsValid(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeResult IsValid");

            __result = true;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_OfflineId")]
        private static bool GetAimeOfflineId(ref AimeOfflineId __result)
        {
            NekoClient.Logging.Log.Info("AimeResult OfflineId");

            __result = AimeOfflineId.Make(AccessCode.Zero);

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_RelatedAimeIdCount")]
        private static bool GetRelatedAimeIdCount(ref int __result)
        {
            NekoClient.Logging.Log.Info("AimeResult RelatedAimeIdCount");

            __result = 0;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_RelatedAimeIds")]
        private static bool GetRelatedAimeIds(ref LazyCollection<AimeId> __result)
        {
            NekoClient.Logging.Log.Info("AimeResult RelatedAimeIds");

            __result = new LazyCollection<AimeId>(() =>
            {
                return 0;
            },
            (a) =>
            {
                return AimeId.Zero;
            }, true);

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeResult), "get_SegaIdAuthKey")]
        private static bool GetSegaIdAuthKey(ref string __result)
        {
            NekoClient.Logging.Log.Info("AimeResult SegaIdAuthKey");

            __result = "skeeter yeeter";

            return false;
        }
    }
}
