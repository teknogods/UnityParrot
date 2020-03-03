using Harmony;
using MU3.Battle;
using NekoClient.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace UnityParrot
{
    public enum PatchType
    {
        Prefix,
        Postfix,
        Transpiler
    };

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MethodPatchAttribute : Attribute
    {
        public Type TargetType;
        public string TargetMethod;
        public PatchType PatchType;

        public MethodPatchAttribute(PatchType patchType, Type targetType, string targetMethod)
        {
            PatchType = patchType;
            TargetType = targetType;
            TargetMethod = targetMethod;
        }
    }

    public static class Harmony
    {
        private static readonly HarmonyInstance ms_harmony;

        public static HarmonyInstance Instance
            => ms_harmony;

        public static HarmonyMethod GetPatch(string name, Type type, BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic)
                => new HarmonyMethod(type.GetMethod(name, flags) 
                    ?? type.GetProperties().FirstOrDefault((PropertyInfo p) => p.GetGetMethod().Name == name)?.GetGetMethod());


        public static void PatchAllInType(Type targetType)
        {
            var methods = targetType.GetMethods((BindingFlags)62);

            foreach (var m in methods)
            {
                var attrs = m.GetCustomAttributes(typeof(MethodPatchAttribute), true);

                if (attrs.Length > 0)
                {
                    foreach (var attr in attrs)
                    {
                        MethodPatchAttribute a = (MethodPatchAttribute)attr;

                        HarmonyMethod harmonyMethod = GetPatch(m.Name, targetType);

                        PerformPatch($"{targetType.Name} # {a.TargetMethod} ({m.Name})",
                            a.TargetType.GetMethod(a.TargetMethod, (BindingFlags)62),
                            a.PatchType == PatchType.Prefix ? harmonyMethod : null,
                            a.PatchType == PatchType.Postfix ? harmonyMethod : null,
                            a.PatchType == PatchType.Transpiler ? harmonyMethod : null);
                    }
                }
            }
        }

        public static void PerformPatch(string patchName, MethodBase original, HarmonyMethod prefix = null, HarmonyMethod postfix = null, HarmonyMethod transpiler = null)
        {
            string logMessage = $"Performing {patchName} patch... ";

            try
            {
                if (original == null)
                {
                    logMessage += "failed! method does not exist!";
                }
                else
                {
                    ms_harmony.Patch(original, prefix, postfix, transpiler);
                    logMessage += "succeeded!";
                }
            }
            catch (Exception e)
            {
                logMessage += $"failed! (Exception: {e.InnerException.Message})";
            }

            Log.Info(logMessage);
        }


        public static void MakeRET(Type targetType, string methodName, bool retVal = false)
        {
            var meth = targetType.GetMethod(methodName, (BindingFlags)62);
            var ret = meth.ReturnType;

            if (ret == typeof(void))
            {
                PerformPatch($"MakeRET {targetType.Name} # {methodName}", meth, GetPatch("DontContinue", typeof(Harmony)));
            }
            else if (ret == typeof(bool))
            {
                PerformPatch($"MakeRET {targetType.Name} # {methodName}", meth, GetPatch(retVal ? "ReturnTrue" : "ReturnFalse", typeof(Harmony)));
            }
            else
            {
                Log.Info($"MakeRET not supported for type: {ret.FullName}");
            }
        }

        static bool ReturnFalse(ref bool __result)
        {
            __result = false;
            return false;
        }

        static bool ReturnTrue(ref bool __result)
        {
            __result = true;
            return false;
        }

        static bool DontContinue()
        {
            return false;
        }


        static Harmony()
        {
            ms_harmony = HarmonyInstance.Create("UnityParrot.ONGEKI.Patches");
        }
    }
}
