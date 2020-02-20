using Harmony;
using MU3.AM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class AMMAnagerPatches : MonoBehaviour
    {
        void Start()
        {
            Harmony.PerformPatch("AMManager#execute",
                typeof(AMManager).GetMethod("execute", System.Reflection.BindingFlags.Public),
                transpiler: Harmony.GetPatch("AMManagerExecuteTranspiler", typeof(AMMAnagerPatches)));

            Harmony.PerformPatch("AMManager#Execute_WaitAMDaemonReady",
                typeof(AMManager).GetMethod("Execute_WaitAMDaemonReady", System.Reflection.BindingFlags.NonPublic),
                transpiler: Harmony.GetPatch("AMManagerExecuteWaitAMDaemonReadyTranspiler", typeof(AMMAnagerPatches)));
        }

        static IEnumerable<CodeInstruction> AMManagerExecuteTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            codes.RemoveAt(0); // remove Core.Execute(); call
            return codes.AsEnumerable();
        }

        static IEnumerable<CodeInstruction> AMManagerExecuteWaitAMDaemonReadyTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);

            // remove checks
            codes.RemoveRange(0, 3);
            codes.RemoveRange(5 - 3, 10);

            return codes.AsEnumerable();
        }
    }
}
