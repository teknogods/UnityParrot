using AMDaemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityParrot.Components
{
    public class AMDaemonPatches : MonoBehaviour
    {
        void Start()
        {
            Harmony.MakeRET(typeof(Error), "Set", false);
        }
    }
}
