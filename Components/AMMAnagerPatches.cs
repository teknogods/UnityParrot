using Harmony;
using MU3.AM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class AMManagerPatches : MonoBehaviour
    {
        void Start()
        {
			Harmony.PatchAllInType(typeof(AMManagerPatches));
        }

        [MethodPatch(PatchType.Transpiler, typeof(AMManager), "execute")]
        static IEnumerable<CodeInstruction> AMManagerExecuteTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            codes.RemoveAt(0); // remove Core.Execute(); call
            return codes.AsEnumerable();
        }

        [MethodPatch(PatchType.Transpiler, typeof(AMManager), "Execute_WaitAMDaemonReady")]
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
