using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NekoClient.Logging;
using MU3.Util;

namespace UnityParrot.Components
{
    public enum AnalogControlStyle
    {
        Mouse = 0,
        Touchpad = 1,
        Buttons = 2
    }

    [Serializable]
    public class Settings
    {
        public string ButtonBegin;
        public string ButtonService;
        public string ButtonPush0;
        public string ButtonPush1;
        public string ButtonLeftWall;
        public string ButtonLeft1;
        public string ButtonLeft2;
        public string ButtonLeft3;
        public string ButtonRight1;
        public string ButtonRight2;
        public string ButtonRight3;
        public string ButtonRightWall;
        public string ButtonRightMenu;
        public string ButtonLeftMenu;

        public string AnalogControlStyle;
        public bool AnalogInvertAxis;
        public bool AnalogRotateAxis;
        public string AnalogLeftButton;
        public string AnalogRightButton;
        public float AnalogButtonSensitivity;

        public bool DisplayFullscreen;

        public string AimeButton;

        public bool EnableEvents;
        public bool RotatingWeeklyEvents;
        public bool RotatingDailyEvents;
        public int EventId;
    }

    public class SettingsManager : SingletonMonoBehaviour<SettingsManager>
    {
        protected Settings settings_;
        public Settings settings
        {
            get { return this.settings_; }
        }

        void Start()
        {
            string fileName = "Settings.json";
            settings_ = new Settings();

            if (!FileSystem.Configuration.FileExists(fileName))
            {
                settings_.ButtonBegin = "f8";
                settings_.ButtonService = "f9";
                settings_.ButtonPush0 = "f10";
                settings_.ButtonPush1 = "f11";
                settings_.ButtonLeftWall = "a";
                settings_.ButtonLeft1 = "s";
                settings_.ButtonLeft2 = "d";
                settings_.ButtonLeft3 = "f";
                settings_.ButtonRight1 = "w";
                settings_.ButtonRight2 = "e";
                settings_.ButtonRight3 = "r";
                settings_.ButtonRightWall = "g";
                settings_.ButtonRightMenu = "t";
                settings_.ButtonLeftMenu = "q";

                settings_.AnalogControlStyle = AnalogControlStyle.Mouse.ToString();
                settings_.AnalogInvertAxis = false;
                settings_.AnalogRotateAxis = false;
                settings_.AnalogLeftButton = "left";
                settings_.AnalogRightButton = "right";
                settings_.AnalogButtonSensitivity = 1.5f;

                settings_.DisplayFullscreen = true;

                settings_.AimeButton = "f2";

                settings_.EnableEvents = false;
                settings_.EventId = -1;
                settings_.RotatingWeeklyEvents = false;
                settings_.RotatingDailyEvents = false;

                FileSystem.Configuration.SaveJson(fileName, settings_);
            }

            settings_ = FileSystem.Configuration.LoadJson<Settings>(fileName);
        }
    }






}
