using MU3;

namespace UnityParrot.Components
{
    public class ControlPatches
    {
        public static void Patch()
        { 
            Harmony.PatchAllInType(typeof(ControlPatches));
        }

        [MethodPatch(PatchType.Prefix, typeof(MU3.Sys.Config), "get_isKeyboardInput")]
        [MethodPatch(PatchType.Prefix, typeof(MU3.Sys.Config), "get_isKeyboardDebug")]
        private static bool ReturnTrueDontContinue(ref bool __result)
        {
            __result = true;
            return false;
        }

        static bool testModeHit = false;

        //[MethodPatch(PatchType.Prefix, typeof(UIInput), "getTriggerOn")]
        private static bool GetTrigger(ref bool __result, UIInput.Key __0, bool __1)
        {
            if (__0 == UIInput.Key.Test && !testModeHit)
            {
                NekoClient.Logging.Log.Info("yeet");

                testModeHit = true;

                __result = true;

                return false;
            }

            return true;
        }
    }
}
