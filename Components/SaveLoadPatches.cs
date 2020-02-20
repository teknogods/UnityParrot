using AMDaemon;
using MU3;
using MU3.Client;
using MU3.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class SaveLoadPatches : MonoBehaviour
    {
        static bool shouldCoreBeReady = false;

        void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.F2))
            {
                shouldCoreBeReady = true;
            }

            if (UnityEngine.Input.GetKey(KeyCode.F3))
            {
                var inst = SingletonMonoBehaviour<RootScript>.instance;
                var val = typeof(RootScript).GetField("_sequenceRoot", (System.Reflection.BindingFlags)62).GetValue(inst);
                ((MU3.Sequence.Root)val).setNextState(MU3.Sequence.Root.EState.TestMode);
            }
        }

        [MethodPatch(PatchType.Prefix, typeof(Sequence), "BeginTest")]
        private static bool BeginTest(ref bool __result)
        {
            __result = false;
            return false;
        }

        void Start()
        {

            Harmony.PerformPatch("SaveLoad#CoreIsReady",
                typeof(AMDaemon.Core).GetMethod("get_IsReady", (System.Reflection.BindingFlags)62),
                prefix: Harmony.GetPatch("CoreIsReady", typeof(SaveLoadPatches)));

            Harmony.PerformPatch("SaveLoad#AimeUnits",
                typeof(Aime).GetMethod("get_Units", (System.Reflection.BindingFlags)62),
                prefix: Harmony.GetPatch("GetUnits", typeof(SaveLoadPatches)));

            Harmony.PatchAllInType(typeof(SaveLoadPatches));
        }

        private static bool GetUnits(ref LazyCollection<AimeUnit> __result)
        {
            NekoClient.Logging.Log.Info("GetUnits");

            __result = new LazyCollection<AimeUnit>(() =>
            {
                return 1;
            }, 
            (a) =>
            {
                return (AimeUnit)Activator.CreateInstance(typeof(AimeUnit), (System.Reflection.BindingFlags)62, null, new object[] { IntPtr.Zero }, null);
            }, true);

            return false;
        }

        private static bool CoreIsReady(ref bool __result)
        {

            if (shouldCoreBeReady)
            {
                __result = true;
            }
            else
            {
                __result = false;
            }

            return false;
        }
    }
}
