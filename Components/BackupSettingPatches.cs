using MU3.AM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class BackupSettingPatches : MonoBehaviour
    {
        void Start()
        {
            Harmony.MakeRET(typeof(BackupBookkeep), "get_isEventModeSettingAvailable", true);
        }
    }
}
