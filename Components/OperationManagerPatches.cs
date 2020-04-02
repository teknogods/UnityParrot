using MU3.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityParrot.Components
{
    public class OperationManagerPatches
    {
        public static void Patch()
        {
            Harmony.PatchAllInType(typeof(OperationManagerPatches));
            Harmony.MakeRET(typeof(OperationManager), "isAimeOffline");
            Harmony.MakeRET(typeof(OperationManager), "isAimeLoginDisable");
            Harmony.MakeRET(typeof(OperationManager), "isAutoRebootNeeded");
            Harmony.MakeRET(typeof(OperationManager), "isClosed");
            Harmony.MakeRET(typeof(OperationManager), "isCoinAcceptable", true);
            Harmony.MakeRET(typeof(OperationManager), "isLoginDisable");
            Harmony.MakeRET(typeof(OperationManager), "isRebootNeeded");
            Harmony.MakeRET(typeof(OperationManager), "isShowClosingRemainingMinutes");
            Harmony.MakeRET(typeof(OperationManager), "isUnderServerMaintenance");
        }

        [MethodPatch(PatchType.Prefix, typeof(OperationManager), "getCreditUseRestrictionByClose")]
        static bool getCreditUseRestrictionByClose(ref ClosingManager.CreditUseRestriction __result)
        {
            __result = ClosingManager.CreditUseRestriction.None;
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(OperationManager), "getCreditUseRestrictionByMaintenance")]
        static bool getCreditUseRestrictionByMaintenance(ref ClosingManager.CreditUseRestriction __result)
        {
            __result = ClosingManager.CreditUseRestriction.None;
            return false;
        }
    }
}
