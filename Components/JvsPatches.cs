using Harmony;
using MU3.DB;
using MU3.Mecha;
using MU3.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using NekoClient.Logging;

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

            Harmony.PatchAllInType(typeof(JvsPatches));
        }

        static IEnumerable<CodeInstruction> JvsSwitchCtorPatch(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);

            codes.RemoveRange(27, 23);

            return codes.AsEnumerable();
        }

        static float analogRange;
        static float limitBuffer = 0.7f;
        static float lastAnalog = 0.0f;

        [MethodPatch(PatchType.Prefix, typeof(Jvs), "initialize")]
        private static bool initialize()
        {
            if (SettingsManager.instance.settings.AnalogRotateAxis)
            {
                analogRange = (float)Screen.height / 2.0f;
            } else
            {
                analogRange = (float)Screen.width / 2.0f;
            }
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(Jvs), "getRawState")]
        private static bool getRawState(ref bool __result, JvsButtonID __0)
        {
            switch (__0)
            {
                case JvsButtonID.Begin:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonBegin);
                    break;
                case JvsButtonID.Service:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonService);
                    break;
                case JvsButtonID.Push0:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonPush0);
                    break;
                case JvsButtonID.Push1:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonPush1);
                    break;
                case JvsButtonID.LeftWall:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonLeftWall);
                    break;
                case JvsButtonID.Left1:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonLeft1);
                    break;
                case JvsButtonID.Left2:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonLeft2);
                    break;
                case JvsButtonID.Left3:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonLeft3);
                    break;
                case JvsButtonID.LeftMenu:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonLeftMenu);
                    break;
                case JvsButtonID.RightMenu:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonRightMenu);
                    break;
                case JvsButtonID.Right1:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonRight1);
                    break;
                case JvsButtonID.Right2:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonRight2);
                    break;
                case JvsButtonID.Right3:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonRight3);
                    break;
                case JvsButtonID.RightWall:
                    __result = Input.GetKey(SettingsManager.instance.settings.ButtonRightWall);
                    break;
            }

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(Jvs), "getTriggerOn")]
        private static bool getTriggerOn(ref bool __result, JvsButtonID __0)
        {
            switch (__0)
            {
                case JvsButtonID.Begin:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonBegin);
                    break;
                case JvsButtonID.Service:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonService);
                    break;
                case JvsButtonID.Push0:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonPush0);
                    break;
                case JvsButtonID.Push1:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonPush1);
                    break;
                case JvsButtonID.LeftWall:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonLeftWall);
                    break;
                case JvsButtonID.Left1:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonLeft1);
                    break;
                case JvsButtonID.Left2:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonLeft2);
                    break;
                case JvsButtonID.Left3:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonLeft3);
                    break;
                case JvsButtonID.LeftMenu:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonLeftMenu);
                    break;
                case JvsButtonID.RightMenu:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonRightMenu);
                    break;
                case JvsButtonID.Right1:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonRight1);
                    break;
                case JvsButtonID.Right2:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonRight2);
                    break;
                case JvsButtonID.Right3:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonRight3);
                    break;
                case JvsButtonID.RightWall:
                    __result = Input.GetKeyDown(SettingsManager.instance.settings.ButtonRightWall);
                    break;
            }

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(Jvs), "getTriggerOff")]
        private static bool getTriggerOff(ref bool __result, JvsButtonID __0)
        {
            switch (__0)
            {
                case JvsButtonID.Begin:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonBegin);
                    break;
                case JvsButtonID.Service:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonService);
                    break;
                case JvsButtonID.Push0:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonPush0);
                    break;
                case JvsButtonID.Push1:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonPush1);
                    break;
                case JvsButtonID.LeftWall:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonLeftWall);
                    break;
                case JvsButtonID.Left1:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonLeft1);
                    break;
                case JvsButtonID.Left2:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonLeft2);
                    break;
                case JvsButtonID.Left3:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonLeft3);
                    break;
                case JvsButtonID.LeftMenu:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonLeftMenu);
                    break;
                case JvsButtonID.RightMenu:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonRightMenu);
                    break;
                case JvsButtonID.Right1:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonRight1);
                    break;
                case JvsButtonID.Right2:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonRight2);
                    break;
                case JvsButtonID.Right3:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonRight3);
                    break;
                case JvsButtonID.RightWall:
                    __result = Input.GetKeyUp(SettingsManager.instance.settings.ButtonRightWall);
                    break;
            }

            return false;
        }

        // Use height because the touchpad is rotated

        [MethodPatch(PatchType.Prefix, typeof(Jvs), "getAnalog")]
        private static bool getAnalog(ref float __result)
        {
            if (SettingsManager.instance.settings.AnalogControlStyle == AnalogControlStyle.Touchpad.ToString())
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    __result = SettingsManager.instance.settings.AnalogRotateAxis ? touch.position.y : touch.position.x;
                    __result = (__result - analogRange) / (analogRange * limitBuffer);
                } else
                {
                    __result = lastAnalog;
                }
            }
            else if (SettingsManager.instance.settings.AnalogControlStyle == AnalogControlStyle.Mouse.ToString())
            {
                Vector3 mouse = Input.mousePosition;
                __result = SettingsManager.instance.settings.AnalogRotateAxis ? mouse.y : mouse.x;
                __result = (__result - analogRange) / (analogRange * limitBuffer);
            }
            else if (SettingsManager.instance.settings.AnalogControlStyle == AnalogControlStyle.Buttons.ToString())
            {
                if (Input.GetKey(SettingsManager.instance.settings.AnalogLeftButton) &
                    !Input.GetKey(SettingsManager.instance.settings.AnalogRightButton))
                {
                    __result = lastAnalog - Time.deltaTime * SettingsManager.instance.settings.AnalogButtonSensitivity;
                } else if (!Input.GetKey(SettingsManager.instance.settings.AnalogLeftButton) &
                    Input.GetKey(SettingsManager.instance.settings.AnalogRightButton))
                {
                    __result = lastAnalog + Time.deltaTime * SettingsManager.instance.settings.AnalogButtonSensitivity;
                } else
                {
                    __result = lastAnalog;
                }
            }

            __result = __result > 1 ? 1 : __result;
            __result = __result < -1 ? -1 : __result;
            lastAnalog = __result;
            __result = SettingsManager.instance.settings.AnalogInvertAxis ? -1 * __result : __result;

            return false;
        }
    }
}
