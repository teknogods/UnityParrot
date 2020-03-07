using MU3;
using MU3.Sys;
using System.IO;

namespace UnityParrot.Components
{
    public class SysConfigPatches
    {
        public static void Patch()
        {
            Harmony.PatchAllInType(typeof(SysConfigPatches));

            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isPlatformAlls", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isDummyJvs", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isNewButtonAssign", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isRevertAnalog", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isInvertWallButtonL", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isInvertWallButtonR", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isDummyCredit", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isDummyAime", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isIgnoreError", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isUseOptionDev", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isWasapiExclusive", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isUseNetwork", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isUseAllnet", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isUseLocalCollab", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isForceLogout", false);
            // get_serverUri
            // get_cameraType
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isKeyboardInput", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isKeyboardCredit", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isKeyboardDebug", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isQuickStart", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isDispDelay", false);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isLoadNoteTap", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isLoadNoteHold", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isLoadNoteFlick", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isLoadBell", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isLoadBullet", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isLoadTapLane", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isLoadWallLane", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isLoadEnemyLane", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isLoadField", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isLoadOneway", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isLoadSoflan", true);
            Harmony.MakeRET(typeof(MU3.Sys.Config), "get_isSimpleLane", false);
        }

        [MethodPatch(PatchType.Prefix, typeof(MU3.Sys.Config), "get_serverUri")]
        static bool ServerUri(ref string __result)
        {
            __result = string.Empty;
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(MU3.Sys.Config), "get_cameraType")]
        static bool CameraType(ref int __result)
        {
            __result = 1;
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(NetConfig), "get_ClientId")]
        static bool ClientId(ref string __result)
        {
            __result = "JEMOEDER";
            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(MU3.Sys.Path), "get_logPath")]
        static bool LogPath(ref string __result)
        {
            __result = Directory.GetCurrentDirectory();
            return false;
        }
    }
}
