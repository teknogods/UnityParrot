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
            Harmony.PerformPatch("AMBookkeep#clearTotal",
                typeof(BackupBookkeep).GetMethod("clearTotal", System.Reflection.BindingFlags.Public),
                transpiler: Harmony.GetPatch("clearTotalTranspiler", typeof(BookkeepPatches)));

            Harmony.PerformPatch("AMBookkeep#endPlayTime",
                typeof(BackupBookkeep).GetMethod("endPlayTime", System.Reflection.BindingFlags.Public),
                transpiler: Harmony.GetPatch("endPlayTimeTranspiler", typeof(BookkeepPatches)));

            Harmony.PerformPatch("AMBookkeep#startPlayTime",
                typeof(BackupBookkeep).GetMethod("startPlayTime", System.Reflection.BindingFlags.Public),
                transpiler: Harmony.GetPatch("startPlayTimeTranspiler", typeof(BookkeepPatches)));
        }

        static IEnumerable<CodeInstruction> clearTotalTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);

            codes.RemoveRange(0, 2);
            codes.RemoveRange(10 - 2, 4);

            return codes.AsEnumerable();
        }

        static IEnumerable<CodeInstruction> endPlayTimeTranspiler(IEnumerable<CodeInstruction> instructions)
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

            codes.RemoveRange(targetIdx - 1, 2);

            return codes.AsEnumerable();
        }
    }
}
