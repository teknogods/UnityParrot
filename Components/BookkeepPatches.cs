using Harmony;
using MU3.AM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class BookkeepPatches : MonoBehaviour
    {
        void Start()
        {
            Harmony.PatchAllInType(typeof(BookkeepPatches));
            Harmony.MakeRET(typeof(BackupBookkeep), "updateCredit");
            Harmony.MakeRET(typeof(BackupBookkeep), "updateRunningTime");
        }

        [MethodPatch(PatchType.Transpiler, typeof(BackupBookkeep), "clearTotal")]
        static IEnumerable<CodeInstruction> ClearTotalTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);

            codes.RemoveRange(0, 4);
            codes.RemoveRange(10 - 4, 4);

            return codes.AsEnumerable();
        }

        // both of these funcs only have one 'call' instruction so the same code can be applied to both
        [MethodPatch(PatchType.Transpiler, typeof(BackupBookkeep), "startPlayTime")]
        [MethodPatch(PatchType.Transpiler, typeof(BackupBookkeep), "endPlayTime")]
        static IEnumerable<CodeInstruction> PlayTimeTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);

            int targetIdx = 0;

            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Call)
                {
                    targetIdx = i;
                }
            }

            // we remove:
            // ldc.i4.0 push 0 to stack
            // call [func]
            // pop

            codes.RemoveRange(targetIdx - 1, 3);

            return codes.AsEnumerable();
        }
    }
}
