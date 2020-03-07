using AMDaemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class AimeUnitPatches
    {
        public static void Patch()
        {
            Harmony.PatchAllInType(typeof(AimeUnitPatches));

            Harmony.PerformPatch("AimeUnit#.ctor",
               typeof(AimeUnit).GetConstructor((System.Reflection.BindingFlags)62, null, new Type[] { typeof(IntPtr) }, null),
               prefix: Harmony.GetPatch("AimeUnitCtorPatch", typeof(Main)));
        }

        private static bool AimeUnitCtorPatch()
        {
            NekoClient.Logging.Log.Info("AimeUnit .ctor");
            // don't continue
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeUnit), "Start")]
        private static bool AimeStart(AimeCommand __0, ref bool __result)
        {
            NekoClient.Logging.Log.Info($"AimeUnit Start: {__0.ToString()}");

            __result = true;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeUnit), "Cancel")]
        private static bool AimeCancel(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeUnit Cancel");

            __result = false;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeUnit), "get_Confirm")]
        private static bool GetConfirm(ref AimeConfirm __result)
        {
            NekoClient.Logging.Log.Info("AimeUnit Confirm");

            __result = AimeConfirm.AimeDB;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeUnit), "get_HasConfirm")]
        private static bool GetHasConfirm(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeUnit HasConfirm");

            __result = true;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeUnit), "get_HasError")]
        private static bool GetHasError(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeUnit HasError");

            __result = false;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeUnit), "get_HasResult")]
        private static bool GetHasResult(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeUnit HasResult");

            __result = true;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeUnit), "get_IsBusy")]
        private static bool GetIsBusy(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeUnit IsBusy");

            __result = false;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeUnit), "get_LedStatus")]
        private static bool GetLedStatus(ref AimeLedStatus __result)
        {
            NekoClient.Logging.Log.Info("AimeUnit LedStatus");

            __result = AimeLedStatus.Success;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeUnit), "SetLed")]
        private static bool SetLed(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeUnit SetLed");

            __result = false;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeUnit), "SetLedStatus")]
        private static bool SetLedStatus(ref bool __result)
        {
            NekoClient.Logging.Log.Info("AimeUnit SetLedStatus");

            __result = false;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(AimeUnit), "get_Result")]
        private static bool GetResult(ref AimeResult __result)
        {
            NekoClient.Logging.Log.Info("AimeUnit Result");

            __result = (AimeResult)Activator.CreateInstance(typeof(AimeResult), (System.Reflection.BindingFlags)62, null, new object[] { IntPtr.Zero }, null);

            return false;
        }
    }
}
