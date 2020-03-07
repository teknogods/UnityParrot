using MU3;
using UnityEngine;

namespace UnityParrot.Components
{
    public class ControlPatches
    {
        public static void Patch()
        { 
            Harmony.PatchAllInType(typeof(ControlPatches));

            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isKeyboardInput", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isKeyboardDebug", true);
        }

        [MethodPatch(PatchType.Prefix, typeof(GameDeviceManager), "isButton")]
        private static bool IsButton(ref bool __result, GameDeviceManager.GKey __0)
        {
            switch (__0)
            {
                case GameDeviceManager.GKey.WestL:
                    __result = Input.GetKeyDown(KeyCode.W);
                    break;
                case GameDeviceManager.GKey.WestC:
                    __result = Input.GetKeyDown(KeyCode.E);
                    break;
                case GameDeviceManager.GKey.WestR:
                    __result = Input.GetKeyDown(KeyCode.R);
                    break;
                case GameDeviceManager.GKey.EastL:
                    __result = Input.GetKeyDown(KeyCode.S);
                    break;
                case GameDeviceManager.GKey.EastC:
                    __result = Input.GetKeyDown(KeyCode.D);
                    break;
                case GameDeviceManager.GKey.EastR:
                    __result = Input.GetKeyDown(KeyCode.F);
                    break;
                case GameDeviceManager.GKey.WestK:
                    __result = Input.GetKeyDown(KeyCode.Q);
                    break;
                case GameDeviceManager.GKey.EastK:
                    __result = Input.GetKeyDown(KeyCode.T); 
                    break;
                case GameDeviceManager.GKey.WestM:
                    __result = Input.GetKeyDown(KeyCode.LeftArrow);
                    break;
                case GameDeviceManager.GKey.EastM:
                    __result = Input.GetKeyDown(KeyCode.RightArrow);
                    break;
            }

            return __result ? false : true;
        }

        [MethodPatch(PatchType.Prefix, typeof(GameDeviceManager), "isButtonHold")]
        private static bool IsButtonHold(ref bool __result, GameDeviceManager.GKey __0)
        {
            switch (__0)
            {
                case GameDeviceManager.GKey.WestL:
                    __result = Input.GetKey(KeyCode.W);
                    break;
                case GameDeviceManager.GKey.WestC:
                    __result = Input.GetKey(KeyCode.E);
                    break;
                case GameDeviceManager.GKey.WestR:
                    __result = Input.GetKey(KeyCode.R);
                    break;
                case GameDeviceManager.GKey.EastL:
                    __result = Input.GetKey(KeyCode.S);
                    break;
                case GameDeviceManager.GKey.EastC:
                    __result = Input.GetKey(KeyCode.D);
                    break;
                case GameDeviceManager.GKey.EastR:
                    __result = Input.GetKey(KeyCode.F);
                    break;
                case GameDeviceManager.GKey.WestK:
                    __result = Input.GetKey(KeyCode.Q);
                    break;
                case GameDeviceManager.GKey.EastK:
                    __result = Input.GetKey(KeyCode.T);
                    break;
                case GameDeviceManager.GKey.WestM:
                    __result = Input.GetKey(KeyCode.LeftArrow);
                    break;
                case GameDeviceManager.GKey.EastM:
                    __result = Input.GetKey(KeyCode.RightArrow);
                    break;
            }

            return __result ? false : true;
        }
    }
}
