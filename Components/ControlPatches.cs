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
        private static bool IsButton(GameDeviceManager.GKey __0)
        {
            switch (__0)
            {
                case GameDeviceManager.GKey.WestL:
                    return Input.GetKeyDown(KeyCode.W);
                case GameDeviceManager.GKey.WestC:
                    return Input.GetKeyDown(KeyCode.E);
                case GameDeviceManager.GKey.WestR:
                    return Input.GetKeyDown(KeyCode.R);
                case GameDeviceManager.GKey.EastL:
                    return Input.GetKeyDown(KeyCode.S);
                case GameDeviceManager.GKey.EastC:
                    return Input.GetKeyDown(KeyCode.D);
                case GameDeviceManager.GKey.EastR:
                    return Input.GetKeyDown(KeyCode.F);
                case GameDeviceManager.GKey.WestK:
                    return Input.GetKeyDown(KeyCode.Q);
                case GameDeviceManager.GKey.EastK:
                    return Input.GetKeyDown(KeyCode.T);
                case GameDeviceManager.GKey.WestM:
                    return Input.GetKeyDown(KeyCode.LeftArrow);
                case GameDeviceManager.GKey.EastM:
                    return Input.GetKeyDown(KeyCode.RightArrow);
            }

            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(GameDeviceManager), "isButtonHold")]
        private static bool IsButtonHold(GameDeviceManager.GKey __0)
        {
            switch (__0)
            {
                case GameDeviceManager.GKey.WestL:
                    return Input.GetKey(KeyCode.W);
                case GameDeviceManager.GKey.WestC:
                    return Input.GetKey(KeyCode.E);
                case GameDeviceManager.GKey.WestR:
                    return Input.GetKey(KeyCode.R);
                case GameDeviceManager.GKey.EastL:
                    return Input.GetKey(KeyCode.S);
                case GameDeviceManager.GKey.EastC:
                    return Input.GetKey(KeyCode.D);
                case GameDeviceManager.GKey.EastR:
                    return Input.GetKey(KeyCode.F);
                case GameDeviceManager.GKey.WestK:
                    return Input.GetKey(KeyCode.Q);
                case GameDeviceManager.GKey.EastK:
                    return Input.GetKey(KeyCode.T);
                case GameDeviceManager.GKey.WestM:
                    return Input.GetKey(KeyCode.LeftArrow);
                case GameDeviceManager.GKey.EastM:
                    return Input.GetKey(KeyCode.RightArrow);
            }

            return true;
        }
    }
}
