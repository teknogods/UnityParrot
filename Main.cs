using NekoClient.Logging;
using System.Threading;
using UnityEngine;

namespace UnityParrot
{
    class Main
    {
        public static void Initialize()
        {
            new Thread(() =>
            {
                Thread.Sleep(250);

                Log.Initialize(LogLevel.All);
                Log.AddListener(new ConsoleLogListener());
                Log.AddListener(new TraceLogListener());
                Log.AddListener(new GameLogListener());
                Log.AddListener(new FileLogListener(FileSystem.Configuration.GetFilePath("..\\UnityParrot.log"), true));

                Log.Info("\n\n\nYAY");

                GameObject mainObject = new GameObject();

                /* save/load */
                mainObject.AddComponent<Components.AimePatches>();
                mainObject.AddComponent<Components.AimeUnitPatches>();
                mainObject.AddComponent<Components.AimeResultPatches>();
                mainObject.AddComponent<Components.AimeIdPatches>();
                mainObject.AddComponent<Components.AccessCodePatches>();
                mainObject.AddComponent<Components.PacketPatches>();

                /* misc */
                mainObject.AddComponent<Components.AMDaemonPatches>();
                mainObject.AddComponent<Components.AMManagerPatches>();
                mainObject.AddComponent<Components.BackupSettingPatches>();
                mainObject.AddComponent<Components.BookkeepPatches>();
                mainObject.AddComponent<Components.ControlPatches>();
                mainObject.AddComponent<Components.CreditPatches>();
                mainObject.AddComponent<Components.SequenceInitializePatches>();
                mainObject.AddComponent<Components.SerialPatches>();
                mainObject.AddComponent<Components.SysConfigPatches>();

                Screen.fullScreen = false;

                UnityEngine.Object.DontDestroyOnLoad(mainObject);
            }).Start();
        }
    }
}