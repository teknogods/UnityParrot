using MU3.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityParrot.Components
{
    public class OperationManagerPatches
    {
        public static void Patch()
        {
            Harmony.MakeRET(typeof(OperationManager), "isAimeOffline");
            Harmony.MakeRET(typeof(OperationManager), "isAimeLoginDisable");
        }
    }
}
