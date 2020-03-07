using Harmony;
using MU3.Mecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class JvsPatches
    {
        public static void Patch()
        {
            Harmony.MakeRET(typeof(Jvs), "execute");

            Type type = typeof(Jvs).GetNestedType("JvsSwitch", (BindingFlags)62);

            Harmony.PerformPatch("JvsSwitch # .ctor",
               type.GetConstructor((BindingFlags)62, null, new Type[] { typeof(int), typeof(string), typeof(KeyCode), typeof(bool), typeof(bool) }, null),
               transpiler: Harmony.GetPatch("JvsSwitchCtorPatch", typeof(JvsPatches)));

            type = typeof(Jvs).GetNestedType("JvsAnalog", (BindingFlags)62);

            Harmony.PerformPatch("JvsAnalog # getValue",
               type.GetMethod("getValue", (BindingFlags)62),
               prefix: Harmony.GetPatch("JvsAnalogGetValuePatch", typeof(JvsPatches)));
        }

        static IEnumerable<CodeInstruction> JvsSwitchCtorPatch(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);

            codes.RemoveRange(27, 23);

            return codes.AsEnumerable();
        }

        static float currentAnalog = 0f;

        static bool JvsAnalogGetValuePatch(ref float __result)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && currentAnalog > -1f)
            {
                currentAnalog -= Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow) && currentAnalog < 1f)
            {
                currentAnalog += Time.deltaTime;
            }

            return false;
        }
    }
}
